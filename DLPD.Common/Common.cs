using System;
using System.Collections.Generic;
using System.Collections;
using IronRuby;
using System.Text;

namespace DLPD.Common {
	/// <summary>
	/// 自然质量分
	/// </summary>
	public class ZRZLF {
		/// <summary>
		/// 初始化类，自然质量分
		/// </summary>
		public ZRZLF() {

		}

		/// <summary>
		/// 初始化类，自然质量分
		/// </summary>
		/// <param name="trzd">土壤质地</param>
		/// <param name="gchd">耕层厚度</param>
		/// <param name="tkzk">田块状况</param>
		/// <param name="yjzhl">有机质含量</param>
		/// <param name="tjdltj">田间道路条件</param>
		/// <param name="ggbzl">灌溉保证率</param>
		/// <param name="hb">海拔</param>
		public ZRZLF(TRZD trzd, GCHD gchd, TKZK tkzk, YJZHL yjzhl, TJDLTJ tjdltj, GGBZL ggbzl, HB hb) {
			this.trzd = trzd;
			this.gchd = gchd;
			this.tkzk = tkzk;
			this.yjzhl = yjzhl;
			this.tjdltj = tjdltj;
			this.ggbzl = ggbzl;
			this.hb = hb;
		}

		TRZD trzd;

		/// <summary>
		/// 土壤质地
		/// </summary>
		/// <value>The trzd.</value>
		public TRZD Trzd {
			get{ return trzd; }
			set{ trzd = value; }
		}

		GCHD gchd;

		/// <summary>
		/// 耕层厚度
		/// </summary>
		/// <value>The gchd.</value>
		public GCHD Gchd {
			get{ return gchd; }
			set{ gchd = value; }
		}

		TKZK tkzk;

		/// <summary>
		/// 田块状况
		/// </summary>
		/// <value>The tkzk.</value>
		public TKZK Tkzk {
			get{ return tkzk; }
			set{ tkzk = value; }
		}

		YJZHL yjzhl;

		/// <summary>
		/// 有机质含量
		/// </summary>
		/// <value>The yjzhl.</value>
		public YJZHL Yjzhl {
			get{ return yjzhl; }
			set{ yjzhl = value; }
		}

		TJDLTJ tjdltj;

		/// <summary>
		/// 田间道路条件
		/// </summary>
		/// <value>The tjdltj.</value>
		public TJDLTJ Tjdltj {
			get{ return tjdltj; }
			set{ tjdltj = value; }
		}

		GGBZL ggbzl;

		/// <summary>
		/// 灌溉保证率
		/// </summary>
		/// <value>The ggbzl.</value>
		public GGBZL Ggbzl {
			get{ return ggbzl; }
			set{ ggbzl = value; }
		}

		HB hb;

		/// <summary>
		/// 海拔
		/// </summary>
		/// <value>The hb.</value>
		public HB Hb {
			get{ return hb; }
			set{ hb = value; }
		}

		/// <summary>
		/// 自然质量分
		/// </summary>
		/// <returns>The value.</returns>
		public double ToValue() {
			double value = 0;
			value = trzd.ToValue() +
			gchd.ToValue() +
			tkzk.ToValue() +
			yjzhl.ToValue() +
			tjdltj.ToValue() +
			ggbzl.ToValue() +
			hb.ToValue();
			return value / 100;
		}
	}

	/// <summary>
	/// 耕地质量等级
	/// </summary>
	public class GDZLDJ {
		/// <summary>
		/// 初始化耕地质量等级
		/// </summary>
		public GDZLDJ() {
		}

		int zdzw1gw;

		/// <summary>
		/// 指定作物1光温生产潜力指数
		/// </summary>
		/// <value>The GWSCLZ.</value>
		public int ZDZW1GW {
			get{ return zdzw1gw; }
			set{ zdzw1gw = value; }
		}



		int zdzw2gw;

		/// <summary>
		/// 指定作物2光温生产潜力指数
		/// </summary>
		/// <value>The GWSCLZ.</value>
		public int ZDZW2GW {
			get{ return zdzw2gw; }
			set{ zdzw2gw = value; }
		}



		int zdzw1b;

		/// <summary>
		/// 指定作物1产量比系数
		/// </summary>
		/// <value>The CLBX.</value>
		public int ZDZW1B {
			get{ return zdzw1b; }
			set{ zdzw1b = value; }
		}

		int zdzw2b;

		/// <summary>
		/// 指定作物2产量比系数
		/// </summary>
		/// <value>The CLBX.</value>
		public int ZDZW2B {
			get{ return zdzw2b; }
			set{ zdzw2b = value; }
		}

		ZRZLF zrzlf;

		/// <summary>
		/// 自然质量分
		/// </summary>
		/// <value>The zrzlf.</value>
		public ZRZLF ZRZLF {
			get{ return zrzlf; }
			set{ zrzlf = value; }
		}
		/// <summary>
		/// 自然质量等指数
		/// </summary>
		/// <returns>The ZRDZ.</returns>
		private double ToZRDZS() {
			return (zdzw1gw*zdzw1b + zdzw2gw*zdzw2b)*zrzlf.ToValue();
		}

		double lyxs;
		/// <summary>
		/// 土地利用系数
		/// </summary>
		/// <value>The LYX.</value>
		public double LYXS{
			get{ return lyxs; }
			set{ lyxs = value; }
		}

        double gjlydzs;
        /// <summary>
        ///国家利用等指数
        /// </summary>
        public double GJLYDZS {
            get {
                return gjlydzs;
            }
            set {
                gjlydzs = value;
            }
        }

        int gjlydb;
        /// <summary>
        /// 国家利用等
        /// </summary>
        public int GJLYDB {
            get {
                return gjlydb;
            }
            set {
                gjlydb = value;
            }
        } 


		/// <summary>
		/// 国家级利用等指数计算
		/// </summary>
		/// <returns>The GJLYDZ.</returns>
		public double ToGJLYDZS(){
			double lydzs = ToZRDZS() * lyxs * 0.5778 + 116.67;
			return lydzs;
		}
		/// <summary>
		/// 国家级利用等级计算
		/// </summary>
		/// <returns>The GJLYD.</returns>
		public int ToGJLYDB(){
			int gjtydb=0;
			var rubyEngine = Ruby.CreateEngine();
            rubyEngine.ExecuteFile(Constant.GJLYDB);
			dynamic ruby = rubyEngine.Runtime.Globals;
			dynamic config = ruby.GJLYDB.@new();
			double gjlydzs = this.ToGJLYDZS();
			gjtydb = config.getGJLYDB(gjlydzs);
			return gjtydb;
		}
		
	}

}
