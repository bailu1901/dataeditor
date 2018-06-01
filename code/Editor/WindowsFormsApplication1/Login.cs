using System;
using System.Collections;
using System.ComponentModel;
using System.Data.Odbc;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WindowsFormsApplication1.Properties;
namespace WindowsFormsApplication1
{
	public class Login : Form
	{
		private IContainer components;
		private Label label1;
		private Label label2;
		private Label label3;
		private ComboBox comboBox1;
		private TextBox textBox1;
		private TextBox textBox2;
		private Button button1;
		private Button button2;
		private ArrayList server_addrs;
		private ArrayList server_names;
	    public static bool CodeTitle = false;
		public string server_addr
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
			this.label2 = new Label();
			this.label3 = new Label();
			this.comboBox1 = new ComboBox();
			this.textBox1 = new TextBox();
			this.textBox2 = new TextBox();
			this.button1 = new Button();
			this.button2 = new Button();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Location = new Point(35, 30);
			this.label1.Name = "label1";
			this.label1.Size = new Size(41, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "服务器";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(35, 62);
			this.label2.Name = "label2";
			this.label2.Size = new Size(41, 12);
			this.label2.TabIndex = 0;
			this.label2.Text = "用户名";
			this.label3.AutoSize = true;
			this.label3.Location = new Point(35, 95);
			this.label3.Name = "label3";
			this.label3.Size = new Size(29, 12);
			this.label3.TabIndex = 0;
			this.label3.Text = "密码";
			this.label3.TextAlign = ContentAlignment.MiddleCenter;
			this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new Point(106, 22);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new Size(121, 20);
			this.comboBox1.TabIndex = 4;
			this.comboBox1.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);
			this.textBox1.Location = new Point(106, 55);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new Size(119, 21);
			this.textBox1.TabIndex = 0;
			this.textBox2.Location = new Point(106, 95);
			this.textBox2.Name = "textBox2";
			this.textBox2.PasswordChar = '*';
			this.textBox2.Size = new Size(120, 21);
			this.textBox2.TabIndex = 1;
			this.button1.Location = new Point(45, 138);
			this.button1.Name = "button1";
			this.button1.Size = new Size(61, 21);
			this.button1.TabIndex = 2;
			this.button1.Text = "登录";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new EventHandler(this.button1_Click);
			this.button2.DialogResult = DialogResult.Cancel;
			this.button2.Location = new Point(150, 138);
			this.button2.Name = "button2";
			this.button2.Size = new Size(61, 21);
			this.button2.TabIndex = 3;
			this.button2.Text = "取消";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new EventHandler(this.button2_Click);
			base.AcceptButton = this.button1;
			base.AutoScaleDimensions = new SizeF(6f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.CancelButton = this.button2;
			base.ClientSize = new Size(286, 181);
			base.Controls.Add(this.button2);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.textBox2);
			base.Controls.Add(this.textBox1);
			base.Controls.Add(this.comboBox1);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Name = "Login";
			this.Text = "Login";
			base.Load += new EventHandler(this.Login_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		public Login()
		{
			this.InitializeComponent();
			this.server_addrs = new ArrayList();
			this.server_names = new ArrayList();
		}
		private void button1_Click(object sender, EventArgs e)
		{
			Settings.Default.testConnectionString = this.server_addr;
			long num = 0L;
			using (OdbcConnection odbcConnection = new OdbcConnection(Settings.Default.testConnectionString))
			{
				odbcConnection.Open();
				OdbcCommand odbcCommand = odbcConnection.CreateCommand();
				odbcCommand.CommandText = string.Concat(new string[]
				{
					"SELECT UserName, Password, UserId, ModRight, NewUserRight, ViewRight  FROM User WHERE (UserName = '",
					this.textBox1.Text,
					"') AND (Password = '",
					this.textBox2.Text,
					"')"
				});
				try
				{
					OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader();
					if (odbcDataReader.Read() && odbcDataReader["UserName"].ToString().Trim() == this.textBox1.Text && odbcDataReader["Password"].ToString().Trim() == this.textBox2.Text)
					{
						num = Convert.ToInt64(odbcDataReader["UserId"].ToString());
                        Program.modify_right = Convert.ToBoolean(odbcDataReader["ModRight"]);
                        Program.add_user_right = Convert.ToBoolean(odbcDataReader["NewUserRight"]);
                        Program.view_right = Convert.ToBoolean(odbcDataReader["ViewRight"]);
						Program.user_name = this.textBox1.Text;
					}
				}
				catch (Exception ex)
				{
					num = 0L;
				}
			}
			if (num == 0L)
			{
				MessageBox.Show("用户名或密码不正确！");
				return;
			}
			Program.userid = num;
			MainForm mainForm = new MainForm(true);
			mainForm.Show();
		    mainForm.DataName = this.comboBox1.Items[this.comboBox1.SelectedIndex].ToString();
		    mainForm.Text = string.Format("数据编辑器--{0}", mainForm.DataName);
			base.Hide();
		}
		private void Login_Load(object sender, EventArgs e)
		{
			string path = "server_list.txt";
			if (!File.Exists(path))
			{
				throw new FileNotFoundException("server_list.txt");
			}
			using (StreamReader streamReader = new StreamReader(path))
			{
				string text;
				while ((text = streamReader.ReadLine()) != null)
                {
                    if (text.StartsWith("CodeTitle="))
                    {
                        CodeTitle = bool.Parse(text.Substring(10));
                    }

					string[] array = text.Split(new char[]
					{
						','
					});

                    if (array.Length == 2)
                    {
                        this.comboBox1.Items.Add(array[0]);
                        this.server_names.Add(array[0]);
                        this.server_addrs.Add(array[1]);
                    }
                }
				this.comboBox1.SelectedIndex = 0;
			}
		}
		private void button2_Click(object sender, EventArgs e)
		{
			base.Close();
		}
		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.server_addr = (this.server_addrs[this.comboBox1.SelectedIndex] as string);
		}
	}
}
