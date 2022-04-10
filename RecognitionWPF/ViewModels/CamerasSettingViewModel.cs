using System;
using System.Linq;
using System.ComponentModel;
using RecognitionWPF.Models;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Input;
using RecognitionWPF.Command;

namespace RecognitionWPF.ViewModels
{
    public class MultyBoolConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values.Count() == 2 && ((bool)values[0]) && !((bool)values[1]);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    public class CamerasSettingViewModel : INotifyPropertyChanged
    {
        readonly SettingCameraModel model;

        public CamerasSettingViewModel()
        {
            model = new SettingCameraModel();
            model.LoadSetting();
        }

        /// <summary>
        /// Использовать единый порт для камер.
        /// </summary>
        public bool IsUsedMainPort
        {
            get => model.Setting.IsUseMainPort.IsChecked;
            set
            {
                model.Setting.IsUseMainPort.IsChecked = value;
                OnPropertyChanged(nameof(IsUsedMainPort));
            }
        }

        /// <summary>
        /// Использовать единое имя пользователя для камер.
        /// </summary>
        public bool IsUsedMainLogin
        {
            get => model.Setting.IsUseMainLogin.IsChecked;
            set
            {
                model.Setting.IsUseMainLogin.IsChecked = value;
                OnPropertyChanged(nameof(IsUsedMainLogin));
            }
        }

        /// <summary>
        /// Использовать единый пароль для камер.
        /// </summary>
        public bool IsUsedMainPassword
        {
            get => model.Setting.IsUseMainPassword.IsChecked;
            set
            {
                model.Setting.IsUseMainPassword.IsChecked = value;
                OnPropertyChanged(nameof(IsUsedMainPassword));
            }
        }

        /// <summary>
        /// Единый порт для камер.
        /// </summary>
        public string MainPort
        {
            get => model.Setting.IsUseMainPort.Value;
            set
            {
                model.Setting.IsUseMainPort.Value = value;
                OnPropertyChanged(nameof(MainPort));
            }
        }

        /// <summary>
        /// Единый логин для камер.
        /// </summary>
        public string MainLogin
        {
            get => model.Setting.IsUseMainLogin.Value;
            set
            {
                model.Setting.IsUseMainLogin.Value = value;
                OnPropertyChanged(nameof(MainLogin));
            }
        }

