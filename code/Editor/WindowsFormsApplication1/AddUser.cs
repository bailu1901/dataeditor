using System;
using System.ComponentModel;
using System.Data.Odbc;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApplication1.Properties;
namespace WindowsFormsApplication1
{
	public class AddUser : Form
	{
		private IContainer components;
		private Label label1;
		private Label label2;
		private TextBox textBox1;
		private TextBox textBox2;
		private Button button1;
		private Button button2;
		private CheckBox checkBox1;
		private CheckBox checkBox2;
		private CheckBox checkBox3;
		public AddUser()
		{
			this.InitializeComponent();
		}
		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				using (OdbcConnection odbcConnection = new OdbcConnection(Settings.Default.testConnectionString))
				{
					odbcConnection.Open();
					new OdbcCommand
					{
						Connection = odbcConnection,
						CommandText = string.Concat(new string[]
						{
							"INSERT INTO User (UserName, Password, ViewRight, ModRight, DelRight, NewUserRight) VALUES (N'",
							this.textBox1.Text,
							"', N'",
							this.textBox2.Text,
							"', ",
							this.checkBox1.Checked ? "1" : "0",
							", ",
							this.checkBox2.Checked ? "1" : "0",
							", 0, ",
							this.checkBox3.Checked ? "1" : "0",
							")"
						})
					}.ExecuteNonQuery();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				base.Close();
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
			this.label1 = new Label();
			this.label2 = new Label();
			this.textBox1 = new TextBox();
			this.textBox2 = new TextBox();
			this.button1 = new Button();
			this.button2 = new Button();
			this.checkBox1 = new CheckBox();
			this.checkBox2 = new CheckBox();
			this.checkBox3 = new CheckBox();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Location = new Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new Size(41, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "用户名";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(13, 46);
			this.label2.Name = "label2";
			this.label2.Size = new Size(29, 12);
			this.label2.TabIndex = 0;
			this.label2.Text = "密码";
			this.textBox1.Location = new Point(72, 13);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new Size(100, 21);
			this.textBox1.TabIndex = 1;
			this.textBox2.Location = new Point(72, 40);
			this.textBox2.Name = "textBox2";
			this.textBox2.PasswordChar = '*';
			this.textBox2.Size = new Size(100, 21);
			this.textBox2.TabIndex = 1;
			this.button1.Location = new Point(12, 119);
			this.button1.Name = "button1";
			this.button1.Size = new Size(75, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "确定";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new EventHandler(this.button1_Click);
			this.button2.Location = new Point(126, 119);
			this.button2.Name = "button2";
			this.button2.Size = new Size(75, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "取消";
			this.button2.UseVisualStyleBackColor = true;
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new Point(15, 82);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new Size(84, 16);
			this.checkBox1.TabIndex = 3;
			this.checkBox1.Text = "修改数据库";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new Point(99, 82);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new Size(48, 16);
			this.checkBox2.TabIndex = 3;
			this.checkBox2.Text = "修改";
			this.checkBox2.UseVisualStyleBackColor = true;
			this.checkBox3.AutoSize = true;
			this.checkBox3.Location = new Point(153, 82);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new Size(72, 16);
			this.checkBox3.TabIndex = 3;
			this.checkBox3.Text = "增加用户";
			this.checkBox3.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new SizeF(6f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(231, 159);
			base.Controls.Add(this.checkBox3);
			base.Controls.Add(this.checkBox2);
			base.Controls.Add(this.checkBox1);
			base.Controls.Add(this.button2);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.textBox2);
			base.Controls.Add(this.textBox1);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Name = "AddUser";
			this.Text = "AddUser";
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
