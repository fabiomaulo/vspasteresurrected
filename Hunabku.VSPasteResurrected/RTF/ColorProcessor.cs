using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace Hunabku.VSPasteResurrected.RTF
{
	internal class ColorProcessor : IProcessor
	{
		private static readonly Dictionary<int, string> namedColors = new Dictionary<int, string>();
		private readonly List<Color> colors = new List<Color>();
		private Color current = Color.Black;

		static ColorProcessor()
		{
			foreach (var property in typeof(Color).GetProperties(BindingFlags.Static | BindingFlags.Public))
			{
				if (property.PropertyType == typeof(Color))
				{
					namedColors[((Color) property.GetValue(null, null)).ToArgb()] = property.Name;
				}
			}
		}

		public void Open() {}

		public void Close() {}

		public void Text(char c)
		{
			if (c != 59)
			{
				return;
			}
			colors.Add(current);
			current = Color.Black;
		}

		public void Word(string word, int? param)
		{
			if (!param.HasValue)
			{
				return;
			}
			switch (word)
			{
				case "red":
					current = Color.FromArgb(param.Value, current.G, current.B);
					break;
				case "green":
					current = Color.FromArgb(current.R, param.Value, current.B);
					break;
				case "blue":
					current = Color.FromArgb(current.R, current.G, param.Value);
					break;
			}
		}

		public void Symbol(char symbol) {}

		public string CssColor(int i)
		{
			if ((i < 0) || (i >= colors.Count))
			{
				return "black";
			}
			string str;
			var color = colors[i];
			if (namedColors.TryGetValue(color.ToArgb(), out str) && (str.Length <= 7))
			{
				return str.ToLower();
			}
			return $"#{color.R:x2}{color.G:x2}{color.B:x2}";
		}
	}
}