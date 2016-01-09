using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace DLPD.Delegate {
    public class DelegateControls {
        protected Control _control;
        public DelegateControls() {
        }

        public DelegateControls(Control control) {
            this._control = control;
        }        
        /// <summary>
        /// 代理函数
        /// </summary>
        /// <param name="value">传值</param>
        protected delegate void outputDelegate(object value);
        /// <summary>
        /// 设置控件是否显示
        /// </summary>
        /// <param name="value">Visibility.Hidden||Visibility.Visable</param>
        public void setVisibility(Visibility value) {
            this._control.Dispatcher.Invoke(new outputDelegate(setVisibilityAction), value);
        }

        private void setVisibilityAction(object visibility) {
            this._control.Visibility = (Visibility)visibility;
        }
    }
    /// <summary>
    /// 代理LABEL
    /// </summary>
    public class DelegateLabel : DelegateControls {
        public DelegateLabel(Control control) {
            this._control = (Label)control;
        }

        //private delegate void outputDelegate(object value);
        /// <summary>
        /// 设置LABEL显示内容
        /// </summary>
        /// <param name="value">显示内容</param>
        public void setContent(string value) {
            this._control.Dispatcher.Invoke(new outputDelegate(setContentAction), value);
        }

        private void setContentAction(object content) {
            ((Label)this._control).Content = content.ToString();
        }

        //public void setVisibility(Visibility value) {
        //    this._control.Dispatcher.Invoke(new outputDelegate(setVisibilityAction), value);
        //}

        //private void setVisibilityAction(object visibility) {
        //    this._control.Visibility = (Visibility)visibility;
        //}
    }
    /// <summary>
    /// DataGrid代理
    /// </summary>
    public class DelegateDataGrid : DelegateControls {
        //private DataGrid _dataGrid;

        public DelegateDataGrid(Control control) {
            this._control = (DataGrid)control;
        }
        /// <summary>
        /// 设置数据源
        /// </summary>
        /// <param name="data">数据源</param>
        public void setData(DataTable data) {
            this._control.Dispatcher.Invoke(new outputDelegate(setDataAction), data);
        }
        /// <summary>
        /// 数据绑定控件
        /// </summary>
        /// <param name="data">数据源</param>
        private void setDataAction(object data) {
            ((DataGrid)this._control).ItemsSource = ((DataTable)data).DefaultView;
        }
    }

    public class DelegateProgressBar : DelegateControls {
        public DelegateProgressBar(Control control) {
            this._control = (ProgressBar)control;
        }

        public void setValue(double value) {
            this._control.Dispatcher.Invoke(new outputDelegate(setValueAction), value);
        }

        private void setValueAction(object value) {
            ((ProgressBar)this._control).Value = (double)value;
        }
    }
}


