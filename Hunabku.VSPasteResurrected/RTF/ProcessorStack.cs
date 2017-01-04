using System.Collections.Generic;

namespace Hunabku.VSPasteResurrected.RTF
{
	public class ProcessorStack : IProcessor
	{
		private readonly Stack<IProcessor> stack = new Stack<IProcessor>();

		public void Open()
		{
			if (stack.Count == 0)
			{
				return;
			}
			stack.Push(stack.Peek());
			stack.Peek().Open();
		}

		public void Close()
		{
			if (stack.Count == 0)
			{
				return;
			}
			stack.Pop().Close();
		}

		public void Text(char c)
		{
			if (stack.Count == 0)
			{
				return;
			}
			stack.Peek().Text(c);
		}

		public void Word(string word, int? param)
		{
			if (stack.Count == 0)
			{
				return;
			}
			stack.Peek().Word(word, param);
		}

		public void Symbol(char symbol)
		{
			if (stack.Count == 0)
			{
				return;
			}
			stack.Peek().Symbol(symbol);
		}

		public void Push(IProcessor processor)
		{
			if (stack.Count != 0)
			{
				stack.Pop();
			}
			stack.Push(processor);
		}
	}
}