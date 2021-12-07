using Reykjavik.view_models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Diagnostics;

namespace Reykjavik.views
{
    /// <summary>
    /// HomeView.xaml 的交互逻辑
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
            MainViewModel.Instance.InitSpeedTimer();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            importPopup.IsOpen = false;
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            models.XRayConfigDefine.Outbound? outbound;
            try
            {
                var jsonStr = ImportTextBox.Text;
                outbound = JsonSerializer.Deserialize<models.XRayConfigDefine.Outbound>(jsonStr);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                TipLabel.Content = "配置内容格式错误，无法导入！";
                return;
            }

            if (outbound == null)
            {
                TipLabel.Content = "配置内容格式错误，无法导入！";
                return;
            }

            var errmsg = "";
            var connect = MainViewModel.Instance.OutBoundToConnectVm(outbound, ref errmsg);
            if (string.IsNullOrEmpty(errmsg))
            {
                MainViewModel.Instance.AddNewConnect(connect);
            }
            else
            {
                TipLabel.Content = errmsg;
                return;
            }
        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            importPopup.PlacementTarget = Window.GetWindow(this);
            importPopup.IsOpen = true;
        }
    }
}
