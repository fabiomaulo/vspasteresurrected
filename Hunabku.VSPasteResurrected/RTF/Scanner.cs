using System.Diagnostics;
using System.IO;
using System.Text;

namespace Hunabku.VSPasteResurrected.RTF
{
	internal struct Scanner
	{
		private readonly TextReader reader;
		private StringBuilder sb;
		private int? peekCache;

		public int Peek
		{
			get
			{
				if (!peekCache.HasValue)
				{
					peekCache = reader.Peek();
				}
				return peekCache.Value;
			}
		}

		public Scanner(TextReader reader)
		{
			this.reader = reader;
			sb = null;
			peekCache = new int?();
		}

		public int Take()
		{
			peekCache = new int?();
			var num = reader.Read();
			sb?.Append((char) num);
			return num;
		}

		public void Take(char check)
		{
			Debug.Assert(check == (ushort) Take());
		}

		public void Mark()
		{
			sb = new StringBuilder();
		}

		public string Cut()
		{
			var str = sb.ToString();
			sb = null;
			return str;
		}
	}
}