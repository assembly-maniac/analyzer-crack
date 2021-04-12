using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Analyzer
{
	public interface IAnalyzer
	{
		List<AnalyzeResult> Analyze();
	}
}
