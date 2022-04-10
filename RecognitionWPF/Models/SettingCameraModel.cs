using System;
using System.Collections.Generic;

namespace RecognitionWPF.Models
{
    public class SettingCameraModel
    {
        public SettingCameras Setting { get; private set; }

        public void LoadSetting()
        {
            Setting = SettingSerializer.Deserializer<SettingCameras>(SettingCameras.FileName) ?? SettingCameras.DefaultValues();
        }

        public void SaveSetting()
        {
            CheckParams();
            SettingSerializer.Serializer(SettingCameras.FileName, Setting);
        }

        private void CheckParams()
        {
            if (Setting.IsUseMainPort.IsChecked)
            {
                Setting.Cameras.ForEach(cam => cam.Port = Setting.IsUseMainPort.Value);
            }
            if (Setting.IsUseMainLogin.IsChecked)
            {
                Setting.Cameras.ForEach(cam => cam.Login = Setting.IsUseMainLogin.Value);
            }
            if (Setting.IsUseMainPassword.IsChecked)
            {
                Setting.Cameras.ForEach(cam => cam.Password = Setting.IsUseMainPassword.Value);
            }
        }
    }
}
