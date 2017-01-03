using System.Windows.Forms;
using Hunabku.VSPasteResurrected.RTF;
using OpenLiveWriter.Api;

namespace Hunabku.VSPasteResurrected
{
	[WriterPlugin("DC526D95-E80C-4E6C-B873-5B2F06F95039", "VS Paste", Description = "Easily transfer syntax highlighted source code from Visual Studio to elegant HTML in Windows Live Writer.", ImagePath = "icon.png")]
	[InsertableContentSource("Paste from Visual Studio", SidebarText = "from Visual Studio")]
	public class VsPasteR : ContentSource
	{
		public override DialogResult CreateContent(IWin32Window dialogOwner, ref string newContent)
		{
			try
			{
				if (Clipboard.ContainsData(DataFormats.Rtf))
				{
					newContent = "<pre class=\"code\">" + Undent(HTMLRootProcessor.FromRTF((string)Clipboard.GetData(DataFormats.Rtf))) + "</pre>";
					return DialogResult.OK;
				}
			}
			catch
			{
				MessageBox.Show("VS Paste could not convert that content.", "VS Paste Problem", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			return DialogResult.Cancel;
		}

		public static string Undent(string s)
		{
			string[] strArray = s.Split('\n');
			int startIndex = int.MaxValue;
			foreach (string str in strArray)
			{
				for (int index = 0; index < str.Length && index < startIndex; ++index)
				{
					if (!char.IsWhiteSpace(str[index]))
					{
						startIndex = index;
						break;
					}
				}
			}
			for (int index = 0; index < strArray.Length; ++index)
			{
				if (strArray[index].Length > startIndex)
					strArray[index] = strArray[index].Substring(startIndex);
			}
			return string.Join("\n", strArray);
		}
	}
}