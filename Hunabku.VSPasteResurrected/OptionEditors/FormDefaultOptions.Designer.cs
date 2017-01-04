namespace Hunabku.VSPasteResurrected.OptionEditors
{
	partial class FormDefaultOptions
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.inTabSpaces = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.inInLineStyles = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.inMaxHeight = new System.Windows.Forms.NumericUpDown();
			this.inFontSize = new System.Windows.Forms.NumericUpDown();
			this.inFontFamiles = new System.Windows.Forms.TextBox();
			this.inBackgroundColor = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.inTabSpaces)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.inMaxHeight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.inFontSize)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 242);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(445, 37);
			this.panel1.TabIndex = 0;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.AutoSize = true;
			this.btnCancel.Location = new System.Drawing.Point(358, 3);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 27);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.AutoSize = true;
			this.btnSave.Location = new System.Drawing.Point(277, 3);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 27);
			this.btnSave.TabIndex = 0;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = true;
			// 
			// inTabSpaces
			// 
			this.inTabSpaces.Location = new System.Drawing.Point(263, 7);
			this.inTabSpaces.Name = "inTabSpaces";
			this.inTabSpaces.Size = new System.Drawing.Size(66, 22);
			this.inTabSpaces.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(245, 17);
			this.label1.TabIndex = 2;
			this.label1.Text = "Number of spaces to represent a Tab";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(135, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "Use inline css styles";
			// 
			// inInLineStyles
			// 
			this.inInLineStyles.AutoSize = true;
			this.inInLineStyles.Location = new System.Drawing.Point(263, 37);
			this.inInLineStyles.Name = "inInLineStyles";
			this.inInLineStyles.Size = new System.Drawing.Size(18, 17);
			this.inInLineStyles.TabIndex = 6;
			this.inInLineStyles.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.inBackgroundColor);
			this.groupBox1.Controls.Add(this.inFontFamiles);
			this.groupBox1.Controls.Add(this.inFontSize);
			this.groupBox1.Controls.Add(this.inMaxHeight);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Location = new System.Drawing.Point(15, 77);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(418, 149);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Inline css Styles";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 26);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(121, 17);
			this.label3.TabIndex = 4;
			this.label3.Text = "Background Color";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 56);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(67, 17);
			this.label4.TabIndex = 5;
			this.label4.Text = "Font Size";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 86);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(78, 17);
			this.label5.TabIndex = 6;
			this.label5.Text = "Max Height";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 116);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(88, 17);
			this.label6.TabIndex = 7;
			this.label6.Text = "Font Familes";
			// 
			// inMaxHeight
			// 
			this.inMaxHeight.Location = new System.Drawing.Point(139, 84);
			this.inMaxHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.inMaxHeight.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.inMaxHeight.Name = "inMaxHeight";
			this.inMaxHeight.Size = new System.Drawing.Size(66, 22);
			this.inMaxHeight.TabIndex = 8;
			this.inMaxHeight.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			// 
			// inFontSize
			// 
			this.inFontSize.Location = new System.Drawing.Point(139, 54);
			this.inFontSize.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
			this.inFontSize.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
			this.inFontSize.Name = "inFontSize";
			this.inFontSize.Size = new System.Drawing.Size(66, 22);
			this.inFontSize.TabIndex = 9;
			this.inFontSize.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
			// 
			// inFontFamiles
			// 
			this.inFontFamiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.inFontFamiles.Location = new System.Drawing.Point(139, 113);
			this.inFontFamiles.Name = "inFontFamiles";
			this.inFontFamiles.Size = new System.Drawing.Size(273, 22);
			this.inFontFamiles.TabIndex = 10;
			// 
			// inBackgroundColor
			// 
			this.inBackgroundColor.Location = new System.Drawing.Point(139, 23);
			this.inBackgroundColor.Name = "inBackgroundColor";
			this.inBackgroundColor.Size = new System.Drawing.Size(127, 22);
			this.inBackgroundColor.TabIndex = 11;
			// 
			// FormDefaultOptions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(445, 279);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.inInLineStyles);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.inTabSpaces);
			this.Controls.Add(this.panel1);
			this.MinimumSize = new System.Drawing.Size(381, 325);
			this.Name = "FormDefaultOptions";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Default options";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.inTabSpaces)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.inMaxHeight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.inFontSize)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.NumericUpDown inTabSpaces;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox inInLineStyles;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown inFontSize;
		private System.Windows.Forms.NumericUpDown inMaxHeight;
		private System.Windows.Forms.TextBox inBackgroundColor;
		private System.Windows.Forms.TextBox inFontFamiles;
	}
}