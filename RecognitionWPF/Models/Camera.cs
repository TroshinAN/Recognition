using System;
using System.Collections.Generic;
using HikvisionLibrary;
using IntLabLibrary;

namespace RecognitionWPF.Models
{
    internal class Camera
    {
        public ConnetionsCamera ConnetionsCamera { get; private set; }
        private readonly HikvisionCamera camera;
        private DllHandle imageSource;
        private DeviceInfo deviceInfo = new DeviceInfo();
        private PreviewInfo previewInfo;
        private JpegParameters jpegParameters = new JpegParameters { wPicSize = 0xff, wPicQuality = 2 };

        public int ID { get { return ConnetionsCamera.ID; } }

        public string Name { get { return ConnetionsCamera.Name; } }

        public int UserID { get; private set; } = -1;

        public int VideoHandle { get; private set; } = -1;

        public bool IsLogin { get { return UserID >= 0; } }

        public bool IsRunVideo { get { return VideoHandle >= 0; } }

        public DeviceInfo DeviceInfo { get { return deviceInfo; } }

        public PreviewInfo PreviewInfo { get { return previewInfo; } }

        public JpegParameters JpegParameters { get { return jpegParameters; } set { jpegParameters = value; } }

        public List<String> PathFrames { get; set; } = new List<string>();

        public Camera(HikvisionCamera camera, ConnetionsCamera connetions)
        {
            this.camera = camera;
            SetConnetionsCamera(connetions);
        }

        public void SetConnetionsCamera(ConnetionsCamera connetions)
        {
            this.ConnetionsCamera = connetions ?? this.ConnetionsCamera;
        }

        public DllHandle GetImageSource(Recognition recognition, DllHandle aggregator, ref FrameSize frameSize)
        {
            if (false) // Обновлять ресурс изображения ?
            {
                return recognition.AddImageSource(aggregator, GetImageSource(ref frameSize), $"--name {this.Name}");
            }
            else
            {
                return imageSource ?? (imageSource = recognition.AddImageSource(aggregator, GetImageSource(ref frameSize), $"--name {this.Name}"));
            }
        }

        private ImageSourceConfig GetImageSource(ref FrameSize frameSize)
        {
            var perc = Convert.ToDecimal(this.ConnetionsCamera.Frame.HeigthWordPercent) / 100;

            var imageConfig = new ImageSourceConfig
            {
                ImageSourceSetup = new ImageSourceDescriptor
                {
                    FrameFormat = ImageFormat.JPG,
                    FrameSize = frameSize,
                    RoiRect = new FrameRectangle { Width = frameSize.Width, Height = frameSize.Height },
                    CameraSetup = new CameraSetup
                    {
                        FrameSize = new FrameSize { Width = frameSize.Width, Height = frameSize.Height },
                        Intrinsic = new CameraIntrinsicSetup { FrameSize = new FrameSize { Width = frameSize.Width, Height = frameSize.Height } },
                    }
                },
                RecognitionSetup = new RecognitionSetup { TypicalCharHeightSize = (int)(frameSize.Height * perc) }
            };
            return imageConfig;
        }

        public bool Login()
        {
            if (!IsLogin)
            {
                if (!Int32.TryParse(ConnetionsCamera.Port, out int port))
                {
                    camera.MessageForUser($"Порт '{ConnetionsCamera.Port}' для камеры №{ConnetionsCamera.ID} имеет недопустимый формат.");
                    return false;
                }
#if DEBUG
                UserID = 1;
#else
                UserID = camera.Login(ConnetionsCamera.Address, port, ConnetionsCamera.Login, ConnetionsCamera.Password, ref deviceInfo);
#endif
            }
            return IsLogin;
        }

        public void Logout()
        {
            if (IsLogin)
            {
#if !DEBUG
                camera.Logout(UserID);
#endif
                UserID = -1;
            }
        }

        public void StartRealPlay(IntPtr videoResource)
        {
            if (IsLogin && !IsRunVideo)
            {
                previewInfo = new PreviewInfo
                {
                    hPlayWnd = videoResource,
                    lChannel = DeviceInfo.byStartChan,
                    dwStreamType = 0,
                    dwLinkMode = 0,
                    bBlocked = true,
                    dwDisplayBufNum = 1,
                    byProtoType = 0,
                    byPreviewMode = 0
                };

#if DEBUG
                VideoHandle = 1;
#else
                VideoHandle = camera.StartRealPlay(UserID, ref previewInfo, null, IntPtr.Zero);
#endif
            }
        }

        public void StopRealPlay()
        {
            if (IsLogin && IsRunVideo)
            {
#if !DEBUG
                camera.StopRealPlay(VideoHandle);
#endif
                VideoHandle = -1;
            }
        }

        public bool SaveImageToJpeg(string fileName = null)
        {
            if (IsLogin)
            {
                string puthFile = String.Empty;
                PathFrames = new List<string>();
#if DEBUG
                return true;
#else
                for (int i = 1; i <= ConnetionsCamera.Frame.Count; i++)
                {
                    puthFile = fileName ?? String.Format("{0}{1}_{2}.jpg", MainWindowModel.PathToFrame, ConnetionsCamera.Name, i);

                    if (camera.SaveJpegPicture(UserID, DeviceInfo.byStartChan, ref jpegParameters, puthFile))
                    {
                        PathFrames.Add(puthFile);
                    }

                    if (i != ConnetionsCamera.Frame.Count)
                    {
                        System.Threading.Thread.Sleep(ConnetionsCamera.Frame.TimeBetweenFrame);
                    }
                }

                return true;
#endif
            }
            return false;
        }
    }
}