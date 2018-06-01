using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
	public class SelectTable : Form
	{
		private IContainer components;
		private ListBox listBox1;
		private Label label1;
		private Button button1;
		private Button button2;
		public List<string> Items
		{
			get;
			set;
		}
		public int Selected
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
			this.listBox1 = new ListBox();
			this.label1 = new Label();
			this.button1 = new Button();
			this.button2 = new Button();
			base.SuspendLayout();
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 12;
			this.listBox1.Location = new Point(12, 30);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new Size(169, 148);
			this.listBox1.TabIndex = 0;
			this.listBox1.MouseDoubleClick += new MouseEventHandler(this.listBox1_MouseDoubleClick);
			this.label1.AutoSize = true;
			this.label1.Location = new Point(13, 12);
			this.label1.Name = "label1";
			this.label1.Size = new Size(53, 12);
			this.label1.TabIndex = 1;
			this.label1.Text = "索引目标";
			this.button1.Location = new Point(12, 192);
			this.button1.Name = "button1";
			this.button1.Size = new Size(75, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "确定";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new EventHandler(this.button1_Click);
			this.button2.Location = new Point(106, 192);
			this.button2.Name = "button2";
			this.button2.Size = new Size(75, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "取消";
			this.button2.UseVisualStyleBackColor = true;
			base.AcceptButton = this.button1;
			base.AutoScaleDimensions = new SizeF(6f, 12f);
			base.CancelButton = this.button2;
			base.ClientSize = new Size(194, 227);
			base.Controls.Add(this.button2);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.listBox1);
			base.Name = "SelectTable";
			this.Text = "SelectTable";
            base.Load += new EventHandler(this.SelectTable_Load);
			base.ResumeLayout(false);
            base.PerformLayout();
		}
		public SelectTable()
		{
			this.InitializeComponent();
			this.Items = new List<string>();
		}
		private void button1_Click(object sender, EventArgs e)
		{
			this.Selected = this.listBox1.SelectedIndex;
			base.DialogResult = DialogResult.OK;
			base.Close();
		}
		private void SelectTable_Load(object sender, EventArgs e)
        {
            this.button2.DialogResult = DialogResult.Cancel;
            base.AutoScaleMode = AutoScaleMode.Font;
			foreach (string current in this.Items)
			{
				this.listBox1.Items.Add(current);
			}
		}
		private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.Selected = this.listBox1.SelectedIndex;
			base.DialogResult = DialogResult.OK;
			base.Close();
		}
	}
}
