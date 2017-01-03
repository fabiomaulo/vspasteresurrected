namespace Hunabku.VSPasteResurrected.RTF
{
	public class VoidProcessor: IProcessor
	{
		public void Open() {}
		public void Close() {}
		public void Text(char c) {}
		public void Word(string word, int? param) {}
		public void Symbol(char symbol) {}
	}
}