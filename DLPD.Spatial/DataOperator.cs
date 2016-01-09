﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotSpatial.Data;
using System.Data;
using DotSpatial.Topology;
using DLPD.Common;
namespace DLPD.Spatial {
    public class DataOperator {
        public static DataTable DataRead(string path) {
            IFeatureSet fs = FeatureSet.Open(path);
            DataTable dt = fs.DataTable;
            dt.Columns.Add(new DataColumn("CentroidX", typeof(double)));
            dt.Columns.Add(new DataColumn("CentroidY", typeof(double)));
            foreach (IFeature feature in fs.Features) {
                double x = feature.Centroid().Coordinates[0].X;
                double y = feature.Centroid().Coordinates[0].Y;
                feature.DataRow.BeginEdit();
                feature.DataRow["CentroidX"] = x;
                feature.DataRow["CentroidY"] = y;
                feature.DataRow.EndEdit();
            }
            
            foreach (DataColumn column in dt.Columns) {
                column.ReadOnly = true;
            }
            dt.Columns.Add(new DataColumn("MAXGJZJDB", typeof(int)));
            return dt;
        }
        /// <summary>
        /// 单线程计算
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DataTable MaxLevelCalculate(DataTable dt) {
            
            foreach (DataRow row in dt.Rows) {
            //DataRow row = dt.Rows[index];
                GDZLDJ gdzldj = new GDZLDJ();
                gdzldj.LYXS = double.Parse(row["LYXS"].ToString());
                //gdzldj.ZRZLF.Ggbzl.Summary = row["GGBZLZ"].ToString();
                gdzldj.ZRZLF.Trzd.Summary = row["BCTRZDZ"].ToString();
                gdzldj.ZRZLF.Hb.Summary = row["HBGDZ"].ToString();
                gdzldj.ZDZW1GW = Int32.Parse(row["ZDZW1GW"].ToString());
                gdzldj.ZDZW1B = Int32.Parse(row["ZDZW1B"].ToString());
                gdzldj.ZDZW2GW = Int32.Parse(row["ZDZW2GW"].ToString());
                gdzldj.ZDZW2B = Int32.Parse(row["ZDZW2B"].ToString());
                row["MAXGJZJDB"] = gdzldj.ToGJLYDB();
            }

            return dt;
        }
        /// <summary>
        /// 多线程计算
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static DataRow MaxLevelMultiCalculate(DataRow row) {
            
                GDZLDJ gdzldj = new GDZLDJ();
                gdzldj.LYXS = double.Parse(row["LYXS"].ToString());
                //gdzldj.ZRZLF.Ggbzl.Summary = row["GGBZLZ"].ToString();
                gdzldj.ZRZLF.Trzd.Summary = row["BCTRZDZ"].ToString();
                gdzldj.ZRZLF.Hb.Summary = row["HBGDZ"].ToString();
                gdzldj.ZDZW1GW = Int32.Parse(row["ZDZW1GW"].ToString());
                gdzldj.ZDZW1B = Int32.Parse(row["ZDZW1B"].ToString());
                gdzldj.ZDZW2GW = Int32.Parse(row["ZDZW2GW"].ToString());
                gdzldj.ZDZW2B = Int32.Parse(row["ZDZW2B"].ToString());
                row["MAXGJZJDB"] = gdzldj.ToGJLYDB();
                      
            return row;
        }
    }
}
