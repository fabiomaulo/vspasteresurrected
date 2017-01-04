using System;
using System.IO;
using System.Text;

namespace Hunabku.VSPasteResurrected.RTF
{
	public class HtmlRootProcessor : IProcessor
	{
		private int? background;
		private Encoding codepage = Encoding.Default;
		private int? color;
		private readonly ColorProcessor colors;
		private int depth;
		private int? nextBackground;
		private int? nextColor;
		private bool skipText;
		private readonly ProcessorStack stack;
		private readonly TextWriter writer;
		private readonly Options options;

		public HtmlRootProcessor(ProcessorStack stack, TextWriter writer, Options options)
		{
			if (options == null)
			{
				throw new ArgumentNullException(nameof(options));
			}
			colors = new ColorProcessor();
			this.stack = stack;
			this.writer = writer;
			this.options = options;
		}

		public void Open()
		{
			++depth;
		}

		public void Close()
		{
			--depth;
			if (depth != 0)
			{
				return;
			}
			nextColor = new int?();
			nextBackground = new int?();
			SyncColors(false);
		}

		public void Text(char c)
		{
			if (skipText)
			{
				skipText = false;
			}
			else
			{
				SyncColors(char.IsWhiteSpace(c));
				switch (c)
				{
					case '\t':
						writer.Write(options.TabToSpace);
						break;
					case '\r':
						writer.Write("<br/>");
						break;
					case '\n':
						writer.Write("\n");
						break;
					case '&':
						writer.Write("&amp;");
						break;
					case '<':
						writer.Write("&lt;");
						break;
					case '>':
						writer.Write("&gt;");
						break;
					case ' ':
						writer.Write("&nbsp;");
						break;
					default:
						writer.Write(c);
						break;
				}
			}
		}

		public void Word(string word, int? param)
		{
			switch (word)
			{
				case "ansicpg":
					if (param.HasValue)
					{
						codepage = Encoding.GetEncoding(param.Value);
					}
					break;
				case "stylesheet":
				case "fonttbl":
					stack.Push(new VoidProcessor());
					--depth;
					break;
				case "colortbl":
					stack.Push(colors);
					--depth;
					break;
				case "tab":
					Text('\t');
					break;
				case "par":
					Text('\r');
					Text('\n');
					break;
				case "cf":
					nextColor = param.HasValue && param.Value != 0 ? param.Value : new int?();
					break;
				case "highlight":
					nextBackground = param.HasValue && param.Value != 0 ? param.Value : new int?();
					break;
				case "u":
					Text((char) param.Value);
					skipText = true;
					break;
				case "'":
					Text(codepage.GetChars(new[]{(byte) param.Value})[0]);
					break;
			}
		}

		public void Symbol(char symbol)
		{
			switch (symbol)
			{
				case '*':
					stack.Push(new VoidProcessor());
					break;
				case '\\':
				case '{':
				case '}':
					Text(symbol);
					break;
			}
		}

		public static string FromRTF(string rtf, Options options = null)
		{
			using (var stringWriter = new StringWriter())
			{
				using (var stringReader = new StringReader(rtf))
				{
					var stack = new ProcessorStack();
					var htmlRootProcessor = new HtmlRootProcessor(stack, stringWriter, options ?? new Options());
					stack.Push(htmlRootProcessor);
					new Parser(new Scanner(stringReader), stack).Parse();
					return stringWriter.ToString();
				}
			}
		}

		private void SyncColors(bool bgOnly)
		{
			if (background == nextBackground && color == nextColor && !bgOnly)
			{
				return;
			}
			if (color.HasValue || background.HasValue)
			{
				writer.Write("</span>");
			}
			color = nextColor;
			background = nextBackground;
			if (color.HasValue || background.HasValue)
			{
				writer.Write("<span style=\"");
				if (color.HasValue)
				{
					writer.Write("color:");
					writer.Write(colors.CssColor(color.Value));
				}
				if (background.HasValue)
				{
					if (color.HasValue)
					{
						writer.Write(';');
					}
					writer.Write("background:");
					writer.Write(colors.CssColor(background.Value));
				}
				writer.Write("\">");
			}
		}
	}
}