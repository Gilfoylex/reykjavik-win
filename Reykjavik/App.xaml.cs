using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace firework
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static Mutex _mutex = new Mutex(true, "Reykjvik-d8d0e869-155f-4758-ac50-cc079c6fc4d8");
        App()
        {
            InitializeComponent();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            if (_mutex.WaitOne(TimeSpan.Zero, true))
            {
                base.OnStartup(e);
                var window = new MainWindow();
                Application.Current.MainWindow = window;
                window.Show();
            }
            else
            {
                NativeMethods.PostMessage((IntPtr)NativeMethods.HWND_BROADCAST, NativeMethods.WM_SHOWME, IntPtr.Zero, IntPtr.Zero);
                Environment.Exit(0);
            }
        }
    }

    internal class NativeMethods
    {
        public const int HWND_BROADCAST = 0xffff;
        public static readonly int WM_SHOWME = RegisterWindowMessage("WM_SHOWME");
        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);
    }
}
