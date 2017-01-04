using System.Linq;
using Hunabku.VSPasteResurrected.RTF;
using OpenLiveWriter.Api;

namespace Hunabku.VSPasteResurrected
{
	public static class OptionsExtensions
	{
		private static readonly Options defaultOptions = new Options();

		public static Options ToOptions(this IProperties source)
		{
			var options = new Options();
			if (source == null)
			{
				return options;
			}
			options.InLineStyles = source.GetBoolean(nameof(Options.InLineStyles), defaultOptions.InLineStyles);
			options.MaxHeight = source.GetInt(nameof(Options.MaxHeight), defaultOptions.MaxHeight);
			options.BackgroundColor = source.GetString(nameof(Options.BackgroundColor), defaultOptions.BackgroundColor);
			options.FontSize = source.GetInt(nameof(Options.FontSize), defaultOptions.FontSize);
			options.FontFamiles = (source.GetString(nameof(Options.FontFamiles), string.Join(", ", defaultOptions.FontFamiles)) ?? "")
				.Split(',').Select(x=> x.Trim()).Where(x=> !string.IsNullOrWhiteSpace(x)).ToArray();
			options.TabSpaces = source.GetInt(nameof(Options.TabSpaces), defaultOptions.TabSpaces);
			return options;
		}

		public static IProperties ToProperties(this Options source)
		{
			var options = new OptionsProperties();
			options.OverrideProperties(source);
			return options;
		}

		public static void OverrideProperties(this IProperties options, Options source)
		{
			if (options == null || source == null)
			{
				return;
			}
			options.SetBoolean(nameof(Options.InLineStyles), source.InLineStyles);
			options.SetInt(nameof(Options.MaxHeight), source.MaxHeight);
			options.SetString(nameof(Options.BackgroundColor), source.BackgroundColor);
			options.SetInt(nameof(Options.FontSize), source.FontSize);
			options.SetInt(nameof(Options.TabSpaces), source.TabSpaces);
			options.SetString(nameof(Options.FontFamiles), string.Join(", ", source.FontFamiles));
		}
	}
}