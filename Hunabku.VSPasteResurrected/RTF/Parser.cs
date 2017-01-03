using System.Globalization;

namespace Hunabku.VSPasteResurrected.RTF
{
	internal struct Parser
	{
		private Scanner scanner;
		private readonly IProcessor processor;

		public Parser(Scanner scanner, IProcessor processor)
		{
			this.scanner = scanner;
			this.processor = processor;
		}

		public void Parse()
		{
			while (scanner.Peek != -1)
			{
				ParseItem();
			}
		}

		private void ParseItem()
		{
			switch (scanner.Peek)
			{
				case -1:
					break;
				case 92:
					ParseControl();
					break;
				case 123:
					ParseGroup();
					break;
				default:
					ParseText();
					break;
			}
		}

		private void ParseControl()
		{
			scanner.Take('\\');
			if (scanner.Peek == 39)
			{
				scanner.Take('\'');
				scanner.Mark();
				scanner.Take();
				scanner.Take();
				processor.Word("'", int.Parse(scanner.Cut(), NumberStyles.HexNumber));
			}
			else if ((scanner.Peek <= 122) && (scanner.Peek >= 97))
			{
				scanner.Mark();
				do
				{
					scanner.Take();
				} while ((scanner.Peek <= 122) && (scanner.Peek >= 97));
				var word = scanner.Cut();
				var nullable = new int?();
				if ((scanner.Peek == 45) || ((scanner.Peek <= 57) && (scanner.Peek >= 48)))
				{
					scanner.Mark();
					scanner.Take();
					while ((scanner.Peek <= 57) && (scanner.Peek >= 48))
					{
						scanner.Take();
					}
					nullable = int.Parse(scanner.Cut());
				}
				if (scanner.Peek == 32)
				{
					scanner.Take();
				}
				processor.Word(word, nullable);
			}
			else
			{
				processor.Symbol((char) scanner.Take());
			}
		}

		private void ParseGroup()
		{
			scanner.Take('{');
			processor.Open();
			while (scanner.Peek != 125)
			{
				ParseItem();
			}
			scanner.Take('}');
			processor.Close();
		}

		private void ParseText()
		{
			while (true)
			{
				switch (scanner.Peek)
				{
					case -1:
						return;
					case 92:
						return;
					case 123:
						return;
					case 125:
						return;
					default:
						processor.Text((char) scanner.Take());
						continue;
				}
			}
		}
	}
}