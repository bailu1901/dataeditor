using System;
namespace WindowsFormsApplication1
{
	public class DRange
	{
		public double LowerBound
		{
			get;
			set;
		}
		public double UpperBound
		{
			get;
			set;
		}
		public DRange(double low, double up)
		{
			this.LowerBound = low;
			this.UpperBound = up;
		}
		public override string ToString()
		{
			return string.Concat(new string[]
			{
				"(",
				this.LowerBound.ToString(),
				", ",
				this.UpperBound.ToString(),
				")"
			});
		}
	}
}
