using DLPD.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotSpatial.Data;
using System.Data.OleDb;

namespace DLPD.Config {
    public class ConfigHelper {
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
    }
}
