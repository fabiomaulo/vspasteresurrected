using System.ComponentModel;

namespace Hunabku.VSPasteResurrected.OptionEditors
{
	public interface ICommand : INotifyPropertyChanged
	{
		bool CanExecute { get; }
		void Execute();
	}
}