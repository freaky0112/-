using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using DLPD.Config;
using DLPD.Common;

namespace DLPD {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        List<BaseInfo> bis = ConfigHelper.BaseInfoRead();
        public MainWindow() {
            InitializeComponent();
            //GDZLDJ ds = ConfigHelper.DataBaseRead(2);
            ConfigHelper.WeightRead(true, "55~70");
            this.Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e) {
            dgdBaseInfo.ItemsSource = bis;
        }
    }
}
