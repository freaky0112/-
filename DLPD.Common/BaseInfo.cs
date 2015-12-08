using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DLPD.Common {
    public class BaseInfo : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info) {
            if(PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public BaseInfo() {
        }

        string fieldCode;
        /// <summary>
        /// 字段代码
        /// </summary>
        public string FieldCode {
            get {
                return fieldCode;
            }
            set {
                fieldCode = value;
                this.NotifyPropertyChanged("Code");
            }
        }

        string fieldName;
        /// <summary>
        /// 字段名称
        /// </summary>
        public string FieldName {
            get {
                return fieldName;
            }
            set {
                fieldName = value;
                this.NotifyPropertyChanged("Name");
            }
        }

        string fieldSummary;
        /// <summary>
        /// 字段内容
        /// </summary>
        public string FieldSummary {
            get {
                return fieldSummary;
            }
            set {
                fieldSummary = value;
                this.NotifyPropertyChanged("Summary");
            }
        }
    }
}
