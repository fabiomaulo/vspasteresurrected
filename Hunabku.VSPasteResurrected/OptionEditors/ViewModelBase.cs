using System;

namespace Hunabku.VSPasteResurrected.OptionEditors
{
	public class ViewModelBase : ObservableObject, IDisposable
	{
		public void Dispose()
		{
			Dispose(true);
		}

		public event EventHandler CloseRequest;

		public virtual bool CanClose()
		{
			return true;
		}

		protected virtual void OnCloseRequest()
		{
			CloseRequest?.Invoke(this, EventArgs.Empty);
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		public void Close()
		{
			OnCloseRequest();
		}
	}
}