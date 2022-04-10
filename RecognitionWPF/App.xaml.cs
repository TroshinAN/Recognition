using System;
using System.Diagnostics;
using System.Windows;
using System.Runtime.InteropServices;

namespace RecognitionWPF
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const int SW_SHOWNORMAL = 1;        // Запустить в исходном состоянии
        private const int SW_SHOWMAXIMIZED = 3;     // Запустить в развёрнутом состоянии
        private const int SW_RESTORE = 9;           // Запустить в текущем состоянии

        [DllImport("user32.dll")]
        private static extern int SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        protected override void OnStartup(StartupEventArgs e)
        {
            Process findProcess = null;
            Process current = Process.GetCurrentProcess();

            foreach (var process in Process.GetProcessesByName(current.ProcessName))
            {
                if (process.Id != current.Id)
                {
                    findProcess = process;
                    break;
                }
            }

            if (findProcess != null)
            {
                ShowWindow(findProcess.MainWindowHandle, SW_RESTORE);
                SetForegroundWindow(findProcess.MainWindowHandle);
                Shutdown();
            }

            base.OnStartup(e);
        }
    }
}
