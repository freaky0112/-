using DLPD.Common;
using DLPD.Config;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DLPD {
    /// <summary>
    /// ZLPD.xaml 的交互逻辑
    /// </summary>
    public partial class ZLPD : Window {
        Project project = new Project();
        public ZLPD() {
            InitializeComponent();
            this.Loaded += ZLPD_Loaded;
        }

        void ZLPD_Loaded(object sender, RoutedEventArgs e) {
            int margin = 10;
            Hashtable hs=ConfigHelper.ZRZLFRead();
            //DotSpatial.Projections.Forms.DoubleBox db = new DotSpatial.Projections.Forms.DoubleBox();
            //grdMain.Children.Add(db);
            foreach(string name in hs.Keys) {
                DockPanel dp = new DockPanel();
                dp.LastChildFill = true;
                dp.Margin=new Thickness(0, margin, 0, 0);
                grdMain.Children.Add(dp);
                Label label = Label_Generator(name, margin);                
                ComboBox cbx = ComboBox_Generator((List<string>)hs[name], margin);
                dp.Children.Add(label);
                dp.RegisterName("lbl" + name, label);
                dp.Children.Add(cbx);
                dp.RegisterName("cbx" + name, cbx);
                margin = margin + 60;
            }
            base.DataContext = project;
            //throw new NotImplementedException();
        }

        Label Label_Generator(string name,int margin) {
            Label label = new Label();
            label.Content = name;
            label.Height = 60;
            label.Width = 200;
            //label.Margin = new Thickness(10, margin, 0, 0);
            label.HorizontalAlignment = HorizontalAlignment.Left;
            label.VerticalAlignment = VerticalAlignment.Top;
            label.HorizontalContentAlignment = HorizontalAlignment.Center;
            label.VerticalContentAlignment = VerticalAlignment.Center;
            label.FontSize = 29.3333;
            //label.BorderThickness = new Thickness(2);
            //label.BorderBrush = Brushes.Black;
            return label;
        }

        ComboBox ComboBox_Generator(List<string> names, int margin) {
            ComboBox cbx = new ComboBox();
            cbx.ItemsSource = names;
            //cbx.Text = cbx.SelectedItem.ToString();
            cbx.Height = 60;
            //cbx.Margin = new Thickness(200, margin, 0, 0);
            //cbx.HorizontalAlignment = HorizontalAlignment.Right;
            cbx.VerticalAlignment = VerticalAlignment.Top;
            cbx.HorizontalContentAlignment = HorizontalAlignment.Center;
            cbx.VerticalContentAlignment = VerticalAlignment.Center;
            cbx.FontSize = 15;
            return cbx;
        }
    }
}
