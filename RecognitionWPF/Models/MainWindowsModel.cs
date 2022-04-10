using System;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Collections.Generic;
using IntLabLibrary;
using HikvisionLibrary;
using System.IO;

namespace RecognitionWPF.Models
{
    public class MainWindowModel
    {
        public static readonly string PathToFrame = Environment.CurrentDirectory + "\\Frames\\";

        private HikvisionCamera camera;
        private readonly List<Camera> Cameras = new List<Camera>();
        private readonly SQLManager SQLManager;
        private Recognition recognition;
        private DllHandle aggregator;
        private SettingCameras SettingCam;
        private BackgroundWorker workIntLabLibrary;
        private BackgroundWorker workAnalysisFrame;
        private bool isRunTimeAnalysisProcesses = false;
        private List<BackgroundWorker> AnalysysDoWorkers;

        public Action<string> DisplayMessage = delegate { };
        public Action<bool> InitRecognitionLibCompleted = delegate { };
        public Action SingleFrameAnalysisCompleted = delegate { };
        public Action RunTimeFrameAnalysisCompleted = delegate { };
        public Action<string> ChahgeStatusRecognition = delegate { };
        public Action<Result, string> ResultIsRecogniotion = delegate { };

        public bool IsInitRecognition { get; set; } = false;
        public bool IsInitCamera { get; set; } = false;

        public MainWindowModel()
        {
            DisplayMessage += (message) => { Logs.SaveMessageForUser(message); };
            SQLManager = new SQLManager();
            SQLManager.DisplayMessage += MessageToForm;
        }

        #region RecognituinLibrary
        public bool InitRecognitionLib(LibraryType type)
        {
            if (recognition == null)
            {
                try
                {
                    recognition = Recognition.CreateInterface(type);
                    recognition.StopByError += MessageFromRecogntion;
                }
                catch (Exception ex)
                {
                    MessageToForm(ex.Message);
                    return false;
                }
            }

            StartAsincInitRecognitionLib();
            return true;
        }

        public void FreeRecognitionLibrary()
        {
            FreeAggregator();
#if !DEBUG
            recognition.LibraryFree();
            SQLManager.Logout();
#endif
            IsInitRecognition = false;
            MessageToForm("Ресурсы библиотеки распознавания успешно освобождены.");
        }

        #region InitRegionLibrary
        private void StartAsincInitRecognitionLib()
        {
            workIntLabLibrary = new BackgroundWorker();
            workIntLabLibrary.DoWork += new DoWorkEventHandler(InitializeIntLabLibrary);
            workIntLabLibrary.RunWorkerCompleted += new RunWorkerCompletedEventHandler(AsincInitRecogniotionLibCompleted);
            workIntLabLibrary.RunWorkerAsync();
        }

        private void InitializeIntLabLibrary(object sender, DoWorkEventArgs e)
        {
            var resultLibraryInit = true;
            ChahgeStatusRecognition("Инициализация библиотеки распознавания.");
            resultLibraryInit = SQLManager.Login();
#if DEBUG
            System.Threading.Thread.Sleep(2000);
#else
            if (resultLibraryInit)
            {
                resultLibraryInit = recognition.LibraryInit(new LibraryConfig());
            }
#endif

            if (resultLibraryInit)
            {
                IsInitRecognition = CreateAggregator();
                if (IsInitRecognition)
                {
                    MessageToForm("Библиотека распознавания инициализирована.");
                }
            }

            e.Result = IsInitRecognition;
        }

        private void AsincInitRecogniotionLibCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            InitRecognitionLibCompleted((bool)(e.Result ?? false));
            ChahgeStatusRecognition("");
            workIntLabLibrary.Dispose();
        }
        #endregion

        #region Create/update/free Aggregator
        private bool CreateAggregator()
        {
#if DEBUG
            aggregator = new DllHandle(LibraryType.WAGON);
#else
            aggregator = recognition.CreateAggregator(new AggregatorConfig { LicenseType = LicenseType.VIDEO });
#endif

            if (aggregator != null)
            {
#if DEBUG
                var lastError = new ErrorReportList { Errors = new List<ErrorReport> { new ErrorReport { ErrorCode = "0" } } };
#else
                var lastError = ObjectToJson.ToObject<ErrorReportList>(recognition.GetLastError(aggregator));
#endif
                if (lastError.Errors.Count == 1 && lastError.Errors.First().ErrorCode == "0")
                {
                    return true;
                }
            }
            return false;
        }

