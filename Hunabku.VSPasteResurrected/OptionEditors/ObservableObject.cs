using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Hunabku.VSPasteResurrected.OptionEditors
{
	public class ObservableObject: INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		protected virtual bool SetProperty<TProperty>(ref TProperty fieldOfProperty, TProperty value, [CallerMemberName] string propertyName = null)
		{
			if (EqualityComparer<TProperty>.Default.Equals(fieldOfProperty, value))
			{
				return false;
			}
			fieldOfProperty = value;
			OnPropertyChanged(propertyName);
			return true;
		}
	}
}