        /// <summary>
        /// Единый пароль для камер.
        /// </summary>
        public string MainPassword
        {
            get => model.Setting.IsUseMainPassword.Value;
            set
            {
                model.Setting.IsUseMainPassword.Value = value;
                OnPropertyChanged(nameof(MainPassword));
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
            set
            {
                model.Setting.Cameras[camera1_index].IsUsed = value;
                OnPropertyChanged(nameof(Camera1IsChecked));
            }
        }

        /// <summary>
        /// Адрес подключения к камере 1.
        /// </summary>
        public string Camera1Address
        {
            get => model.Setting.Cameras[camera1_index].Address;
            set
            {
                model.Setting.Cameras[camera1_index].Address = value;
                OnPropertyChanged(nameof(Camera1Address));
            }
        }

        /// <summary>
        /// Порт подключения камеры 1.
        /// </summary>
        public string Camera1Port
        {
            get => model.Setting.Cameras[camera1_index].Port;
            set
            {
                model.Setting.Cameras[camera1_index].Port = value;
                OnPropertyChanged(nameof(Camera1Port));
            }
        }

        /// <summary>
        /// Логин подключения к камере 1.
        /// </summary>
        public string Camera1Login
        {
            get => model.Setting.Cameras[camera1_index].Login;
            set
            {
                model.Setting.Cameras[camera1_index].Login = value;
                OnPropertyChanged(nameof(Camera1Login));
            }
        }

        /// <summary>
        /// Пароль подключения к камере 1.
        /// </summary>
        public string Camera1Password
        {
            get => model.Setting.Cameras[camera1_index].Password;
            set
            {
                model.Setting.Cameras[camera1_index].Password = value;
                OnPropertyChanged(nameof(Camera1Password));
            }
        }
        #endregion

        #region Камера 2
        const int camera2_index = 1;
        /// <summary>
        /// Использовать ли камеру 2.
        /// </summary>
        public bool Camera2IsChecked
        {
            get => model.Setting.Cameras[camera2_index].IsUsed;
            set
            {
                model.Setting.Cameras[camera2_index].IsUsed = value;
                OnPropertyChanged(nameof(Camera2IsChecked));
            }
        }

        /// <summary>
        /// Адрес подключения к камере 2.
        /// </summary>
        public string Camera2Address
        {
            get => model.Setting.Cameras[camera2_index].Address;
            set
            {
                model.Setting.Cameras[camera2_index].Address = value;
                OnPropertyChanged(nameof(Camera2Address));
            }
        }

        /// <summary>
        /// Порт подключения камеры 2.
        /// </summary>
        public string Camera2Port
        {
            get => model.Setting.Cameras[camera2_index].Port;
            set
            {
                model.Setting.Cameras[camera2_index].Port = value;
                OnPropertyChanged(nameof(Camera2Port));
            }
        }

        /// <summary>
        /// Логин подключения к камере 2.
        /// </summary>
        public string Camera2Login
        {
            get => model.Setting.Cameras[camera2_index].Login;
            set
            {
                model.Setting.Cameras[camera2_index].Login = value;
                OnPropertyChanged(nameof(Camera2Login));
            }
        }

        /// <summary>
        /// Пароль подключения к камере 2.
        /// </summary>
        public string Camera2Password
        {
            get => model.Setting.Cameras[camera2_index].Password;
            set
            {
                model.Setting.Cameras[camera2_index].Password = value;
                OnPropertyChanged(nameof(Camera2Password));
            }
        }
        #endregion

        #region Камера 3
        const int camera3_index = 2;
        /// <summary>
        /// Использовать ли камеру 3.
        /// </summary>
        public bool Camera3IsChecked
        {
            get => model.Setting.Cameras[camera3_index].IsUsed;
            set
            {
                model.Setting.Cameras[camera3_index].IsUsed = value;
                OnPropertyChanged(nameof(Camera3IsChecked));
            }
        }

        /// <summary>
        /// Адрес подключения к камере 3.
        /// </summary>
        public string Camera3Address
        {
            get => model.Setting.Cameras[camera3_index].Address;
            set
            {
                model.Setting.Cameras[camera3_index].Address = value;
                OnPropertyChanged(nameof(Camera3Address));
            }
        }

        /// <summary>
        /// Порт подключения камеры 3.
        /// </summary>
        public string Camera3Port
        {
            get => model.Setting.Cameras[camera3_index].Port;
            set
            {
                model.Setting.Cameras[camera3_index].Port = value;
                OnPropertyChanged(nameof(Camera3Port));
            }
        }

        /// <summary>
        /// Логин подключения к камере 3.
        /// </summary>
        public string Camera3Login
        {
            get => model.Setting.Cameras[camera3_index].Login;
            set
            {
                model.Setting.Cameras[camera3_index].Login = value;
                OnPropertyChanged(nameof(Camera3Login));
            }
        }

        /// <summary>
        /// Пароль подключения к камере 3.
        /// </summary>
        public string Camera3Password
        {
            get => model.Setting.Cameras[camera3_index].Password;
            set
            {
                model.Setting.Cameras[camera3_index].Password = value;
                OnPropertyChanged(nameof(Camera3Password));
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
            set
            {
                model.Setting.Cameras[camera4_index].IsUsed = value;
                OnPropertyChanged(nameof(Camera4IsChecked));
            }
        }

        /// <summary>
        /// Адрес подключения к камере 4.
        /// </summary>
        public string Camera4Address
        {
            get => model.Setting.Cameras[camera4_index].Address;
            set
            {
                model.Setting.Cameras[camera4_index].Address = value;
                OnPropertyChanged(nameof(Camera4Address));
            }
        }

        /// <summary>
        /// Порт подключения камеры 4.
        /// </summary>
        public string Camera4Port
        {
            get => model.Setting.Cameras[camera4_index].Port;
            set
            {
                model.Setting.Cameras[camera4_index].Port = value;
                OnPropertyChanged(nameof(Camera4Port));
            }
        }

        /// <summary>
        /// Логин подключения к камере 4.
        /// </summary>
        public string Camera4Login
        {
            get => model.Setting.Cameras[camera4_index].Login;
            set
            {
                model.Setting.Cameras[camera4_index].Login = value;
                OnPropertyChanged(nameof(Camera4Login));
            }
        }

        /// <summary>
        /// Пароль подключения к камере 4.
        /// </summary>
        public string Camera4Password
        {
            get => model.Setting.Cameras[camera4_index].Password;
            set
            {
                model.Setting.Cameras[camera4_index].Password = value;
                OnPropertyChanged(nameof(Camera4Password));
            }
        }
        #endregion

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
