using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Analyzer
{
	public class StockQuote
	{
		public decimal Close
		{
			get;
			set;
		}

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

		public decimal High
		{
			get;
			set;
		}

		public string Instrument
		{
			get;
			set;
		}

		public decimal Low
		{
			get;
			set;
		}

		public decimal Open
		{
			get;
			set;
		}

		public DateTime QuoteTime
		{
			get;
			set;
		}

		public string Symbol
		{
			get;
			set;
		}

		public int Volume
		{
			get;
			set;
		}

		public StockQuote()
		{
		}
	}
}