        private void FreeAggregator()
        {
            if (aggregator != null)
            {
#if !DEBUG
                recognition.ReleaseAggregator(aggregator);
#endif
                aggregator = null;
            }
        }

        private void UpdateAggregator()
        {
            ChahgeStatusRecognition("Обновление агрегатора распознавания.");
            FreeAggregator();
            CreateAggregator();
        }
        #endregion

        public void RunTimeFrameAnalysisStart()
        {
            isRunTimeAnalysisProcesses = true;
            FrameAnalysisInit(true);
        }

        public void RunTimeFrameAnalysisStop()
        {
            isRunTimeAnalysisProcesses = false;
        }

        public void SingleFrameAnalysisStart()
        {
            FrameAnalysisInit();
        }

        private void FrameAnalysisInit(bool isRuntime = false)
        {
            if (workAnalysisFrame == null)
            {
                workAnalysisFrame = new BackgroundWorker();
                workAnalysisFrame.DoWork += AnalysisFrame_DoWork;
                workAnalysisFrame.RunWorkerCompleted += (sender, e) => { if (isRuntime) RunTimeFrameAnalysisCompleted(); else SingleFrameAnalysisCompleted(); };
            }
            workAnalysisFrame.RunWorkerAsync();
        }

        private void AnalysisFrame_DoWork(object sender, DoWorkEventArgs e)
        {
            SettingCam = SettingSerializer.Deserializer<SettingCameras>(SettingCameras.FileName);
            AnalysysDoWorkers = new List<BackgroundWorker>();

            foreach (var cam in Cameras)
            {
                var analysysBackgroundWorker = new BackgroundWorker();
                analysysBackgroundWorker.DoWork += AnalysysBackgroundWorker_DoWork;
                AnalysysDoWorkers.Add(analysysBackgroundWorker);
            }

            do
            {
                FrameAnalysisStart();
            } while (isRunTimeAnalysisProcesses);
        }

        private void FrameAnalysisStart()
        {
            if (aggregator != null)
            {
                // Если будет ошибка, связанная с переполнением памяти - то установить условие в True (обновление агрегатора перед каждым циклом распознавания);
                if (false)
                {
                    UpdateAggregator();
                }

                // Если в потоке будет всё печально и не будет работать как нужно - то отключить (установить условие в false)
                // Если true - для каждой камеры распознавание проходит в отдельном потоке.
                if (true)
                {
                    if (Cameras.Count != AnalysysDoWorkers.Count)
                    {
                        return;
                    }

                    for (int i = 0; i < Cameras.Count; i++)
                    {
                        AnalysysDoWorkers[i].RunWorkerAsync(Cameras[i]);
                    }

                    bool runWorkersIsRun;
                    do
                    {
                        runWorkersIsRun = false;
                        foreach (var work in AnalysysDoWorkers)
                        {
                            runWorkersIsRun = runWorkersIsRun || work.IsBusy;
                        }
                    } while (runWorkersIsRun);
                    GetAndParsingResult();
                }
                else
                {
                    foreach (var cam in Cameras)
                    {
                        AnalysysCamera(cam);
                    }
                    GetAndParsingResult();
                }
            }
        }

        private void AnalysysBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Camera cam = e.Argument as Camera;

