using Reykjavik.views;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Media;
using Reykjavik.models;
using Reykjavik.view_models;

namespace firework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : UIBase.window.BaseWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.SourceInitialized += MainWindow_SourceInitialized;
            
            this.DpiChanged += MainWindow_DpiChanged;
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

        private void MainWindow_DpiChanged(object sender, DpiChangedEventArgs e)
        {
            var x = UIBase.window.DPIHelper.GetDpiFromVisual(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var y = new XrayServer.XRayProcessHelper();
            y.Start();
        }
    }
}
