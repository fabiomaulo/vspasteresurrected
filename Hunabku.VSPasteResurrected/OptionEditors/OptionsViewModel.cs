using System.Linq;
using Hunabku.VSPasteResurrected.RTF;

namespace Hunabku.VSPasteResurrected.OptionEditors
{
	public class OptionsViewModel: ViewModelBase
	{
		private readonly Options options;
		private bool wasChanged;
		private readonly RelayCommand saveCommand;
		private readonly RelayCommand cancelCommand;
		private bool inLineStyles;
		private int tabSpaces;
		private int maxHeight;
		private string backgroundColor;
		private int fontSize;
		private string fontFamiles;

		public OptionsViewModel(Options options)
		{
			this.options = options;
			Initialize();
			saveCommand = new RelayCommand(()=> SaveAndClose(), ()=> wasChanged);
			cancelCommand= new RelayCommand(() => Close());
		}

		private void Initialize()
		{
			inLineStyles = options.InLineStyles;
			tabSpaces = options.TabSpaces;
			maxHeight = options.MaxHeight;
			backgroundColor = options.BackgroundColor;
			fontSize = options.FontSize;
			fontFamiles = string.Join(", ", options.FontFamiles);
		}

		private void SaveAndClose()
		{
			options.InLineStyles = InLineStyles;
			options.TabSpaces = TabSpaces;
			options.MaxHeight = MaxHeight;
			options.BackgroundColor = BackgroundColor;
			options.FontSize = FontSize;
			options.FontFamiles = (FontFamiles ?? "").Split(',').Select(x => x.Trim()).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
			Close();
		}

		public int TabSpaces
		{
			get { return tabSpaces; }
			set { SetProperty(ref tabSpaces, value); }
		}

		public bool InLineStyles
		{
			get { return inLineStyles; }
			set { SetProperty(ref inLineStyles, value); }
		}

		public int MaxHeight
		{
			get { return maxHeight; }
			set { SetProperty(ref maxHeight, value); }
		}

		public string BackgroundColor
		{
			get { return backgroundColor; }
			set { SetProperty(ref backgroundColor, value); }
		}

		public int FontSize
		{
			get { return fontSize; }
			set { SetProperty(ref fontSize, value); }
		}

		public string FontFamiles
		{
			get { return fontFamiles; }
			set { SetProperty(ref fontFamiles, value); }
		}

		public ICommand SaveCommand => saveCommand;
		public ICommand CancelCommand => cancelCommand;

		protected override bool SetProperty<TProperty>(ref TProperty fieldOfProperty, TProperty value, string propertyName = null)
		{
			var result = base.SetProperty(ref fieldOfProperty, value, propertyName);
			if (result)
			{
				wasChanged = true;
				saveCommand.CheckCanExecute();
			}
			return result;
		}
	}
}