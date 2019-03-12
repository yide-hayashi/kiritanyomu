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
using Microsoft.Win32;

namespace kiritannyomi
{
    /// <summary>
    /// UserControl1.xaml の相互作用ロジック
    /// </summary>
    public partial class settingUC : UserControl
    {
        public settingUC()
        {
            InitializeComponent();
        }

        private void pathdialog_Click(object sender, RoutedEventArgs e)
        {
            ///使わない　遅いから
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.exe";
            if(ofd.ShowDialog()==true)
            {
                path.Text = ofd.FileName;
            }
        }
    }
}
