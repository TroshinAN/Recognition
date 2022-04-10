using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using RecognitionWPF.Command;
using RecognitionWPF.Models;
using System.Windows.Forms;
using RecognitionWPF.Views;
using IntLabLibrary;
using System.Windows.Controls;

namespace RecognitionWPF.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly MainWindowModel mainModel;
        /// <summary>
        /// Предоставляет коллекцию информационных сообщений.
        /// </summary>
        public ObservableCollection<String> InfoMessages { get; }
        /// <summary>
        /// Предоставляет коллекцию результатов распознавания.
        /// </summary>
        public ObservableCollection<RecognitionDataGrid> RecognitionResults { get; }

        const string Camera1Name = "Camera1";
        const string Camera2Name = "Camera2";
        const string Camera3Name = "Camera3";
        const string Camera4Name = "Camera4";
        const string BorderCamera1Name = "BorderCamera1";
        const string BorderCamera2Name = "BorderCamera2";
        const string BorderCamera3Name = "BorderCamera3";
        const string BorderCamera4Name = "BorderCamera4";


        private PictureBox camera1;
        /// <summary>
        /// Изображение с камеры 1.
        /// </summary>
        public PictureBox Camera1
        {
            get => camera1;
            set
            {
                camera1 = value;
                OnPropertyChanged(nameof(Camera1));
            }
        }

        private PictureBox camera2;
        /// <summary>
        /// Изображение с камеры 2.
        /// </summary>
        public PictureBox Camera2
        {
            get => camera2;
            set
            {
                camera2 = value;
                OnPropertyChanged(nameof(Camera2));
            }
        }

        private PictureBox camera3;
        /// <summary>
        /// Изображение с камеры 3.
        /// </summary>
        public PictureBox Camera3
        {
            get => camera3;
            set
            {
                camera3 = value;
                OnPropertyChanged(nameof(Camera3));
            }
        }

        private PictureBox camera4;
        /// <summary>
        /// Изображение с камеры 4.
        /// </summary>
        public PictureBox Camera4
        {
            get => camera4;
            set
            {
                camera4 = value;
                OnPropertyChanged(nameof(Camera4));
            }
        }

        private bool isCameraLibraryInit = false;
        /// <summary>
        /// Указывает, инициализирована ли библиотека видеокамеры.
        /// </summary>
        public bool IsCameraLibraryInit
        {
            get => isCameraLibraryInit;
            set
            {
                isCameraLibraryInit = value;
                OnPropertyChanged(nameof(IsCameraLibraryInit));
            }
        }

        private string recognitionStatus = String.Empty;
        /// <summary>
        /// Состояние библиотеки распознавания.
        /// </summary>
        public string RecognitionStatus
        {
            get => recognitionStatus;
            set
            {
                recognitionStatus = value;
                OnPropertyChanged(nameof(RecognitionStatus));
            }
        }

        private bool isRecognitionLibraryInit = false;
        /// <summary>
        /// Указывает, инициализирована ли библиотека распознавания.
        /// </summary>
        public bool IsRecognitionLibraryInit
        {
            get => isRecognitionLibraryInit;
            set
            {
                isRecognitionLibraryInit = value;
                OnPropertyChanged(nameof(IsRecognitionLibraryInit));
            }
        }

        private bool isRecognitionRunTimeFrameStopProcess = false;
        /// <summary>
        /// Указывает, идёт ли процесс завершения распознавания в реальном времени.
        /// </summary>
        public bool IsRecognitionRunTimeFrameStopProcess
        {
            get => isRecognitionRunTimeFrameStopProcess;
            set
            {
                isRecognitionRunTimeFrameStopProcess = value;
                OnPropertyChanged(nameof(IsRecognitionRunTimeFrameStopProcess));
            }
        }

        private bool isRecognitionInitProcess = false;
        /// <summary>
        /// Указывает, идёт ли процесс инициализации библиотеки распознавания.
        /// </summary>
        public bool IsRecognitionInitProcess
        {
            get => isRecognitionInitProcess;
            set
            {
                isRecognitionInitProcess = value;
                OnPropertyChanged(nameof(IsRecognitionInitProcess));
            }
        }

        private bool isRecognitionSingleFrameProcess = false;
        /// <summary>
        /// Указывает, идёт ли процесс распознавания одного кадра.
        /// </summary>
        public bool IsRecognitionSingleFrameProcess
        {
            get => isRecognitionSingleFrameProcess;
            set
            {
                isRecognitionSingleFrameProcess = value;
                OnPropertyChanged(nameof(IsRecognitionSingleFrameProcess));
            }
        }

        private bool isRecognitionRunTimeFrameProcess = false;
        /// <summary>
        /// Указывает, идёт ли процесс распознавания в реальном времени.
        /// </summary>
        public bool IsRecognitionRunTimeFrameProcess
        {
            get => isRecognitionRunTimeFrameProcess;
            set
            {
                isRecognitionRunTimeFrameProcess = value;
                OnPropertyChanged(nameof(IsRecognitionRunTimeFrameProcess));
            }
        }

        private bool isCamerasPlay = false;
        /// <summary>
        /// Указывает, воспроизводится ли изображение с камер в данный момент.
        /// </summary>
        public bool IsCamerasPlay
        {
            get => isCamerasPlay;
            set
            {
                isCamerasPlay = value;
                OnPropertyChanged(nameof(IsCamerasPlay));
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        public MainWindowViewModel()
        {
            mainModel = new MainWindowModel();
            mainModel.InitRecognitionLibCompleted += RecognInitCompleted;
            mainModel.RunTimeFrameAnalysisCompleted += RunTimeFrameAnalysisCompleted;
            mainModel.SingleFrameAnalysisCompleted += () => { IsRecognitionSingleFrameProcess = false; };
            mainModel.ChahgeStatusRecognition += (statusMessage) => { RecognitionStatus = statusMessage; };
            mainModel.DisplayMessage += (message) => { InfoMessages.Add(message); };
            mainModel.ResultIsRecogniotion += GetResultRecognition;

            InfoMessages = new AsyncObservableCollection<string>();
            RecognitionResults = new AsyncObservableCollection<RecognitionDataGrid>();

            App.Current.MainWindow.ContentRendered += MainWindow_ContentRendered;
        }

        private void MainWindow_ContentRendered(object sender, EventArgs e)
        {
            InitCamerasPictureBox();
        }

        private void InitCamerasPictureBox()
        {
            Camera1 = Camera1 ?? App.Current.MainWindow.FindName(Camera1Name) as PictureBox;
            Camera2 = Camera2 ?? App.Current.MainWindow.FindName(Camera2Name) as PictureBox;
            Camera3 = Camera3 ?? App.Current.MainWindow.FindName(Camera3Name) as PictureBox;
            Camera4 = Camera4 ?? App.Current.MainWindow.FindName(Camera4Name) as PictureBox;

            //Camera1.Image = System.Drawing.Image.FromFile("D:\\1.jpg");

            Camera1.Click += CameraClick;
            Camera2.Click += CameraClick;
            Camera3.Click += CameraClick;
            Camera4.Click += CameraClick;

            Camera1.Name = Camera1Name;
            Camera2.Name = Camera2Name;
            Camera3.Name = Camera3Name;
            Camera4.Name = Camera4Name;
        }


        private void CameraClick(object sender, EventArgs e)
        {
            var border1 = App.Current.MainWindow.FindName(BorderCamera1Name) as Grid;
            var border2 = App.Current.MainWindow.FindName(BorderCamera2Name) as Grid;
            var border3 = App.Current.MainWindow.FindName(BorderCamera3Name) as Grid;
            var border4 = App.Current.MainWindow.FindName(BorderCamera4Name) as Grid;
            

            var camera = sender as PictureBox;

            switch (camera.Name)
            {
                case Camera1Name:
                    border1.Visibility = System.Windows.Visibility.Visible;
                    border2.Visibility = System.Windows.Visibility.Collapsed;
                    border3.Visibility = System.Windows.Visibility.Collapsed;
                    border4.Visibility = System.Windows.Visibility.Collapsed;

                    Grid.SetColumn(border1, 0);
                    Grid.SetRow(border1, 0);
                    Grid.SetColumnSpan(border1, 2);
                    Grid.SetRowSpan(border1, 2);
                    break;
                case Camera2Name:
                    border1.Visibility = System.Windows.Visibility.Collapsed;
                    border2.Visibility = System.Windows.Visibility.Visible;
                    border3.Visibility = System.Windows.Visibility.Collapsed;
                    border4.Visibility = System.Windows.Visibility.Collapsed;
                    
                    Grid.SetColumn(border2, 0);
                    Grid.SetRow(border2, 0);
                    Grid.SetColumnSpan(border2, 2);
                    Grid.SetRowSpan(border2, 2);
                    break;
                case Camera3Name:
                    border1.Visibility = System.Windows.Visibility.Collapsed;
                    border2.Visibility = System.Windows.Visibility.Collapsed;
                    border3.Visibility = System.Windows.Visibility.Visible;
                    border4.Visibility = System.Windows.Visibility.Collapsed;

                    Grid.SetColumn(border3, 0);
                    Grid.SetRow(border3, 0);
                    Grid.SetColumnSpan(border3, 2);
                    Grid.SetRowSpan(border3, 2);
                    break;
                case Camera4Name:
                    border1.Visibility = System.Windows.Visibility.Collapsed;
                    border2.Visibility = System.Windows.Visibility.Collapsed;
                    border3.Visibility = System.Windows.Visibility.Collapsed;
                    border4.Visibility = System.Windows.Visibility.Visible;

                    Grid.SetColumn(border4, 0);
                    Grid.SetRow(border4, 0);
                    Grid.SetColumnSpan(border4, 2);
                    Grid.SetRowSpan(border4, 2);
                    break;

                default:
                    break;
            }
        }

        private void GetResultRecognition(Result result, string resStr)
        {
            System.IO.File.AppendAllText("logResult.txt", DateTime.Now.ToString("(dd.MM.yy - hh:mm) ") + resStr);
            if (RecognitionResults.FirstOrDefault(w => w.Number == result.Number) == null)
            {
                RecognitionResults.Add(new RecognitionDataGrid { Time = DateTime.Now, Number = result.Number, Confidence = result.Confidence });
            }
        }

        private void RecognInitCompleted(bool result)
        {
            IsRecognitionInitProcess = false;
            IsRecognitionLibraryInit = result;
        }

        private void RunTimeFrameAnalysisCompleted()
        {
            IsRecognitionRunTimeFrameProcess = false;
            IsRecognitionRunTimeFrameStopProcess = false;
        }

        #region Commands
        private ICommand _initRecognitionLibrary;
        /// <summary>
        /// Команда инициализации библиотеки распознавания.
        /// </summary>
        public ICommand InitRecognitionLibrary
        {
            get
            {
                return _initRecognitionLibrary ??
                    (_initRecognitionLibrary = new BaseCommand(execute =>
                    {
                        IsRecognitionInitProcess = true;
                        if (!IsRecognitionLibraryInit)
                        {
                            mainModel.InitRecognitionLib(IntLabLibrary.LibraryType.WAGON);
                        }
                        else
                        {
                            mainModel.FreeRecognitionLibrary();
                            IsRecognitionLibraryInit = false;
                            IsRecognitionInitProcess = false;
                        }
                    }, canExecute =>
                    {
                        return !IsRecognitionInitProcess
                            && !IsRecognitionRunTimeFrameProcess
                            && !IsRecognitionSingleFrameProcess
                            && IsCameraLibraryInit;
                    }));
            }
        }

        private ICommand _recognitionSingleFrame;
        /// <summary>
        /// Команда распознавания 1 кадра.
        /// </summary>
        public ICommand RecognitionSingleFrame
        {
            get
            {
                return _recognitionSingleFrame ??
                   (_recognitionSingleFrame = new BaseCommand(execute =>
                   {
                       IsRecognitionSingleFrameProcess = true;
                       mainModel.SingleFrameAnalysisStart();
                   }, canExecute =>
                   {
                       return IsRecognitionLibraryInit
                           && !IsRecognitionSingleFrameProcess
                           && !IsRecognitionRunTimeFrameProcess
                           && IsCamerasPlay;
                   }));
            }
        }

        private ICommand _recognitionRunTimeFrame;
        /// <summary>
        /// Команда распознавания в реальном времени.
        /// </summary>
        public ICommand RecognitionRunTimeFrame
        {
            get
            {
                return _recognitionRunTimeFrame ??
                    (_recognitionRunTimeFrame = new BaseCommand(execute =>
                    {
                        if (!IsRecognitionRunTimeFrameProcess)
                        {
                            IsRecognitionRunTimeFrameProcess = true;
                            mainModel.RunTimeFrameAnalysisStart();
                        }
                        else
                        {
                            IsRecognitionRunTimeFrameStopProcess = true;
                            mainModel.RunTimeFrameAnalysisStop();
                        }
                    }, canExecute =>
                    {
                        return IsRecognitionLibraryInit
                            && !IsRecognitionRunTimeFrameStopProcess
                            && !IsRecognitionSingleFrameProcess
                            && IsCamerasPlay;
                    }));
            }
        }

        private ICommand _clearRecognitionDataGrid;
        /// <summary>
        /// Команда очистки результатов распознавания.
        /// </summary>
        public ICommand ClearRecognitionDataGrid
        {
            get
            {
                return _clearRecognitionDataGrid ??
                    (_clearRecognitionDataGrid = new BaseCommand(execute =>
                    {
                        RecognitionResults.Clear();
                    }));
            }
        }

        private ICommand _clearInfoMessages;
        /// <summary>
        /// Команда очистки информационных сообщений.
        /// </summary>
        public ICommand ClearInfoMessages
        {
            get
            {
                return _clearInfoMessages ??
                    (_clearInfoMessages = new BaseCommand(execute =>
                    {
                        InfoMessages.Clear();
                    }));
            }
        }

        private ICommand _initCameraLibrary;
        /// <summary>
        /// Команда инициализации библиотеки видеокамеры.
        /// </summary>
        public ICommand InitCameraLibrary
        {
            get
            {
                return _initCameraLibrary ??
                    (_initCameraLibrary = new BaseCommand(execute =>
                    {
                        if (!IsCameraLibraryInit)
                        {
                            if (mainModel.InitializeCameraLibrary() && mainModel.LoginsToCams())
                            {
                                IsCameraLibraryInit = true;
                                CamerasPlay.Execute(null);
                            }
                            else
                            {
                                mainModel.LogoutToCams();
                                mainModel.FreeCameraLibrary();
                            }
                        }
                        else
                        {
                            CamerasStop.Execute(null);
                            mainModel.LogoutToCams();
                            mainModel.FreeCameraLibrary();
                            IsCameraLibraryInit = false;
                        }
                    }, canExecute =>
                    {
                        return !IsRecognitionRunTimeFrameStopProcess
                            && !IsRecognitionSingleFrameProcess
                            && !IsRecognitionLibraryInit;
                    }));
            }
        }

        private ICommand _camerasPlay;
        /// <summary>
        /// Команда запуска/паузы воспроизведения видео.
        /// </summary>
        public ICommand CamerasPlay
        {
            get
            {
                return _camerasPlay ??
                    (_camerasPlay = new BaseCommand(execute =>
                    {
                        if (!IsCamerasPlay)
                        {
                            Camera1 = Camera1 ?? App.Current.MainWindow.FindName("Camera1") as PictureBox;
                            Camera2 = Camera2 ?? App.Current.MainWindow.FindName("Camera2") as PictureBox;
                            Camera3 = Camera3 ?? App.Current.MainWindow.FindName("Camera3") as PictureBox;
                            Camera4 = Camera4 ?? App.Current.MainWindow.FindName("Camera4") as PictureBox;

                            IsCamerasPlay = mainModel.StartRealPlay(Camera1 != null ? Camera1.Handle : IntPtr.Zero
                                , Camera2 != null ? Camera2.Handle : IntPtr.Zero
                                , Camera3 != null ? Camera3.Handle : IntPtr.Zero
                                , Camera4 != null ? Camera4.Handle : IntPtr.Zero);

                            if (!IsCamerasPlay)
                            {
                                mainModel.StopRealPlay(); ;
                            }
                        }
                        else
                        {
                            mainModel.StopRealPlay();
                            IsCamerasPlay = false;
                        }
                    }, canExecute =>
                    {
                        return IsCameraLibraryInit
                            && !IsRecognitionSingleFrameProcess
                            && !IsRecognitionRunTimeFrameProcess;
                    }));
            }
        }

        private ICommand _camerasStop;
        /// <summary>
        /// Команда остановки воспроизведения видео.
        /// </summary>
        public ICommand CamerasStop
        {
            get
            {
                return _camerasStop ??
                    (_camerasStop = new BaseCommand(execute =>
                    {
                        mainModel.StopRealPlay();
                        IsCamerasPlay = false;

                        Camera1.Invalidate();
                        Camera2.Invalidate();
                        Camera3.Invalidate();
                        Camera4.Invalidate();
                    }, canExecute =>
                    {
                        return IsCamerasPlay
                            && !IsRecognitionSingleFrameProcess
                            && !IsRecognitionRunTimeFrameProcess;
                    }));
            }
        }

        private ICommand _camerasSetting;
        /// <summary>
        /// Команда открытия окна настроек камеры.
        /// </summary>
        public ICommand CamerasSetting
        {
            get
            {
                return _camerasSetting ??
                    (_camerasSetting = new BaseCommand(execute =>
                    {
                        var setting = new CamerasSettingView();

                        setting.ShowDialog();
                    }, canExecute =>
                    {
                        return !IsCameraLibraryInit;
                    }));
            }
        }

        private ICommand _multyCamera;
        /// <summary>
        /// Команда возврата к просмотру всех камер.
        /// </summary>
        public ICommand MultyCamera
        {
            get
            {
                return _multyCamera ??
                    (_multyCamera = new BaseCommand(execute =>
                    {
                        var border1 = App.Current.MainWindow.FindName(BorderCamera1Name) as Grid;
                        var border2 = App.Current.MainWindow.FindName(BorderCamera2Name) as Grid;
                        var border3 = App.Current.MainWindow.FindName(BorderCamera3Name) as Grid;
                        var border4 = App.Current.MainWindow.FindName(BorderCamera4Name) as Grid;

                        border1.Visibility = System.Windows.Visibility.Visible;
                        border2.Visibility = System.Windows.Visibility.Visible;
                        border3.Visibility = System.Windows.Visibility.Visible;
                        border4.Visibility = System.Windows.Visibility.Visible;

                        Grid.SetColumn(border1, 0);
                        Grid.SetRow(border1, 0);
                        Grid.SetColumnSpan(border1, 1);
                        Grid.SetRowSpan(border1, 1);

                        Grid.SetColumn(border2, 1);
                        Grid.SetRow(border2, 0);
                        Grid.SetColumnSpan(border2, 1);
                        Grid.SetRowSpan(border2, 1);

                        Grid.SetColumn(border3, 0);
                        Grid.SetRow(border3, 1);
                        Grid.SetColumnSpan(border3, 1);
                        Grid.SetRowSpan(border3, 1);

                        Grid.SetColumn(border4, 1);
                        Grid.SetRow(border4, 1);
                        Grid.SetColumnSpan(border4, 1);
                        Grid.SetRowSpan(border4, 1);
                    }));
            }
        }

        private ICommand _recognitionSetting;
        /// <summary>
        /// Команда открытия окна настроек камеры.
        /// </summary>
        public ICommand RecognitionSetting
        {
            get
            {
                return _recognitionSetting ??
                    (_recognitionSetting = new BaseCommand(execute =>
                    {
                        var setting = new RecongnitionSettingView();

                        setting.ShowDialog();
                    }, canExecute =>
                    {
                        return !IsRecognitionLibraryInit;
                    }));
            }
        }
        #endregion

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            CommandManager.InvalidateRequerySuggested();
        }
        #endregion
    }
}
