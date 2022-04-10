using System;
using System.ComponentModel;
using System.Windows.Input;
using RecognitionWPF.Command;
using RecognitionWPF.Models;

namespace RecognitionWPF.ViewModels
{
    public class RecognitionSettingViewModel : INotifyPropertyChanged
    {
        public int MinFrameCount { get; set; } = 1;
        public int MaxFrameCount { get; set; } = 10;
        public int MinTimeBetweenFrame { get; set; } = 50;
        public int MinHeigthWordPercent { get; set; } = 5;
        public int MaxHeigthWordPercent { get; set; } = 95;
        readonly RecognitionSettingModel model;

        public RecognitionSettingViewModel()
        {
            model = new RecognitionSettingModel();
            model.LoadSetting();
        }

        /// <summary>
        /// Использовать ли единое количество кадров при распознавании.
        /// </summary>
        public bool IsUseMainCameraFrameCount
        {
            get => model.Setting.IsUseMainCameraFrameCount.IsChecked;
            set
            {
                model.Setting.IsUseMainCameraFrameCount.IsChecked = value;
                OnPropertyChanged(nameof(IsUseMainCameraFrameCount));
            }
        }

        /// <summary>
        /// Использовать ли единый временной интервал между получением кадров.
        /// </summary>
        public bool IsUseMainTimeBetweenFrame
        {
            get => model.Setting.IsUseMainTimeBetweenFrame.IsChecked;
            set
            {
                model.Setting.IsUseMainTimeBetweenFrame.IsChecked = value;
                OnPropertyChanged(nameof(IsUseMainTimeBetweenFrame));
            }
        }

        /// <summary>
        /// Использовать ли единую среднюю высоту символа при распознавании.
        /// </summary>
        public bool IsUseMainHeigthWordPercent
        {
            get => model.Setting.IsUseMainHeigthWordPercent.IsChecked;
            set
            {
                model.Setting.IsUseMainHeigthWordPercent.IsChecked = value;
                OnPropertyChanged(nameof(IsUseMainHeigthWordPercent));
            }
        }

        /// <summary>
        /// Единое количество кадров при распознавании.
        /// </summary>
        public int MainCameraFrameCount
        {
            get => Convert.ToInt32(model.Setting.IsUseMainCameraFrameCount.Value);
            set
            {
                model.Setting.IsUseMainCameraFrameCount.Value = CheckFrameCount(value).ToString();
                OnPropertyChanged(nameof(MainCameraFrameCount));
            }
        }

        /// <summary>
        /// Единый временной интервал между получением кадров (в мс).
        /// </summary>
        public int MainTimeBetweenFrame
        {
            get => Convert.ToInt32(model.Setting.IsUseMainTimeBetweenFrame.Value);
            set
            {
                model.Setting.IsUseMainTimeBetweenFrame.Value = CheckTimeBetweenFrame(value).ToString();
                OnPropertyChanged(nameof(MainTimeBetweenFrame));
            }
        }

        /// <summary>
        /// Единая средняя высота символа при распознавании (в процентном соотношении от высоты кадра).
        /// </summary>
        public int MainHeigthWordPercent
        {
            get => Convert.ToInt32(model.Setting.IsUseMainHeigthWordPercent.Value);
            set
            {
                model.Setting.IsUseMainHeigthWordPercent.Value = CheckHeigthWordPercent(value).ToString();
                OnPropertyChanged(nameof(MainHeigthWordPercent));
            }
        }

        #region Камера 1
        const int camera1_index = 0;

        /// <summary>
        /// Использовать ли камеру 1.
        /// </summary>
        public bool Camera1IsChecked
        {
            get => model.Setting.Cameras[camera1_index].IsUsed;
        }

        public int Camera1FrameCount
        {
            get => model.Setting.Cameras[camera1_index].Frame.Count;
            set
            {
                model.Setting.Cameras[camera1_index].Frame.Count = CheckFrameCount(value);
                OnPropertyChanged(nameof(Camera1FrameCount));
            }
        }

        public int Camera1TimeBetweenFrame
        {
            get => model.Setting.Cameras[camera1_index].Frame.TimeBetweenFrame;
            set
            {
                model.Setting.Cameras[camera1_index].Frame.TimeBetweenFrame = CheckTimeBetweenFrame(value);
                OnPropertyChanged(nameof(Camera1TimeBetweenFrame));
            }
        }

        public int Camera1HeigthWordPercent
        {
            get => model.Setting.Cameras[camera1_index].Frame.HeigthWordPercent;
            set
            {
                model.Setting.Cameras[camera1_index].Frame.HeigthWordPercent = CheckHeigthWordPercent(value);
                OnPropertyChanged(nameof(Camera1HeigthWordPercent));
            }
        }
        #endregion

        #region Камера 2
        const int camera2_index = 1;

