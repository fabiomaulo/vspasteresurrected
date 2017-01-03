using System.IO;
using System.Text;

namespace Hunabku.VSPasteResurrected.RTF
{
	internal class HTMLRootProcessor : IProcessor
	{
		private bool skipText = false;
		private Encoding codepage = Encoding.Default;
		private int depth = 0;
		private ProcessorStack stack;
		private TextWriter writer;
		private ColorProcessor colors;
		private int? color;
		private int? background;
		private int? nextColor;
		private int? nextBackground;

		public HTMLRootProcessor(ProcessorStack stack, TextWriter writer)
		{
			this.colors = new ColorProcessor();
			this.stack = stack;
			this.writer = writer;
		}

		public static string FromRTF(string rtf)
		{
			using (StringWriter stringWriter = new StringWriter())
			{
				using (StringReader stringReader = new StringReader(rtf))
				{
					ProcessorStack stack = new ProcessorStack();
					HTMLRootProcessor htmlRootProcessor = new HTMLRootProcessor(stack, (TextWriter)stringWriter);
					stack.Push((IProcessor)htmlRootProcessor);
					new Parser(new Scanner((TextReader)stringReader), (IProcessor)stack).Parse();
					return stringWriter.ToString();
				}
			}
		}

		public void Open()
		{
			++this.depth;
		}

		public void Close()
		{
			--this.depth;
			if (this.depth != 0)
				return;
			this.nextColor = new int?();
			this.nextBackground = new int?();
			this.SyncColors(false);
		}

		public void Text(char c)
		{
			if (this.skipText)
			{
				this.skipText = false;
			}
			else
			{
				this.SyncColors(char.IsWhiteSpace(c));
				switch (c)
				{
					case '\t':
						this.writer.Write("    ");
						break;
					case '\n':
						break;
					case '\r':
						break;
					case '&':
						this.writer.Write("&amp;");
						break;
					case '<':
						this.writer.Write("&lt;");
						break;
					case '>':
						this.writer.Write("&gt;");
						break;
					default:
						this.writer.Write(c);
						break;
				}
			}
		}

		private void SyncColors(bool bgOnly)
		{
			int? nullable = this.background;
			int? nextBackground = this.nextBackground;
			int num;
			if ((nullable.GetValueOrDefault() != nextBackground.GetValueOrDefault() ? 1 : (nullable.HasValue != nextBackground.HasValue ? 1 : 0)) == 0)
			{
				nullable = this.color;
				int? nextColor = this.nextColor;
				num = (nullable.GetValueOrDefault() != nextColor.GetValueOrDefault() ? 1 : (nullable.HasValue != nextColor.HasValue ? 1 : 0)) == 0 ? 1 : (bgOnly ? 1 : 0);
			}
			else
				num = 0;
			if (num != 0)
				return;
			if (this.color.HasValue || this.background.HasValue)
				this.writer.Write("</span>");
			this.color = this.nextColor;
			this.background = this.nextBackground;
			if (this.color.HasValue || this.background.HasValue)
			{
				this.writer.Write("<span style=\"");
				if (this.color.HasValue)
				{
					this.writer.Write("color:");
					this.writer.Write(this.colors.CssColor(this.color.Value));
				}
				if (this.background.HasValue)
				{
					if (this.color.HasValue)
						this.writer.Write(';');
					this.writer.Write("background:");
					this.writer.Write(this.colors.CssColor(this.background.Value));
				}
				this.writer.Write("\">");
			}
		}

		public void Word(string word, int? param)
		{
			switch (word)
			{
				case "ansicpg":
					if (!param.HasValue)
						break;
					this.codepage = Encoding.GetEncoding(param.Value);
					break;
				case "stylesheet":
				case "fonttbl":
					this.stack.Push((IProcessor)new VoidProcessor());
					--this.depth;
					break;
				case "colortbl":
					this.stack.Push((IProcessor)this.colors);
					--this.depth;
					break;
				case "tab":
					this.Text('\t');
					break;
				case "par":
					this.writer.Write("\r\n");
					break;
				case "cf":
					int num1;
					if (param.HasValue)
					{
						int? nullable = param;
						num1 = (nullable.GetValueOrDefault() != 0 ? 1 : (!nullable.HasValue ? 1 : 0)) == 0 ? 1 : 0;
					}
					else
						num1 = 1;
					if (num1 == 0)
					{
						this.nextColor = new int?(param.Value);
						break;
					}
					this.nextColor = new int?();
					break;
				case "highlight":
					int num2;
					if (param.HasValue)
					{
						int? nullable = param;
						num2 = (nullable.GetValueOrDefault() != 0 ? 1 : (!nullable.HasValue ? 1 : 0)) == 0 ? 1 : 0;
					}
					else
						num2 = 1;
					if (num2 == 0)
					{
						this.nextBackground = new int?(param.Value);
						break;
					}
					this.nextBackground = new int?();
					break;
				case "u":
					this.Text((char)param.Value);
					this.skipText = true;
					break;
				case "'":
					this.Text(this.codepage.GetChars(new byte[1]
					{
					(byte) param.Value
					})[0]);
					break;
			}
		}

		public void Symbol(char symbol)
		{
			switch (symbol)
			{
				case '*':
					this.stack.Push((IProcessor)new VoidProcessor());
					break;
				case '\\':
				case '{':
				case '}':
					this.Text(symbol);
					break;
			}
		}
	}
}