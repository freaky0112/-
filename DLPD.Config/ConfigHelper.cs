using DLPD.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotSpatial.Data;
using System.Data.OleDb;
using System.Data;
using System.Xml.Linq;
using System.Collections;

namespace DLPD.Config {
    public class ConfigHelper {
        /// <summary>
        /// 已有耕地质量等级图层读取
        /// </summary>
        /// <param name="FID"></param>
        /// <returns></returns>
        public static GDZLDJ DataBaseRead(int FID) {

            IFeatureSet fs = FeatureSet.Open(Constant.DataBase);
            IFeature feature = fs.GetFeature(FID);
            GDZLDJ gdzldj = new GDZLDJ();
            ZRZLF zrzlf=new ZRZLF();
            gdzldj.LYXS =Double.Parse(feature.DataRow["LYXS"].ToString());
            gdzldj.GJLYDB = Int32.Parse(feature.DataRow["GJLYD"].ToString());
            gdzldj.GJLYDZS = Double.Parse(feature.DataRow["GJLYDZS"].ToString());
            #region 自然质量分
            zrzlf.Gchd.Summary = feature.DataRow["ZACJDBSDZ"].ToString();//耕层厚度
            zrzlf.Trzd.Summary = feature.DataRow["BCTRZDZ"].ToString();//土壤质地
            zrzlf.Yjzhl.Summary = feature.DataRow["TRYJZHLZ"].ToString();//有机质含量
            zrzlf.Ggbzl.Summary = feature.DataRow["GGBZLZ"].ToString();//灌溉保证率
            zrzlf.Hb.Summary = feature.DataRow["HBGDZ"].ToString();//海拔高度值
            #endregion


            return gdzldj;
        }
        /// <summary>
        /// 土地整治补充耕地质量等级数据库字段标准表读取
        /// </summary>
        /// <returns></returns>
        public static List<BaseInfo> BaseInfoRead() {
            List<BaseInfo> bis = new List<BaseInfo>();
            ExcelHelper exhelper = new ExcelHelper(Constant.BaseInfoConfig);
            DataTable dt=exhelper.ExcelToDataTable(Constant.BaseInfoSheetName,true);
            foreach(DataRow row in dt.Rows) {
                BaseInfo bi = new BaseInfo();
                bi.FieldCode = row["字段代码"].ToString();
                bi.FieldName = row["字段名称"].ToString();
                bis.Add(bi);
            }
            return bis;
        }
        /// <summary>
        /// 权重信息读取
        /// </summary>
        /// <param name="type">类型水田true|旱地false</param>
        public static int WeightRead(bool type,string keyword) {
            int mark = 0;
            if(type) {//水田
                mark=WeithtWaterRead(keyword);   
            }
            return mark;
        }
        /// <summary>
        /// 水田权重
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        private static int WeithtWaterRead(string keyword) {
            int mark = 0;
            XElement weightconfig = XElement.Load(Constant.WeightConfig);
            IEnumerable<XElement> els = from el in weightconfig.Elements("Type").Elements()
                                        select el;
            foreach(XElement el in els) {
                if(el.Attribute("Summary").Value.Contains(keyword)) {
                    mark =Int32.Parse(el.Attribute("Mark").Value.ToString());
                    break;
                }
            }                     
            return mark;
        }
        /// <summary>
        /// 获取自然质量分类型
        /// </summary>
        /// <returns></returns>
        public static Hashtable ZRZLFRead() {
            Hashtable types = new  Hashtable();
            XElement weightconfig = XElement.Load(Constant.WeightConfig);
            IEnumerable<XElement> els = from el in weightconfig.Elements("Type")
                                        select el;
            foreach(XElement el in els) {
                List<string> names=new List<string>();
                string name=el.Attribute("Name").Value;
                foreach(XElement e in el.Elements()) {
                    names.Add(e.Attribute("Summary").Value);
                }
                types.Add(name,names);
            }
            return types;
        }


        /// <summary>
        /// 自然质量分评价对应分数
        /// </summary>
        /// <returns></returns>
        public static Hashtable ZRZLFMarkRead() {
            Hashtable types = new Hashtable();
            XElement weightconfig = XElement.Load(Constant.WeightConfig);
            IEnumerable<XElement> els = from el in weightconfig.Elements("Type")
                                        select el;
            foreach (XElement el in els) {
                //List<string> names = new List<string>();
                //string name = el.Attribute("Name").Value;
                foreach (XElement e in el.Elements()) {
                    string key=e.Attribute("Summary").Value;
                    double mark =double.Parse(e.Attribute("Mark").Value);
                    types.Add(key  ,mark);
                }
            }
            return types;
        }


        ///// <summary>
        ///// 自然质量分分等因素读取
        ///// </summary>
        ///// <returns></returns>
        //public static List<string> FDYSRead(string type) {
        //    List<string> types = new List<string>();
        //    XElement weightconfig = XElement.Load(Constant.WeightConfig);
        //    IEnumerable<XElement> els = from el in weightconfig.Elements("Type").Elements()
        //                                where el.
        //                                select el;
        //    foreach(XElement el in els) {
        //        //types.Add(el.Attribute("Summary").Value);
        //    }
        //    return types;

        //}
    }
}
