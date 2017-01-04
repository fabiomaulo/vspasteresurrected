using System.Linq;

namespace Hunabku.VSPasteResurrected.RTF
{
	public class Options
	{
		public string TabToSpace => string.Concat(Enumerable.Repeat("&nbsp;", TabSpaces > 0 ? TabSpaces:2));
		public bool InLineStyles { get; set; } = true;
		public int MaxHeight { get; set; } = 500;
		public string BackgroundColor { get; set; } = "white";
		public int FontSize { get; set; } = 10;
		public string[] FontFamiles { get; set; } = {"'Courier New'", "Courier", "Monospace"};
		public int TabSpaces { get; set; } = 2;
	}
}