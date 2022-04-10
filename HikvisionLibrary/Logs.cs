using System;
using System.IO;

namespace HikvisionLibrary
{
    public static class Logs
    {
        private static readonly object _lockAdmin = new object();
        private static readonly object _lockUser = new object();
        private static readonly string _directoryAdmin = $"\\Logs\\Admin\\{DateTime.Now.ToString("yyyy")}\\{GetMonth(DateTime.Now)}";
        private static readonly string _directoryUser = $"\\Logs\\User\\{DateTime.Now.ToString("yyyy")}\\{GetMonth(DateTime.Now)}";
        private static readonly string _fileNameAdmin = $"{_directoryAdmin}\\{DateTime.Now.ToString("dd - HH-mm-ss")}.txt";
        private static readonly string _fileNameUser = $"{_directoryAdmin}\\{DateTime.Now.ToString("dd - HH-mm-ss")}.txt";

        public static void SaveMessageForAdmin(string message)
        {
            if (!Directory.Exists(_directoryAdmin))
            {
                Directory.CreateDirectory(_directoryAdmin);
            }

            lock (_lockAdmin)
            {
                File.AppendAllText(_fileNameAdmin, $"{DateTime.Now.ToString("HH:mm:ss")}: {message}\r\n");
            }
        }

        public static void SaveMessageForUser(string message)
        {
            if (!Directory.Exists(_directoryUser))
            {
                Directory.CreateDirectory(_directoryUser);
            }

            lock (_lockUser)
            {
                File.AppendAllText(_fileNameUser, $"{DateTime.Now.ToString("HH:mm:ss")}: {message}\r\n");
            }
        }

        private static string GetMonth(DateTime dtNow)
        {
            switch (dtNow.Month)
            {
                case 1: return "01 Январь";
                case 2: return "02 Февраль";
                case 3: return "03 Март";
                case 4: return "04 Апрель";
                case 5: return "05 Май";
                case 6: return "06 Июнь";
                case 7: return "07 Июль";
                case 8: return "08 Август";
                case 9: return "09 Сентябрь";
                case 10: return "10 Октябрь";
                case 11: return "11 Ноябрь";
                case 12: return "12 Декабрь";
                default: return "00 Межпространственное время";
            }
        }
    }
}
