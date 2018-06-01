using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
	public class NewData : Form
	{
		private IContainer components;
		private Label label1;
		private TextBox textBox1;
		private Button button1;
		private Button button2;
		public string TemplateName
		{
			get;
			set;
		}
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
			this.label1 = new Label();
			this.textBox1 = new TextBox();
			this.button1 = new Button();
			this.button2 = new Button();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Location = new Point(14, 22);
			this.label1.Name = "label1";
			this.label1.Size = new Size(41, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "模板名";
			this.textBox1.Location = new Point(73, 19);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new Size(154, 21);
			this.textBox1.TabIndex = 1;
			this.button1.Location = new Point(16, 66);
			this.button1.Name = "button1";
			this.button1.Size = new Size(75, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "确定";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new EventHandler(this.button1_Click);
			this.button2.DialogResult = DialogResult.Cancel;
			this.button2.Location = new Point(152, 66);
			this.button2.Name = "button2";
			this.button2.Size = new Size(75, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "取消";
			this.button2.UseVisualStyleBackColor = true;
			base.AcceptButton = this.button1;
			base.AutoScaleDimensions = new SizeF(6f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.CancelButton = this.button2;
			base.ClientSize = new Size(242, 99);
			base.Controls.Add(this.button2);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.textBox1);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "NewData";
			this.Text = "NewData";
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		public NewData()
		{
			this.InitializeComponent();
		}
		private void button1_Click(object sender, EventArgs e)
		{
			this.TemplateName = this.textBox1.Text;
			base.DialogResult = DialogResult.OK;
			base.Close();
		}
	}
}
