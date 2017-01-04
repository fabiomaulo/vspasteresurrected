using System;
using System.Windows.Forms;
using Hunabku.VSPasteResurrected.OptionEditors;
using Hunabku.VSPasteResurrected.RTF;
using OpenLiveWriter.Api;

namespace Hunabku.VSPasteResurrected
{
	[WriterPlugin("DC526D95-E80C-4E6C-B873-5B2F06F95039", "VS Paste", Description = "Easily transfer syntax highlighted source code from Visual Studio to elegant HTML in Windows Live Writer.", ImagePath = "VsPaste20_18.png", HasEditableOptions = true)]
	[InsertableContentSource("Paste from Visual Studio", SidebarText = "from Visual Studio")]
	public class VsPasteR : ContentSource
	{
		private Options options;
		private IProperties optionsProperties;

		public VsPasteR()
		{
			options= new Options();
		}

		public override DialogResult CreateContent(IWin32Window dialogOwner, ref string newContent)
		{
			try
			{
				if (Clipboard.ContainsData(DataFormats.Rtf))
				{
					var html = HtmlRootProcessor.FromRTF((string)Clipboard.GetData(DataFormats.Rtf), options);
					newContent = $"<div class=\"olwVSPaste\" {GetContainerStyles()}><div {GetCodeStyles()}>{html}</div></div>";
					return DialogResult.OK;
				}
			}
			catch (Exception e)
			{
				MessageBox.Show("Could not convert RTF content:" + e.Message, "VS Paste Problem", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			return DialogResult.Cancel;
		}

		public override void EditOptions(IWin32Window dialogOwner)
		{
			using (var optionForm = new FormDefaultOptions(new OptionsViewModel(options)))
			{
				optionForm.ShowDialog(dialogOwner);
				optionsProperties.OverrideProperties(options);
			}
		}
		
		public override void Initialize(IProperties pluginOptions)
		{
			base.Initialize(pluginOptions);
			options = pluginOptions.ToOptions();
			optionsProperties = pluginOptions;
		}

		private string GetContainerStyles()
		{
			if (!options.InLineStyles)
			{
				return null;
			}
			return $"style=\"border: #000080 1px solid; color: black; font-family: {string.Join(", ", options.FontFamiles)}; font-size: {options.FontSize}pt;\"";
		}

		private string GetCodeStyles()
		{
			if (!options.InLineStyles)
			{
				return null;
			}
			return $"style=\"background-color: {options.BackgroundColor}; max-height: {options.MaxHeight}px; overflow: auto; padding: 2px 5px; white-space: nowrap;\"";
		}
	}
}