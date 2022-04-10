using System;
using System.Runtime.InteropServices;

namespace HikvisionLibrary
{
    /// <summary>
    /// Базовый класс с функциями для работы с библиотеками Hikvision.
    /// </summary>
    internal class BaseDll
    {
        private const string libraryNetSDKName = @"\Drivers\HCNetSDK.dll";

        /// <summary>
        /// Инициализация библиотеки.
        /// </summary>
        /// <returns></returns>
        [DllImport(libraryNetSDKName)]
        public static extern bool NET_DVR_Init();

        /// <summary>
        /// Отключение от библиотеки.
        /// </summary>
        /// <returns></returns>
        [DllImport(libraryNetSDKName)]
        public static extern bool NET_DVR_Cleanup();

        /// <summary>
        /// Вход пользователя для устройства.
        /// </summary>
        /// <param name="sDVRIP">IP-адрес или статическое доменное имя устройства, количество символов должно быть не более 128.</param>
        /// <param name="wDVRPort">Порт №. устройства.</param>
        /// <param name="sUserName">Имя пользователя.</param>
        /// <param name="sPassword">Пароль.</param>
        /// <param name="lpDeviceInfo">Информация об устройстве.</param>
        /// <returns>Возвращает -1, если вход не удался, а другое значение - это значение возвращенного идентификатора пользователя. 
        /// Идентификатор пользователя является уникальным, и следующие операции должны осуществляться через этот идентификатор.</returns>
        [DllImport(libraryNetSDKName)]
        public static extern int NET_DVR_Login_V30(string sDVRIP, Int32 wDVRPort, string sUserName, string sPassword, ref DeviceInfo lpDeviceInfo);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DllImport(libraryNetSDKName)]
        public static extern uint NET_DVR_GetLastError();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iUserID"></param>
        /// <returns></returns>
        [DllImport(libraryNetSDKName)]
        public static extern bool NET_DVR_Logout(int iUserID);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iUserID"></param>
        /// <param name="lpPreviewInfo"></param>
        /// <param name="fRealDataCallBack_V30"></param>
        /// <param name="pUser"></param>
        /// <returns></returns>
        [DllImport(libraryNetSDKName)]
        public static extern int NET_DVR_RealPlay_V40(int iUserID, ref PreviewInfo lpPreviewInfo, HikvisionCamera.REALDATACALLBACK fRealDataCallBack_V30, IntPtr pUser);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iRealHandle"></param>
        /// <returns></returns>
        [DllImport(libraryNetSDKName)]
        public static extern bool NET_DVR_StopRealPlay(int iRealHandle);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <param name="sPicFileName"></param>
        /// <returns></returns>
        [DllImport(libraryNetSDKName)]
        public static extern bool NET_DVR_CapturePicture(int lRealHandle, string sPicFileName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="lpJpegPara"></param>
        /// <param name="sPicFileName"></param>
        /// <returns></returns>
        [DllImport(libraryNetSDKName)]
        public static extern bool NET_DVR_CaptureJPEGPicture(int lUserID, int lChannel, ref JpegParameters lpJpegPara, string sPicFileName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <returns></returns>
        [DllImport(libraryNetSDKName)]
        public static extern bool NET_DVR_MakeKeyFrame(int lUserID, int lChannel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <returns></returns>
        [DllImport(libraryNetSDKName)]
        public static extern bool NET_DVR_MakeKeyFrameSub(int lUserID, int lChannel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <param name="sFileName"></param>
        /// <returns></returns>
        [DllImport(libraryNetSDKName)]
        public static extern bool NET_DVR_SaveRealData(int lRealHandle, string sFileName);

        [DllImport(libraryNetSDKName)]
        public static extern bool NET_DVR_StopSaveRealData(int lRealHandle);
    }
}