            if (cam != null)
            {
                cam.SetConnetionsCamera(SettingCam.Cameras.FirstOrDefault(f => f.ID == cam.ID));
                AnalysysCamera(cam);
            }
        }

        private void AnalysysCamera(Camera cam)
        {
            byte[] bytesImage;
            FrameSize frameSize = new FrameSize { Width = 1600, Height = 900 };
            try
            {
                ChahgeStatusRecognition($"Добавление ресурса изображения для \"{cam.Name}\".");
#if DEBUG
                var imageSource = new DllHandle(LibraryType.WAGON);
#else
                //var imageSource = recognition.AddImageSource(aggregator, imageConfig, $"--name {cam.Name}");
                var imageSource = cam.GetImageSource(recognition, aggregator, ref frameSize);
#endif
                if (imageSource != null)
                {
                    cam.SaveImageToJpeg();

                    foreach (var fileName in cam.PathFrames)
                    {
                        bytesImage = GetBytesFromFrame(fileName, frameSize);

                        if (bytesImage == null)
                        {
                            continue;
                        }

                        var imageFrame = new ImageDataFrame(bytesImage);
                        ChahgeStatusRecognition($"Загрузка изображения для \"{cam.Name}\".");
#if !DEBUG
                        recognition.Process(imageSource, imageFrame.ToJson());
#endif
                    }

                    ChahgeStatusRecognition("");
                }
            }
            catch (Exception ex)
            {
                MessageToForm(ex.Message);
            }
        }

        private void GetAndParsingResult()
        {
            ChahgeStatusRecognition("Получение результата распознавания.");
            bool resultAggregatorProcess = true;
            var eventAgr = new AggregatorEvent(AggregatorEventType.OBJECT_ENDING_POINT, new TimeSpec());

#if DEBUG
            System.Threading.Thread.Sleep(500);
#else
            resultAggregatorProcess = recognition.Process(aggregator, eventAgr.ToJson());
#endif
            if (resultAggregatorProcess)
            {
#if DEBUG
                var newRec = new RecognitionRow { Date = DateTime.Now, Number = "567567567", Confidence = Convert.ToDecimal(1) };
                ResultIsRecogniotion( new Result { TypeOfNumber = RecognizedType.FULL_RECOGNIZED, Number = newRec.Number, Confidence = Convert.ToDouble(newRec.Confidence) }, "");
                SQLManager.RecognitionData.InsertRecognition(newRec);
#else
                var result = recognition.GetResult(aggregator);
                var exportResult = ObjectToJson.ToObject<ExportResult>(result);

                if (exportResult.Results.Count > 0)
                {
                    foreach (var res in exportResult.Results)
                    {
                        if (res.TypeOfNumber == RecognizedType.FULL_RECOGNIZED
                            && !String.IsNullOrWhiteSpace(res.Number) && res.Number.Length == 8)
                        {
                            string number = res.Number;

                            if ((number[0] == '5' || number[0] == '6')
                                && number[1] != '9')
                            {
                                try
                                {
                                    SQLManager.RecognitionData.InsertRecognition(new RecognitionRow { Date = DateTime.Now, Number = res.Number, Confidence = Convert.ToDecimal(res.Confidence) });
                                }
                                catch (Exception ex)
                                {
                                    DisplayMessage(ex.Message);
                                }

                                ResultIsRecogniotion(res, result);
                            }
                        }
                    }
                }
#endif
            }
        }

        private byte[] GetBytesFromFrame(string fileName, FrameSize frameSize)
        {
            byte[] bytesImage;

            try
            {
                System.Drawing.Image image = System.Drawing.Image.FromFile(fileName);

                if (image.Height * image.Width > FrameSize.MaxPixcel)
                {
                    var newImage = image.GetThumbnailImage(frameSize.Width, frameSize.Height, null, IntPtr.Zero);
                    image.Dispose();
                    newImage.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    image = System.Drawing.Image.FromFile(fileName);
                }

                image.Dispose();
                bytesImage = File.ReadAllBytes(fileName);

            }
            catch (Exception ex)
            {
                MessageToForm("Не удалось произвести анализ изображения. " + ex.Message);
                return null;
            }
            return bytesImage;
        }

        #region Старая версия анализа. Позже можно будет удалить
        private bool FrameAnalysis()
        {
            if (aggregator != null)
            {
                UpdateAggregator();
                foreach (var cam in Cameras)
                {
                    var fileName = $"{PathToFrame}{cam.Name}.jpg";
                    FrameSize frameSize;
                    byte[] bytesImage;

                    try
                    {
                        System.Drawing.Image image = System.Drawing.Image.FromFile(fileName);

                        if (image.Height * image.Width > FrameSize.MaxPixcel)
                        {
                            var newImage = image.GetThumbnailImage(1600, 900, null, IntPtr.Zero);
                            image.Dispose();
                            newImage.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                            image = System.Drawing.Image.FromFile(fileName);
                        }

                        frameSize = new FrameSize { Height = image.Height, Width = image.Width };
                        image.Dispose();
                        bytesImage = File.ReadAllBytes(fileName);

                    }
                    catch (Exception ex)
                    {
                        MessageToForm("Не удалось произвести анализ изображения. " + ex.Message);
                        return false;
                    }

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
                        RecognitionSetup = new RecognitionSetup { TypicalCharHeightSize = (int)(frameSize.Height * 0.15) }
                    };

                    ChahgeStatusRecognition($"Загрузка изображения для \"{cam.Name}\".");
#if DEBUG
                    var imageSource = new DllHandle(LibraryType.WAGON);
#else
                    var imageSource = recognition.AddImageSource(aggregator, imageConfig, $"--name {cam.Name}");
#endif
                    if (imageSource == null)
                    {
                        return false;
                    }

                    var imageFrame = new ImageDataFrame(bytesImage);
                    bool resultImageProcess = true;
#if !DEBUG
                    resultImageProcess = recognition.Process(imageSource, imageFrame.ToJson());
#endif
                    if (resultImageProcess)
                    {
                        var eventAgr = new AggregatorEvent(AggregatorEventType.OBJECT_ENDING_POINT, new TimeSpec());
                        bool resultAggregatorProcess = true;
                        ChahgeStatusRecognition($"Получение результата распознавания с \"{cam.Name}\".");
#if DEBUG
                        System.Threading.Thread.Sleep(500);
#else
                        resultAggregatorProcess = recognition.Process(aggregator, eventAgr.ToJson());
#endif

                        if (resultAggregatorProcess)
                        {
#if DEBUG
                            ResultIsRecogniotion(new Result { TypeOfNumber = RecognizedType.FULL_RECOGNIZED, Number = "12345678", Confidence = 1 }, "");
#else
                            var result = recognition.GetResult(aggregator);
                            ResultIsRecogniotion(ObjectToJson.ToObject<ExportResult>(result).Results.First(), result);
#endif
                        }
                    }
                }
            }
            ChahgeStatusRecognition("");
            return true;
        }
        #endregion

        #endregion

        #region CameraLibrary
        public bool InitializeCameraLibrary()
        {
            var settingCam = SettingSerializer.Deserializer<SettingCameras>(SettingCameras.FileName);

            if (settingCam == null)
            {
                MessageToForm("Файл с настройками отсутствует - необходимо провести первичные настройки камер.");
                return false;
            }

            if (!IsInitCamera)
            {
                camera = new HikvisionCamera();
#if DEBUG
                IsInitCamera = true;
#else
                IsInitCamera = camera.Initialisation();
#endif
                if (IsInitCamera)
                {
                    foreach (var cam in settingCam.Cameras.Where(w => w.IsUsed))
                    {
                        Cameras.Add(new Camera(camera, cam));
                    }

                    if (Cameras.Count == 0)
                    {
                        MessageToForm("Камеры для распознавания отсутствуют.");
                        return false;
                    }

                    camera.MessageForUser += MessageToForm;
                }
            }
            return IsInitCamera;
        }

        public void FreeCameraLibrary()
        {
            if (IsInitCamera)
            {
#if !DEBUG
                camera.Cleanup();
#endif
                Cameras.Clear();
                IsInitCamera = false;
            }
        }

        public bool LoginsToCams()
        {
            if (IsInitCamera)
            {
                foreach (var cam in Cameras)
                {
                    if (!cam.Login()) return false;
                }

                return true;
            }
            return false;
        }

        public void LogoutToCams()
        {
            if (IsInitCamera)
            {
                Cameras.ForEach(f => f.Logout());
            }
        }

        public bool StartRealPlay(IntPtr videoResource1, IntPtr videoResource2, IntPtr videoResource3, IntPtr videoResource4)
        {
            if (IsInitCamera)
            {
                var resorces = new IntPtr[4] { videoResource1, videoResource2, videoResource3, videoResource4 };

                for (int i = 0; i < Cameras.Count; i++)
                {
                    Cameras[i].StartRealPlay(resorces[i]);
                }
                return Cameras.Where(w => !w.IsLogin || !w.IsRunVideo).Count() == 0;
            }
            return false;
        }

        public void StopRealPlay()
        {
            if (IsInitCamera)
            {
                Cameras.ForEach(f => f.StopRealPlay());
            }
        }

        public bool CreateFrame(string fileName1 = null, string fileName2 = null, string fileName3 = null, string fileName4 = null)
        {
            if (IsInitCamera)
            {
                ChahgeStatusRecognition("Получение изображений для распознавания.");
#if DEBUG
                System.Threading.Thread.Sleep(500);
#endif
                var resorces = new string[4] { fileName1, fileName2, fileName3, fileName4 };

                for (int i = 0; i < Cameras.Count; i++)
                {
                    if (!Cameras[i].SaveImageToJpeg(resorces[i]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion

        private void MessageFromRecogntion(string message, ErrorReportList reportList)
        {
            int iterator = 1;
            StringBuilder text = new StringBuilder();

            text.AppendLine($"{message} Количество ошибок: {reportList.Errors.Count}");

            foreach (var error in reportList.Errors)
            {
                text.AppendFormat("  \t{0}. Код ошибки: {1}. Сообщение: {2}", iterator++, error.ErrorCode, error.ErrorMessage);
            }
            MessageToForm(text.ToString());
        }

        private void MessageToForm(string message)
        {
            DisplayMessage(message);
        }
    }
}
