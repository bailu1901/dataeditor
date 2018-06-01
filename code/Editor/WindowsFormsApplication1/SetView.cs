using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
	public class SetView : Form
	{
		private IContainer components;
		private TableLayoutPanel tableLayoutPanel1;
		private Panel panel1;
		private Button Cancel;
		private Button OK;
		private FlowLayoutPanel flowLayoutPanel1;
		public List<string> Choices
		{
			get;
			set;
		}
		public List<bool> Choosed
		{
			get;
			set;
		}
		public Point Position
		{
			get;
			set;
		}
		public SetView()
		{
			this.InitializeComponent();
			this.Choices = new List<string>();
			this.Choosed = new List<bool>();
		}
		private void OK_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.flowLayoutPanel1.Controls.Count; i++)
			{
				this.Choosed[i] = ((CheckBox)this.flowLayoutPanel1.Controls[i]).Checked;
			}
			base.DialogResult = DialogResult.OK;
			base.Close();
		}
		private void Set_Load(object sender, EventArgs e)
		{
			for (int i = 0; i < this.Choices.Count; i++)
			{
				CheckBox checkBox = new CheckBox();
				checkBox.Checked = this.Choosed[i];
				checkBox.Text = this.Choices[i];
				this.flowLayoutPanel1.Controls.Add(checkBox);
			}
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
			this.tableLayoutPanel1 = new TableLayoutPanel();
			this.panel1 = new Panel();
			this.Cancel = new Button();
			this.OK = new Button();
			this.flowLayoutPanel1 = new FlowLayoutPanel();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
			this.tableLayoutPanel1.Dock = DockStyle.Fill;
			this.tableLayoutPanel1.Location = new Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
			this.tableLayoutPanel1.Size = new Size(224, 316);
			this.tableLayoutPanel1.TabIndex = 0;
			this.panel1.Controls.Add(this.Cancel);
			this.panel1.Controls.Add(this.OK);
			this.panel1.Dock = DockStyle.Fill;
			this.panel1.Location = new Point(3, 289);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(218, 24);
			this.panel1.TabIndex = 0;
			this.Cancel.DialogResult = DialogResult.Cancel;
			this.Cancel.Location = new Point(134, 0);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new Size(75, 23);
			this.Cancel.TabIndex = 0;
			this.Cancel.Text = "取消";
			this.Cancel.UseVisualStyleBackColor = true;
			this.OK.Location = new Point(3, 1);
			this.OK.Name = "OK";
			this.OK.Size = new Size(75, 23);
			this.OK.TabIndex = 0;
			this.OK.Text = "确认";
			this.OK.UseVisualStyleBackColor = true;
			this.OK.Click += new EventHandler(this.OK_Click);
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.Dock = DockStyle.Fill;
			this.flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new Point(3, 3);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new Size(218, 280);
			this.flowLayoutPanel1.TabIndex = 1;
			base.AcceptButton = this.OK;
			base.AutoScaleDimensions = new SizeF(6f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.AutoSize = true;
			base.CancelButton = this.Cancel;
			base.ClientSize = new Size(224, 316);
			base.Controls.Add(this.tableLayoutPanel1);
			base.Name = "SetView";
			this.Text = "Set";
			base.Load += new EventHandler(this.Set_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.panel1.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
