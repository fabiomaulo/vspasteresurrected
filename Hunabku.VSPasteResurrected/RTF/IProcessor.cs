namespace Hunabku.VSPasteResurrected.RTF
{
	internal interface IProcessor
	{
		void Open();

		void Close();

		void Text(char c);

		void Word(string word, int? param);

		void Symbol(char symbol);
	}
}