        /// <summary>
        /// Использовать ли камеру 1.
        /// </summary>
        public bool Camera2IsChecked
        {
            get => model.Setting.Cameras[camera2_index].IsUsed;
        }

        public int Camera2FrameCount
        {
            get => model.Setting.Cameras[camera2_index].Frame.Count;
            set
            {
                model.Setting.Cameras[camera2_index].Frame.Count = CheckFrameCount(value);
                OnPropertyChanged(nameof(Camera2FrameCount));
            }
        }

        public int Camera2TimeBetweenFrame
        {
            get => model.Setting.Cameras[camera2_index].Frame.TimeBetweenFrame;
            set
            {
                model.Setting.Cameras[camera2_index].Frame.TimeBetweenFrame = CheckTimeBetweenFrame(value);
                OnPropertyChanged(nameof(Camera2TimeBetweenFrame));
            }
        }

        public int Camera2HeigthWordPercent
        {
            get => model.Setting.Cameras[camera2_index].Frame.HeigthWordPercent;
            set
            {
                model.Setting.Cameras[camera2_index].Frame.HeigthWordPercent = CheckHeigthWordPercent(value);
                OnPropertyChanged(nameof(Camera2HeigthWordPercent));
            }
        }
        #endregion

        #region Камера 3
        const int camera3_index = 2;

        /// <summary>
        /// Использовать ли камеру 1.
        /// </summary>
        public bool Camera3IsChecked
        {
            get => model.Setting.Cameras[camera3_index].IsUsed;
        }

        public int Camera3FrameCount
        {
            get => model.Setting.Cameras[camera3_index].Frame.Count;
            set
            {
                model.Setting.Cameras[camera3_index].Frame.Count = CheckFrameCount(value);
                OnPropertyChanged(nameof(Camera3FrameCount));
            }
        }

        public int Camera3TimeBetweenFrame
        {
            get => model.Setting.Cameras[camera3_index].Frame.TimeBetweenFrame;
            set
            {
                model.Setting.Cameras[camera3_index].Frame.TimeBetweenFrame = CheckTimeBetweenFrame(value);
                OnPropertyChanged(nameof(Camera3TimeBetweenFrame));
            }
        }

        public int Camera3HeigthWordPercent
        {
            get => model.Setting.Cameras[camera3_index].Frame.HeigthWordPercent;
            set
            {
                model.Setting.Cameras[camera3_index].Frame.HeigthWordPercent = CheckHeigthWordPercent(value);
                OnPropertyChanged(nameof(Camera3HeigthWordPercent));
            }
        }
        #endregion

        #region Камера 4
        const int camera4_index = 3;

        /// <summary>
        /// Использовать ли камеру 4.
        /// </summary>
        public bool Camera4IsChecked
        {
            get => model.Setting.Cameras[camera4_index].IsUsed;
        }

        public int Camera4FrameCount
        {
            get => model.Setting.Cameras[camera4_index].Frame.Count;
            set
            {
                model.Setting.Cameras[camera4_index].Frame.Count = CheckFrameCount(value);
                OnPropertyChanged(nameof(Camera4FrameCount));
            }
        }

        public int Camera4TimeBetweenFrame
        {
            get => model.Setting.Cameras[camera4_index].Frame.TimeBetweenFrame;
            set
            {
                model.Setting.Cameras[camera4_index].Frame.TimeBetweenFrame = CheckTimeBetweenFrame(value);
                OnPropertyChanged(nameof(Camera4TimeBetweenFrame));
            }
        }

        public int Camera4HeigthWordPercent
        {
            get => model.Setting.Cameras[camera4_index].Frame.HeigthWordPercent;
            set
            {
                model.Setting.Cameras[camera4_index].Frame.HeigthWordPercent = CheckHeigthWordPercent(value);
                OnPropertyChanged(nameof(Camera4HeigthWordPercent));
            }
        }
        #endregion

        private int CheckFrameCount(int count)
        {
            if (count < MinFrameCount) return MinFrameCount;
            if (count > MaxFrameCount) return MaxFrameCount;
            return count;
        }

        private int CheckTimeBetweenFrame(int time)
        {
            if (time < MinTimeBetweenFrame) return MinTimeBetweenFrame;
            return time;
        }

        private int CheckHeigthWordPercent(int heigth)
        {
            if (heigth < MinHeigthWordPercent) return MinHeigthWordPercent;
            if (heigth > MaxHeigthWordPercent) return MaxHeigthWordPercent;
            return heigth;
        }

        #region Commands
        private ICommand _saveAndExit;
        public ICommand SaveAndExit
        {
            get
            {
                return _saveAndExit ??
                    (_saveAndExit = new BaseCommand(execute =>
                    {
                        model.SaveSetting();
                    }));
            }
        }
        #endregion

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
