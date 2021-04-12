using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnalyzerWin
{
	public interface IAnalyzer
	{
		List<AnalyzeResult> Analyze();
	}
}
