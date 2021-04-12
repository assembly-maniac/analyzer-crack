namespace AnalyzerWin
{
	partial class AnalyzerWin
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
			this.btnVerify = new System.Windows.Forms.Button();
			this.lstBetaTick = new System.Windows.Forms.ListBox();
			this.lstAbraca = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// btnVerify
			// 
			this.btnVerify.Location = new System.Drawing.Point(87, 12);
			this.btnVerify.Name = "btnVerify";
			this.btnVerify.Size = new System.Drawing.Size(150, 53);
			this.btnVerify.TabIndex = 0;
			this.btnVerify.Text = "Verify";
			this.btnVerify.UseVisualStyleBackColor = true;
			this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
			// 
			// lstBetaTick
			// 
			this.lstBetaTick.FormattingEnabled = true;
			this.lstBetaTick.Location = new System.Drawing.Point(12, 92);
			this.lstBetaTick.Name = "lstBetaTick";
			this.lstBetaTick.Size = new System.Drawing.Size(140, 186);
			this.lstBetaTick.TabIndex = 2;
			// 
			// lstAbraca
			// 
			this.lstAbraca.FormattingEnabled = true;
			this.lstAbraca.Location = new System.Drawing.Point(172, 92);
			this.lstAbraca.Name = "lstAbraca";
			this.lstAbraca.Size = new System.Drawing.Size(140, 186);
			this.lstAbraca.TabIndex = 3;
			// 
			// AnalyzerWin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(324, 296);
			this.Controls.Add(this.lstAbraca);
			this.Controls.Add(this.lstBetaTick);
			this.Controls.Add(this.btnVerify);
			this.Name = "AnalyzerWin";
			this.Text = "Analyzer";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnVerify;
		private System.Windows.Forms.ListBox lstBetaTick;
		private System.Windows.Forms.ListBox lstAbraca;
	}
}

