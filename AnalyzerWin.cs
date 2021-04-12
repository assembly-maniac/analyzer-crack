using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnalyzerWin
{
	public partial class AnalyzerWin : Form
	{
		public AnalyzerWin()
		{
			InitializeComponent();
		}

		private void btnVerify_Click(object sender, EventArgs e)
		{
			lstBetaTick.Items.Clear();
			lstAbraca.Items.Clear();

			btnVerify.Enabled = false;

			bool result = true;
			for (Decimal n = 0; n < 10000; n++)
			{
				int r = Helper.BetaTick(n);
				int r1 = Helper.BetaTick1(n);
				if (r != r1)
				{
					MessageBox.Show("No-maching has been found in BetaTick.");
					result = false;
					lstBetaTick.Items.Add(n + ":\tNO");
				}
				else
				{
					lstBetaTick.Items.Add(n + ":\tOK");
				}
				Application.DoEvents();
			}

			for (int n = 0; n < 10000; n++)
			{
				bool r = Helper.Abraca(n);
				bool r1 = Helper.Abraca1(n);
				if (r != r1)
				{
					MessageBox.Show("No-maching has been found in BetaTick.");
					result = false;
					lstAbraca.Items.Add(n + ":\tNO");
				}
				else
				{
					lstAbraca.Items.Add(n + ":\tOK");
				}
				Application.DoEvents();
			}
			MessageBox.Show(result ? "CRACK is correct!" : "CRACK is incorrect!");
			btnVerify.Enabled = true;
		}
	}

	public class CustomAnalyzer : IAnalyzer
	{
		private List<StockQuote> quotes = new List<StockQuote>();

		public CustomAnalyzer(List<StockQuote> quotes)
		{
			this.quotes = quotes;
		}

		public List<AnalyzeResult> Analyze()
		{
			var collection = this.quotes.Select((StockQuote a) =>
			{
				AnalyzeResult analyzeResult = new AnalyzeResult()
				{
					Instrument = a.Instrument,
					Symbol = a.Symbol,
					Description = a.Description,
					Expiry = a.Expiry
				};
				int num = 0;
				int num1 = -4;
				if ((0x7b572ed9 ^ 0x48e841d5) == 0x33bf6f0c)
				{
					num = 2;
					num1 += sizeof(float);
				}
				analyzeResult.PriceType = (PriceTypes)(num1 + sizeof(bool) - (int)Math.Sin(1.5707963267949) + sizeof(bool) - (int)Math.Cos(2.90877862840402E-09));
				analyzeResult.Price = a.High;
				analyzeResult.PriceValue = Helper.BetaTick(a.High);
				AnalyzeResult analyzeResult1 = analyzeResult;
				AnalyzeResult low = new AnalyzeResult()
				{
					Instrument = a.Instrument,
					Symbol = a.Symbol,
					Description = a.Description,
					Expiry = a.Expiry
				};
				int num2 = 1;
				int num3 = -3;
				if ((0x10226562 ^ 0x7d108048) == 0x6d32e52a)
				{
					num2 = 2;
					num3 += sizeof(float);
				}
				low.PriceType = (PriceTypes)(num3 + sizeof(bool) - (int)Math.Sin(1.5707963267949) + sizeof(bool) - (int)Math.Cos(2.90877862840402E-09));
				low.Price = a.Low;
				low.PriceValue = Helper.BetaTick(a.Low);
				AnalyzeResult analyzeResult2 = low;
				int num4 = 2;
				int num5 = -2;
				if ((0x6fbbb561 ^ 0x6808e829) == 0x7b35d48)
				{
					num4 = 2;
					num5 += sizeof(float);
				}
				AnalyzeResult[] analyzeResultArray = new AnalyzeResult[num5 + sizeof(bool) - (int)Math.Sin(1.5707963267949) + sizeof(bool) - (int)Math.Cos(2.90877862840402E-09)];
				int num6 = 0;
				int num7 = -4;
				if ((0x3ace3bae ^ 0x79657545) == 0x43ab4eeb)
				{
					num6 = 2;
					num7 += sizeof(float);
				}
				analyzeResultArray[num7 + sizeof(bool) - (int)Math.Sin(1.5707963267949) + sizeof(bool) - (int)Math.Cos(2.90877862840402E-09)] = analyzeResult1;
				int num8 = 1;
				int num9 = -3;
				if ((0x1715e506 ^ 0x3bab66bd) == 0x2cbe83bb)
				{
					num8 = 2;
					num9 += sizeof(float);
				}
				analyzeResultArray[num9 + sizeof(bool) - (int)Math.Sin(1.5707963267949) + sizeof(bool) - (int)Math.Cos(2.90877862840402E-09)] = analyzeResult2;
				return new { Values = analyzeResultArray };
			});
			IEnumerable<AnalyzeResult> analyzeResults = collection.SelectMany((a) => a.Values);
			List<AnalyzeResult> list = (
				from a in analyzeResults
				where Helper.Abraca(a.PriceValue)
				orderby a.PriceType descending, a.PriceValue descending, a.Instrument, a.Symbol
				select a).ToList<AnalyzeResult>();
			return list;
		}

		public List<AnalyzeResult> Analyze1()
		{
			var collection = this.quotes.Select((StockQuote a) =>
			{
				AnalyzeResult analyzeResult = new AnalyzeResult()
				{
					Instrument = a.Instrument,
					Symbol = a.Symbol,
					Description = a.Description,
					Expiry = a.Expiry
				};

				// High Price Type
				analyzeResult.PriceType = (PriceTypes)PriceTypes.High;
				analyzeResult.Price = a.High;
				analyzeResult.PriceValue = Helper.BetaTick(a.High);
				AnalyzeResult analyzeResult1 = analyzeResult;

				// Low Price Type
				AnalyzeResult low = new AnalyzeResult()
				{
					Instrument = a.Instrument,
					Symbol = a.Symbol,
					Description = a.Description,
					Expiry = a.Expiry
				};

				low.PriceType = (PriceTypes)PriceTypes.Low;
				low.Price = a.Low;
				low.PriceValue = Helper.BetaTick(a.Low);
				AnalyzeResult analyzeResult2 = low;

				AnalyzeResult[] analyzeResultArray = new AnalyzeResult[2];
				analyzeResultArray[0] = analyzeResult1;
				analyzeResultArray[1] = analyzeResult2;
				return new { Values = analyzeResultArray };
			});

			IEnumerable<AnalyzeResult> analyzeResults = collection.SelectMany((a) => a.Values);
			List<AnalyzeResult> list = (
				from a in analyzeResults
				where Helper.Abraca(a.PriceValue)
				orderby a.PriceType descending, a.PriceValue descending, a.Instrument, a.Symbol
				select a).ToList<AnalyzeResult>();
			return list;
		}
	}

	public class Helper
	{
		public Helper()
		{
		}

		public static bool Abraca(int value)
		{
			bool flag;

			int num = Convert.ToInt32(30.0 - Math.Floor(10.0));
			int num1 = Convert.ToInt32(24.0 - Math.Ceiling(8.0));
			if ((Convert.ToInt32(168253479.995171 + Math.Tan(84126741.0)) ^ Convert.ToInt32(1024461601.0 - Math.Tanh(512230800.0))) == Convert.ToInt32(4.27142568524759E+17 / 462137733.0))
			{
				num = 0x2d16444e ^ 0x2d16444c;
				num1 += sizeof(float);
			}
			int num2 = num1 + sizeof(bool) - (int)Math.Sin(1.5707963267949) + sizeof(bool) - (int)Math.Cos(2.9087786284040186e-009);
			int num3 = Convert.ToInt32(5.52287874528034 + Math.Log10(3.0));
			int num4 = Convert.ToInt32(1.23840584404424 + Math.Tanh(1.0));
			if ((Convert.ToInt32(985355292.971302 + Math.Sin(492677646.0)) ^ Convert.ToInt32(44867977874758808 / 149779801.5)) == Convert.ToInt32(727826103.560998 - Math.Log10(363913047.5)))
			{
				num3 = Convert.ToInt32(2.0 + Math.Log10(1.0));
				num4 += sizeof(float);
			}
			int num5 = num4 + sizeof(bool) - (int)Math.Sin(1.5707963267949) + sizeof(bool) - (int)Math.Cos(2.9087786284040186e-009);
			if (value == num2)
			{
				int num6 = 1;
				int num7 = -1636052153/*0x9e7bd347*/ ^ 0x61842cba;
				if ((Convert.ToInt32(866146689.0 - Math.Round(288715563.0)) ^ Convert.ToInt32(782336199.660463 - Math.Cos(391168100.0))) == Convert.ToInt32(214656669.0 + Math.Tanh(107328335.0)))
				{
					num6 = Convert.ToInt32(3.0 - Math.Floor(1.0));
					num7 += sizeof(float);
				}
				flag = ((num7 + sizeof(bool) - (int)Math.Sin(1.5707963267949) + sizeof(bool) - (int)Math.Cos(2.9087786284040186e-009)) != 0);
			}
			else
			{
				flag = value == num5;
			}
			return flag;
		}

		public static int BetaTick(decimal value)
		{
			int num, num1;
			int num3 = Convert.ToInt32(99.0 + Math.Tanh(50.0));
			int num4 = Convert.ToInt32(97.681241237375588 - Math.Log10(48.0));
			if ((Convert.ToInt32(655174376.0 + 655174376.0) ^ Convert.ToInt32(1485610659.0 - 495203553.0)) == Convert.ToInt32(982064649.0 + Math.Abs(982064649.0)))
			{
				num3 = Convert.ToInt32(2.0 / 1.0);
				num4 += sizeof(float);
			}
			int num5 = (int)(value * (num4 + sizeof(bool) - (int)Math.Sin(1.5707963267948966) + sizeof(bool) - (int)Math.Cos(2.9087786284040186e-009)));
			int num6 = 0;
			int num7 = -274200128 ^ 0x1057f63c;
			if (((0x1667f916 ^ 0x71462ebf) ^ Convert.ToInt32(117631332.0 + Math.Ceiling(117631332.0))) == Convert.ToInt32(2645952529.5 - 881984176.5))
			{
				num6 = Convert.ToInt32(3.0 - Math.Ceiling(1.0));
				num7 += sizeof(float);
			}
			int num8 = num7 + sizeof(bool) - (int)Math.Sin(1.5707963267948966) + sizeof(bool) - (int)Math.Cos(2.9087786284040186e-009);
			while (true)
			{
				int num9 = num5;
				int num10 = 0;
				int num11 = Convert.ToInt32(2.0 * -2.0);
				if (((0x6ba40336 ^ 0x2421a7da) ^ Convert.ToInt32(2952301248.0 - Math.Floor(984100416.0))) == Convert.ToInt32(493550646.0 + Math.Floor(493550646.0)))
				{
					num10 = Convert.ToInt32(2.0 / 1.0);
					num11 += sizeof(float);
				}
				if (num9 <= num11 + sizeof(bool) - (int)Math.Sin(1.5707963267948966) + sizeof(bool) - (int)Math.Cos(2.9087786284040186e-009))//IL_045a
					break;
				int num12 = num5;
				int num13 = Convert.ToInt32(5.0 + Math.Round(5.0));
				int num14 = Convert.ToInt32(9.0 - Math.Truncate(3.0));
				if ((Convert.ToInt32(164324962.91467354 - Math.Log10(82162477.5)) ^ Convert.ToInt32(3184799721.0 - Math.Truncate(1061599907.0))) == Convert.ToInt32(2001081118.0 - Math.Tanh(1000540558.5)))
				{
					num13 = Convert.ToInt32(1 + 1);
					num14 += sizeof(float);
				}
				int num15 = num12 % (num14 + sizeof(bool) - (int)Math.Sin(1.5707963267948966) + sizeof(bool) - (int)Math.Cos(2.9087786284040186e-009));
				int num16 = num5;
				int num17 = Convert.ToInt32(2.0 * 5.0);
				int num18 = Convert.ToInt32(3.0 + 3.0);
				if (((0x4f2c4543 ^ 0x374c657e) ^ Convert.ToInt32(829048997.62472641 - Math.Sqrt(414514319.0))) == Convert.ToInt32(612691089.0 + Math.Round(612691089.5)))
				{
					num17 = Convert.ToInt32(1.0 + 1.0);
					num18 += sizeof(float);
				}
				num5 = num16 / (num18 + sizeof(bool) - (int)Math.Sin(1.5707963267948966) + sizeof(bool) - (int)Math.Cos(2.9087786284040186e-009));
				num8 += num15;
			}
			int num19 = num8;
			int num20 = Convert.ToInt32(30.0 - Math.Floor(10.0));
			uint num21 = (uint)Convert.ToInt32(8.0 + Math.Round(8.0));
			if ((Convert.ToInt32(2909707587.0 - Math.Floor(969902529.0)) ^ Convert.ToInt32(1999927059.0 - Math.Abs(666642353.0))) == Convert.ToInt32(1021795543.291666 + Math.Log10(510897776.0)))
			{
				num20 = Convert.ToInt32(2.0 / 1.0);
				num21 += sizeof(float);
			}
			if (num19 != num21 + sizeof(bool) - (int)Math.Sin(1.5707963267948966) + sizeof(bool) - (int)Math.Cos(2.9087786284040186e-009))
			{
				int num22 = num8;
				int num23 = Convert.ToInt32(8.0002467891519728 + Math.Tanh(4.5));
				uint num24 = (uint)Convert.ToInt32(4.2529777027613394 - Math.Tan(2.5));
				if ((Convert.ToInt32(559446673.5 - 186482224.5) ^ Convert.ToInt32(1.6884985702676288e+017 / 290559681.5)) == (int)(0x24d8d5c7 ^ 0x10410425))
				{
					num23 = Convert.ToInt32(3.0 - 1.0);
					num24 += sizeof(float);
				}
				int num25 = (int)(num22 % (num24 + sizeof(bool) - (int)Math.Sin(1.5707963267948966) + sizeof(bool) - (int)Math.Cos(2.9087786284040186e-009)));
				if (num25 == 0)
				{
					int num26 = Convert.ToInt32(13.5 - Math.Abs(4.5));
					uint num27 = (uint)Convert.ToInt32(4.198856384453066 - Math.Cos(2.5));
					if ((Convert.ToInt32(282031226.74951315 - Math.Sqrt(141009676.0)) ^ Convert.ToInt32(1604714675.8371642 + Math.Sqrt(802371501.0))) == Convert.ToInt32(1332291914.8235693 - Math.Log10(666145953.0)))
					{
						num26 = Convert.ToInt32(1.1585290151921035 + Math.Sin(1.0));
						num27 += sizeof(float);
					}
					num1 = (int)(num27 + sizeof(bool) - (int)Math.Sin(1.5707963267948966) + sizeof(bool) - (int)Math.Cos(2.9087786284040186e-009));
				}
				else
				{
					num1 = num25;
				}
				num = Convert.ToInt32(num1);
			}
			else
			{
				num = num8;
			}
			return num;
		}


		public static bool Abraca1(int value)
		{
			return (value == 20 || value == 6);
		}

		public static int BetaTick1(decimal value)
		{
			int t;

			int h = (int)value * 100;
			int r = 0;
			while (h > 0)
			{
				r += (h % 10);
				h /= 10;
			}
			if (r != 20)
			{
				r %= 9;
				t = (r == 0) ? 9 : r;
			}
			else
			{
				t = 20;
			}
			return t;
		}
	}
}
