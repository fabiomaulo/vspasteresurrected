using System.Windows.Forms;

namespace Hunabku.VSPasteResurrected.OptionEditors
{
	public partial class FormDefaultOptions : Form
	{
		public FormDefaultOptions(OptionsViewModel model)
		{
			InitializeComponent();
			this.Bind(model);
			btnSave.Bind(model.SaveCommand);
			btnCancel.Bind(model.CancelCommand);
			inTabSpaces.BindValue(model, m=> m.TabSpaces);
			inInLineStyles.BindValue(model, m=> m.InLineStyles);
			inBackgroundColor.BindValue(model, m=> m.BackgroundColor);
			inFontSize.BindValue(model, m=> m.FontSize);
			inMaxHeight.BindValue(model,m=> m.MaxHeight);
			inFontFamiles.BindValue(model, m=> m.FontFamiles);
			groupBox1.DataBindings.Add("Enabled", model, nameof(OptionsViewModel.InLineStyles));
		}
	}
}
