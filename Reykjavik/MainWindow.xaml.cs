using Reykjavik.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            RootGrid.Background = bg;
            TitleBarBg.Background = new SolidColorBrush(Colors.White);
            TitleBarBg.Opacity = 0.6;
            CaptionArea.Children.Add(new TitleView());
        }

        private void MainWindow_DpiChanged(object sender, DpiChangedEventArgs e)
        {
            var x = UIBase.window.DPIHelper.GetDpiFromVisual(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var y = new XrayServer.XrayProcessHelper();
            y.Start();
        }
    }
}
