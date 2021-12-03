using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using UIBase.controls;

namespace UIBase.window
{
    public class BaseWindow : Window
    {
        static BaseWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseWindow),
                new FrameworkPropertyMetadata(typeof(BaseWindow)));
        }

        public BaseWindow()
        {
            Loaded += BaseWindow_Loaded;
            StateChanged += BaseWindow_StateChanged;
        }

        private void BaseWindow_StateChanged(object? sender, EventArgs e)
        {
            UpdateMaxBtn();
        }


        public Grid? RootGrid { get; private set; }
        public Grid? TitleBar { get; private set; }
        public Grid? TitleBarBg { get; private set; }
        public Grid? CaptionArea { get; private set; }
        public Button? MinimizeBtn { get; private set; }
        public Grid? MaxRestoreGrid { get; private set; }
        public Button? RestoreBtn { get; private set; }
        public Button? MaximizeBtn { get; private set; }
        public Button? CloseBtn { get; private set; }
        public override void OnApplyTemplate()
        {
            RootGrid = GetRequiredTemplateChild<Grid>("RootGrid");
            MaxRestoreGrid = GetRequiredTemplateChild<Grid>("MaxRestoreGrid");
            TitleBar = GetRequiredTemplateChild<Grid>("TitleBar");
            TitleBarBg = GetRequiredTemplateChild<Grid>("TitleBarBg");
            CaptionArea = GetRequiredTemplateChild<Grid>("CaptionArea");
            MinimizeBtn = GetRequiredTemplateChild<TitleBarButton>("MinimizeBtn");
            RestoreBtn = GetRequiredTemplateChild<TitleBarButton>("RestoreBtn");
            MaximizeBtn = GetRequiredTemplateChild<TitleBarButton>("MaximizeBtn");
            CloseBtn = GetRequiredTemplateChild<TitleBarButton>("CloseBtn");

            MinimizeBtn.Click += MinimizeBtn_Click;
            RestoreBtn.Click += RestoreBtn_Click;
            MaximizeBtn.Click += MaximizeBtn_Click;
            CloseBtn.Click += CloseBtn_Click;
            base.OnApplyTemplate();
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            var handle = new WindowInteropHelper(this).Handle;
            var source = HwndSource.FromHwnd(handle);
            source.AddHook(new HwndSourceHook(WpfHandleWindowMsg));
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property.Name == ResizeModeProperty.Name
                && e.NewValue is ResizeMode resizeMode)
            {
                UpdateMinMaxRestoreBtnsStatus(resizeMode);
            }
        }

        private void UpdateMinMaxRestoreBtnsStatus(ResizeMode resizeMode)
        {
            if (MinimizeBtn == null
                || MaxRestoreGrid == null)
                return;

            if (resizeMode == ResizeMode.NoResize)
            {
                MinimizeBtn.Visibility = Visibility.Collapsed;
                MaxRestoreGrid.Visibility = Visibility.Collapsed;
            }
            else if (resizeMode == ResizeMode.CanMinimize)
            {
                MinimizeBtn.Visibility = Visibility.Visible;
                MaxRestoreGrid.Visibility = Visibility.Collapsed;
            }
            else if (resizeMode == ResizeMode.CanResize)
            {
                MinimizeBtn.Visibility = Visibility.Visible;
                MaxRestoreGrid.Visibility = Visibility.Visible;
            }
            else if (resizeMode == ResizeMode.CanResizeWithGrip)
            {
                MinimizeBtn.Visibility = Visibility.Visible;
                MaxRestoreGrid.Visibility = Visibility.Visible;
            }
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            OnCloseBtn_Click(sender, e);
        }

        protected virtual void OnCloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MaximizeBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }

        private void RestoreBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Normal;
        }

        private void MinimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        public T GetRequiredTemplateChild<T>(string childName) where T : DependencyObject
        {
            return (T)base.GetTemplateChild(childName);
        }

        private void BaseWindow_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateMaxBtn();
            UpdateMinMaxRestoreBtnsStatus(this.ResizeMode);
        }

        private void UpdateMaxBtn()
        {
            if (WindowState == WindowState.Maximized)
            {
                if (RestoreBtn != null) RestoreBtn.Visibility = Visibility.Visible;
                if (MaximizeBtn != null) MaximizeBtn.Visibility = Visibility.Hidden;
            }
            else
            {
                if (RestoreBtn != null) RestoreBtn.Visibility = Visibility.Hidden;
                if (MaximizeBtn != null) MaximizeBtn.Visibility = Visibility.Visible;
            }
        }

        // 自定义消息处理
        protected virtual IntPtr OnWindowsMeessage(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled, ref bool customHandled)
        {
            return IntPtr.Zero;
        }

        private IntPtr WpfHandleWindowMsg(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            var customHandled = false;
            var ret = OnWindowsMeessage((IntPtr)hwnd, msg, wParam, lParam, ref handled, ref customHandled);
            if (customHandled)
            {
                return ret;
            }


            if (msg == Win32ApiDefine.WM_NCHITTEST)
            {
                var dpi = UIBase.window.DPIHelper.GetDpiFromVisual(this);
                var mousePt = GetPoint(lParam);

                var captionAreaRect = GetCapationAreaRect(dpi);

                if (captionAreaRect.Contains(mousePt))
                {
                    handled = true;
                    return new IntPtr((int)Win32ApiDefine.HitTest.HTCAPTION);
                }

                // windows 11 的边缘贴靠还有问题，待研究
                //var closeBtnArea = GetMaxmizeOrRestoreRect(dpi);

                //if (closeBtnArea.Contains(mousePt))
                //{
                //    handled = true;
                //    return new IntPtr((int)Win32ApiDefine.HitTest.HTMAXBUTTON);
                //}

                //handled = true;
                //return new IntPtr((int)Win32ApiDefine.HitTest.HTCLIENT);
            }
            //else if (msg == Win32ApiDefine.WM_NCCALCSIZE)
            //{
            //    handled = true;
            //    return IntPtr.Zero;
            //}
            //else if (msg == Win32ApiDefine.WM_NCPAINT)
            //{
            //    handled = true;
            //    return IntPtr.Zero;
            //}
            //else if (msg == Win32ApiDefine.WM_GETMINMAXINFO)
            //{
            //    WmGetMinMaxInfo(hwnd, lParam);
            //    handled = true;
            //    return IntPtr.Zero;
            //}

            return IntPtr.Zero;
            //return Win32ApiDefine.DefWindowProc(hwnd, (uint)msg, wParam, lParam);
        }

        

        private void WmGetMinMaxInfo(System.IntPtr hwnd, IntPtr lParam)
        {

            Win32ApiDefine.MINMAXINFO mmi = (Win32ApiDefine.MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(Win32ApiDefine.MINMAXINFO));

            var monitor = Win32ApiDefine.MonitorFromWindow(hwnd, Win32ApiDefine.MONITOR_DEFAULTTOPRIMARY);

            if (monitor != System.IntPtr.Zero)
            {

                var monitorInfo = new Win32ApiDefine.MonitorInfo();
                monitorInfo.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(typeof(Win32ApiDefine.MonitorInfo));
                Win32ApiDefine.GetMonitorInfo(monitor, ref monitorInfo);
                Win32ApiDefine.RectStruct rcWorkArea = monitorInfo.rcWork;
                Win32ApiDefine.RectStruct rcMonitorArea = monitorInfo.rcMonitor;
                
                


                mmi.ptMaxPosition.X = rcWorkArea.Left;
                mmi.ptMaxPosition.Y = rcWorkArea.Top;
                mmi.ptMaxSize.X = Math.Abs(rcWorkArea.Right - rcWorkArea.Left);
                mmi.ptMaxSize.Y = Math.Abs(rcWorkArea.Bottom - rcWorkArea.Top);



                //mmi.ptMaxPosition.X = 0;
                //mmi.ptMaxPosition.Y = 0;
                //mmi.ptMaxSize.X = 1000;
                //mmi.ptMaxSize.Y = 1000;
            }

            Marshal.StructureToPtr(mmi, lParam, true);
        }

        private Point GetPoint(IntPtr _xy)
        {
            uint xy = unchecked(IntPtr.Size == 8 ? (uint)_xy.ToInt64() : (uint)_xy.ToInt32());
            int x = unchecked((short)xy);
            int y = unchecked((short)(xy >> 16));
            return new Point(x, y);
        }

        private Rect GetCapationAreaRect(double dpi)
        {
            var titleBarPos = CaptionArea.PointToScreen(new Point(0, 0));
            return new Rect()
            {
                X = titleBarPos.X,
                Y = titleBarPos.Y,
                Width = CaptionArea.ActualWidth * dpi,
                Height = CaptionArea.ActualHeight * dpi
            };
        }

        private Rect GetMaxmizeOrRestoreRect(double dpi)
        {
            var btn = WindowState == WindowState.Maximized ? RestoreBtn : MaximizeBtn;
            var pos = btn.PointToScreen(new Point(0, 0));
            return new Rect()
            {
                X = pos.X,
                Y = pos.Y,
                Width = btn.ActualWidth * dpi,
                Height = btn.ActualHeight * dpi
            };
        }

        private Rect GetCurWindowRect(double dpi)
        {
            return new Rect()
            {
                X = Left,
                Y = Top,
                Width = ActualWidth * dpi,
                Height = ActualHeight * dpi
            };
        }
    }
}
