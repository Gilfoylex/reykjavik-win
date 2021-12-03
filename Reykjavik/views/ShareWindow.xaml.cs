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
using System.Windows.Shapes;

namespace Reykjavik.views
{
    /// <summary>
    /// ShareWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ShareWindow : UIBase.window.BaseWindow
    {
        public ShareWindow()
        {
            InitializeComponent();
        }

        public void SetShareContent(string content)
        {
            ShareText.Text = content;
        }

        private void TextButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, ShareText.Text);
            TipLabel.Content = "成功复制到剪贴板";
        }
    }
}
