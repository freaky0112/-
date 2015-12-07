using System;

namespace Constant
{
	/// <summary>
	/// 耕地质量分等因素
	/// </summary>
	public class GDZLFDYS {
		public GDZLFDYS () {
		}

		double weight;

		/// <summary>
		/// 指数权重
		/// </summary>
		/// <value>权重</value>
		public double Weight {
			get { return weight; }
			set { weight = value; }
		}

		string name;

		/// <summary>
		/// 评定指数名
		/// </summary>
		/// <value>评定指数名</value>
		public string Name {
			get{ return name; }
			set { name = value; }
		}

		int mark;

		/// <summary>
		/// 分数
		/// </summary>
		/// <value>The mark.</value>
		public int Mark {
			get{ return mark; }
			set{ mark = value; }
		}

		string summary;

		/// <summary>
		/// 说明
		/// </summary>
		/// <value>The summary.</value>
		public string Summary {
			get{ return summary; }
			set{ summary = value; }
		}

		public double ToValue(){
			double vaule=mark*weight;
			return vaule;
		}
	}
	/// <summary>
	/// 土壤质地
	/// </summary>
	public class TRZD: GDZLFDYS{
		public TRZD(){
			this.Weight = 0.2;
		}
	}
	/// <summary>
	/// 耕层厚度
	/// </summary>
	public class GCHD:GDZLFDYS{
		public GCHD(){
			this.Weight = 0.25;
		}
	}
	/// <summary>
	/// 田块状况
	/// </summary>
	public class TKZK:GDZLFDYS{
		public TKZK(){
			this.Weight = 0.1;
		}
	}
	/// <summary>
	/// 有机质含量
	/// </summary>
	public class YJZHL:GDZLFDYS{
		public YJZHL(){
			this.Weight = 0.1;
		}
	}
	/// <summary>
	/// 田间道路状况
	/// </summary>
	public class TJDLTJ:GDZLFDYS{
		public TJDLTJ(){
			this.Weight = 0.1;
		}
	}
	/// <summary>
	/// 灌溉保证率
	/// </summary>
	public class GGBZL:GDZLFDYS{
		public GGBZL(){
			this.Weight = 0.2;
		}
	}
	/// <summary>
	/// 海拔
	/// </summary>
	public class HB:GDZLFDYS{
		public HB(){
			this.Weight = 0.05;
		}
	}
}

