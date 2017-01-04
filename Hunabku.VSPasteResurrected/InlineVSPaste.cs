using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Hunabku.VSPasteResurrected.RTF;
using OpenLiveWriter.Api;

namespace Hunabku.VSPasteResurrected
{
	[WriterPlugin("5C3A30AC-50D2-41F4-81D0-CE8898A1F095", "Inline VS Paste", Description = "Easily transfer syntax highlighted source code from Visual Studio to elegant HTML in Windows Live Writer.", ImagePath = "VsPasteInline20_18.png")]
	[InsertableContentSource("Inline Paste from Visual Studio", SidebarText = "inline from Visual Studio")]
	public class InlineVsPaste: ContentSource
	{
		private static readonly Regex rtfNewlineRegex= new Regex("\\\\par }$");
		private static readonly Regex rtfFontRegex = new Regex("\\\\fonttbl.*? (.+?);");
		public override DialogResult CreateContent(IWin32Window dialogOwner, ref string newContent)
		{
			try
			{
				if (Clipboard.ContainsData(DataFormats.Rtf))
				{
					string rtf = (string) Clipboard.GetData(DataFormats.Rtf);
					string rtfNoNewline = rtfNewlineRegex.Replace(rtf, "}");
					string fontName = rtfFontRegex.Match(rtf).Groups[1].Value;
					string html = HtmlRootProcessor.FromRTF(rtfNoNewline);

					newContent = "<font face=\"" + fontName + ", 'Courier New', Courier, Monospace\">" + html + "</font>";
					if (newContent.Contains("\n"))
						newContent = $"<pre style=\"word-wrap: break-word; white-space: pre-wrap\">{newContent}</pre><br/>";
					else
						newContent += " ";
					return DialogResult.OK;
				}
			}
			catch (Exception e)
			{
				MessageBox.Show("Could not convert RTF content:"+e.Message, "VS Paste Problem", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			return DialogResult.Cancel;
		}

	}
}