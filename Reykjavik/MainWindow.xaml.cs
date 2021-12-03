using Reykjavik.views;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Media;
using Reykjavik.models;
using Reykjavik.view_models;
using System.Windows.Forms;

namespace firework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : UIBase.window.BaseWindow
    {
        //  托盘
        private NotifyIcon m_notifyIcon = null;
        public MainWindow()
        {
            InitializeComponent();
            this.SourceInitialized += MainWindow_SourceInitialized;

            this.DpiChanged += MainWindow_DpiChanged;
            Loaded += MainWindow_Loaded;
            Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MainViewModel.Instance.ProxySetted)
                MainViewModel.Instance.ChangeProxy(false); // 程序退出的时候关闭代理

            MainViewModel.Instance.StopXRay();

            m_notifyIcon?.Dispose();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CreateTrayIcon();
        }

        private void MainWindow_SourceInitialized(object? sender, EventArgs e)
        {
            var bg = new ImageBrush();
            bg.ImageSource = (ImageSource)FindResource("IconDrawingImage");
            if (RootGrid != null) RootGrid.Background = bg;
            if (TitleBarBg != null)
            {
                TitleBarBg.Background = new SolidColorBrush(Colors.White);
                TitleBarBg.Opacity = 0.6;
            }

            CaptionArea?.Children.Add(new TitleView());
        }

        protected override IntPtr OnWindowsMeessage(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled, ref bool customHandled)
        {
            if (msg == NativeMethods.WM_SHOWME)
            {
                customHandled = true;
                Show();
                Activate();
            }

            return IntPtr.Zero;
        }

        private void MainWindow_DpiChanged(object sender, System.Windows.DpiChangedEventArgs e)
        {
            var x = UIBase.window.DPIHelper.GetDpiFromVisual(this);
        }

        // 创建托盘图标
        private void CreateTrayIcon()
        {
            try
            {
                if (m_notifyIcon != null)
                    return;
                ContextMenuStrip menu = new ContextMenuStrip();
                ToolStripMenuItem showItem = new ToolStripMenuItem("显示");
                showItem.Click += ShowItem_Click;
                menu.Items.Add(showItem);

                ToolStripMenuItem exitItem = new ToolStripMenuItem("退出");
                exitItem.Click += ExitItem_Click;
                menu.Items.Add(exitItem);
                m_notifyIcon = new NotifyIcon();
                m_notifyIcon.Text = "Reykjavik";
                m_notifyIcon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Windows.Forms.Application.ExecutablePath);
                m_notifyIcon.Visible = true;
                m_notifyIcon.ContextMenuStrip = menu;
                m_notifyIcon.MouseClick += M_notifyIcon_MouseClick; ;
            }
            catch (Exception) { }
        }

        protected override void OnCloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void M_notifyIcon_MouseClick(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Show();
                Activate();
            }
        }

        private void ExitItem_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void ShowItem_Click(object? sender, EventArgs e)
        {
            Show();
            Activate();
        }
    }
}
