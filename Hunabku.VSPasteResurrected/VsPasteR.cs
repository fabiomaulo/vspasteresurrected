using System.Windows.Forms;
using Hunabku.VSPasteResurrected.RTF;
using OpenLiveWriter.Api;

namespace Hunabku.VSPasteResurrected
{
	[WriterPlugin("DC526D95-E80C-4E6C-B873-5B2F06F95039", "VS Paste", Description = "Easily transfer syntax highlighted source code from Visual Studio to elegant HTML in Windows Live Writer.", ImagePath = "VsPaste20_18.png")]
	[InsertableContentSource("Paste from Visual Studio", SidebarText = "from Visual Studio")]
	public class VsPasteR : ContentSource
	{
		public override DialogResult CreateContent(IWin32Window dialogOwner, ref string newContent)
		{
			try
			{
				if (Clipboard.ContainsData(DataFormats.Rtf))
				{
					var html = HTMLRootProcessor.FromRTF((string)Clipboard.GetData(DataFormats.Rtf));
					newContent = $"<div class=\"olwVSPaste\"><div>{html}</div></div>";
					return DialogResult.OK;
				}
			}
			catch
			{
				MessageBox.Show("VS Paste could not convert that content.", "VS Paste Problem", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			return DialogResult.Cancel;
		}
	}

	/*
.olwVSPaste {
border: #000080 1px solid; 
color: black; 
font-family: 'Courier New', Courier, Monospace; 
font-size: 10pt;
}
.olwVSPaste div {
background-color: white; 
max-height: 500px; 
overflow: auto; 
padding: 2px 5px; 
white-space: nowrap;
}	 
	 */
}