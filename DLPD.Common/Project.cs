using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DLPD.Common {
    public class Project {
        public Project() {
        }

        string name;
        /// <summary>
        /// 项目名称
        /// </summary>
        public string Name {
            get {
                return name;
            }
            set {
                name = value;
            }
        }
        string id;
        /// <summary>
        /// 地块编号
        /// </summary>
        public string Id {
            get {
                return id;
            }
            set {
                id = value;
            }
        }


        CoordinatePosition cp;
        /// <summary>
        /// 坐标位置
        /// </summary>
        public CoordinatePosition CP {
            get {
                return cp;
            }
            set {
                cp = value;
            }
        }

        string property;
        /// <summary>
        /// 项目性质
        /// </summary>
        public string Property {
            get {
                return property;
            }
            set {
                property = value;
            }
        }

        string type;
        /// <summary>
        /// 耕地利用类型
        /// </summary>
        public string Type {
            get {
                return type;
            }
            set {
                type = value;
            }
        }

        ZRZLF zrzlf;
        /// <summary>
        /// 自然质量分
        /// </summary>
        public ZRZLF Zrzlf {
            get {
                return zrzlf;
            }
            set {
                zrzlf = value;
            }
        }

    }
    /// <summary>
    /// 坐标位置
    /// </summary>
    public class CoordinatePosition {
        public CoordinatePosition() {
        }

        string north;
        /// <summary>
        /// 北
        /// </summary>
        public string North {
            get {
                return north;
            }
            set {
                north = value;
            }
        }

        string south;
        /// <summary>
        /// 南
        /// </summary>
        public string South {
            get {
                return south;
            }
            set {
                south = value;
            }
        }

        string east;
        /// <summary>
        /// 东
        /// </summary>
        public string East {
            get {
                return east;
            }
            set {
                east = value;
            }
        }
        string west;
        /// <summary>
        /// 西
        /// </summary>
        public string West {
            get {
                return west;
            }
            set {
                west = value;
            }
        }
        /// <summary>
        /// 重写ToString函数，返回东南西北合集
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append("北至");
            sb.Append(north);
            sb.Append("\n东至");
            sb.Append(east);
            sb.Append("\n南至");
            sb.Append(south);
            sb.Append("\n西至");
            sb.Append(west);
            return sb.ToString();
        }

    }
}
