using System;

namespace RecognitionWPF.Models
{
    public class RecognitionSettingModel
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
            if (Setting.IsUseMainCameraFrameCount.IsChecked)
            {
                Setting.Cameras.ForEach(cam => cam.Frame.Count = Convert.ToInt32(Setting.IsUseMainCameraFrameCount.Value));
            }
            if (Setting.IsUseMainTimeBetweenFrame.IsChecked)
            {
                Setting.Cameras.ForEach(cam => cam.Frame.TimeBetweenFrame = Convert.ToInt32(Setting.IsUseMainTimeBetweenFrame.Value));
            }
            if (Setting.IsUseMainHeigthWordPercent.IsChecked)
            {
                Setting.Cameras.ForEach(cam => cam.Frame.HeigthWordPercent = Convert.ToInt32(Setting.IsUseMainHeigthWordPercent.Value));
            }
        }
    }
}
