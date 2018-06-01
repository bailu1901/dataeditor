using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
	public class Messages : Form
	{
		private IContainer components;
		private RichTextBox richTextBox1;
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
			this.richTextBox1 = new RichTextBox();
			base.SuspendLayout();
			this.richTextBox1.Dock = DockStyle.Fill;
			this.richTextBox1.Location = new Point(0, 0);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new Size(292, 273);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = "";
			base.AutoScaleDimensions = new SizeF(6f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(292, 273);
			base.Controls.Add(this.richTextBox1);
			base.Name = "Messages";
			this.Text = "Messages";
			base.ResumeLayout(false);
		}
		public void AddMessage(string str)
		{
			this.richTextBox1.AppendText(str);
		}
		public Messages()
		{
			this.InitializeComponent();
		}
	}
}
