using DotSpatial.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DLPD.Common {
    /// <summary>
    /// 常量
    /// </summary>
    public class Constant {
        /// <summary>
        /// 国家利用等别计算@ruby
        /// </summary>
        public const string GJLYDB = @"./Interface/GJLYDB.rb";

        public const string DataBase = @"./Data/331121青田县耕地等级/XJFDDY.shp";
        /// <summary>
        /// 耕地质量等级评定基本信息表路径
        /// </summary>
        public const string BaseInfoConfig = @"./Config/土地整治补充耕地质量等级数据库字段标准.xlsx";
        /// <summary>
        /// 耕地质量等级评定基本信息表名
        /// </summary>
        public const string BaseInfoSheetName = "土地整治补充耕地质量等级数据库字段标准";
        /// <summary>
        /// 自然质量分关系表
        /// </summary>
        public const string WeightConfig = @"./Config/自然质量分关系表.xml";
        /// <summary>
        /// 地类
        /// </summary>
        public enum FieldType {
            /// <summary>
            /// 水田
            /// </summary>
            type0=0,
            /// <summary>
            /// 旱地
            /// </summary>
            type1=1
        };
        /// <summary>
        /// 自然质量分对应关系表
        /// </summary>
        public static Hashtable ZRZLFSheet = new Hashtable();

        public static IFeatureSet fs;
    }
}
