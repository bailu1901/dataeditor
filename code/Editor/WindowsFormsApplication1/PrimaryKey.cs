using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
	public class PrimaryKey : Form
	{
		private IContainer components;
		private GroupBox groupBox1;
		private TableLayoutPanel tableLayoutPanel1;
		private Panel panel1;
		private Button button2;
		private Button button1;
		private FlowLayoutPanel flowLayoutPanel1;
		private FlowLayoutPanel flowLayoutPanel2;
		public List<string> Keys
		{
			get;
			set;
		}
		public List<string> Values
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
			this.groupBox1 = new GroupBox();
			this.tableLayoutPanel1 = new TableLayoutPanel();
			this.panel1 = new Panel();
			this.button1 = new Button();
			this.button2 = new Button();
			this.flowLayoutPanel1 = new FlowLayoutPanel();
			this.flowLayoutPanel2 = new FlowLayoutPanel();
			this.groupBox1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.groupBox1.Controls.Add(this.tableLayoutPanel1);
			this.groupBox1.Dock = DockStyle.Fill;
			this.groupBox1.Location = new Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(240, 228);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "主键";
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35.04274f));
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64.95727f));
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 0);
			this.tableLayoutPanel1.Dock = DockStyle.Fill;
			this.tableLayoutPanel1.Location = new Point(3, 17);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 82.69231f));
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 17.30769f));
			this.tableLayoutPanel1.Size = new Size(234, 208);
			this.tableLayoutPanel1.TabIndex = 0;
			this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Dock = DockStyle.Fill;
			this.panel1.Location = new Point(3, 174);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(228, 31);
			this.panel1.TabIndex = 0;
			this.button1.Location = new Point(16, 2);
			this.button1.Name = "button1";
			this.button1.Size = new Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "确定";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new EventHandler(this.button1_Click);
			this.button2.Location = new Point(138, 2);
			this.button2.Name = "button2";
			this.button2.Size = new Size(75, 23);
			this.button2.TabIndex = 0;
			this.button2.Text = "取消";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new EventHandler(this.button2_Click);
			this.flowLayoutPanel1.Dock = DockStyle.Fill;
			this.flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new Point(3, 3);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new Size(76, 165);
			this.flowLayoutPanel1.TabIndex = 1;
			this.flowLayoutPanel2.Dock = DockStyle.Fill;
			this.flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
			this.flowLayoutPanel2.Location = new Point(85, 3);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Size = new Size(146, 165);
			this.flowLayoutPanel2.TabIndex = 2;
			base.AutoScaleDimensions = new SizeF(6f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(240, 228);
			base.Controls.Add(this.groupBox1);
			base.Name = "PrimaryKey";
			this.Text = "PrimaryKey";
			base.Load += new EventHandler(this.PrimaryKey_Load);
			this.groupBox1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			base.ResumeLayout(false);
		}
		public PrimaryKey()
		{
			this.InitializeComponent();
			this.Keys = new List<string>();
			this.Values = new List<string>();
		}
		private void button2_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}
		private void button1_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.flowLayoutPanel2.Controls.Count; i++)
			{
				this.Values.Add(((TextBox)this.flowLayoutPanel2.Controls[i]).Text);
			}
			base.DialogResult = DialogResult.OK;
			base.Close();
		}
		private void PrimaryKey_Load(object sender, EventArgs e)
		{
			foreach (string current in this.Keys)
			{
				Label label = new Label();
				label.Height = 30;
				label.Text = current;
				TextBox textBox = new TextBox();
				textBox.Height = 30;
				this.flowLayoutPanel2.Controls.Add(textBox);
				this.flowLayoutPanel1.Controls.Add(label);
			}
		}
	}
}
