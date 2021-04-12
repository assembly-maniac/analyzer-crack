using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Analyzer
{
	public class AnalyzeResult
	{
		public string Description
		{
			get;
			set;
		}

		public string Expiry
		{
			get;
			set;
		}

		public string Instrument
		{
			get;
			set;
		}

		public decimal Price
		{
			get;
			set;
		}

		public PriceTypes PriceType
		{
			get;
			set;
		}

		public int PriceValue
		{
			get;
			set;
		}

		public string Symbol
		{
			get;
			set;
		}

		public AnalyzeResult()
		{
		}
	}
}
