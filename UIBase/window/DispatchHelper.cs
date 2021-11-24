using System;
using System.Windows;
using System.Windows.Interop;

namespace UIBase.window
{
    public static class DispatchHelper
    {
        public static void InvokeOnUI(Action action)
        {
            Application.Current.Dispatcher.Invoke(action);
        }

        public static void InvokeOnUIAsync(Action action)
        {
            Application.Current.Dispatcher.InvokeAsync(action);
        }

        public static long WindowToLong(Window wnd)
        {
            try
            {
                var interopOwner = new System.Windows.Interop.WindowInteropHelper(wnd);
                return interopOwner.Handle.ToInt64();
            }
            catch
            {
                return 0;
            }
        }

        public static Window? LongToWindow(long value)
        {
            try
            {
                if (value == 0)
                    return null;

                var hWndSource = HwndSource.FromHwnd(new IntPtr(value));
                return hWndSource?.RootVisual as Window;
            }
            catch
            {
                return null;
            }
        }

        public static bool CheckMainAccess()
        {
            try
            {
                return Application.Current.Dispatcher.CheckAccess();
            }
            catch
            {
                return false;
            }
        }
    }
}
