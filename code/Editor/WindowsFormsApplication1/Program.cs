using System;
using System.Text;
using System.Windows.Forms;
using System.Xml;
namespace WindowsFormsApplication1
{
	public static class Program
	{
		public static DDB ddb;
		public static long userid;
		public static string user_name;
		public static bool modify_right;
		public static bool view_right;
		public static bool add_user_right;
		[STAThread]
		private static void Main()
		{
			Application.SetCompatibleTextRenderingDefault(false);
			Program.ddb = new DDB();
		    try
		    {
                XmlReader xmlReader = XmlReader.Create("test.xml", null, new XmlParserContext(null, null, null, XmlSpace.Default, Encoding.UTF8));
                Program.ddb.ReadXml(xmlReader);
                xmlReader.Close();
		    }
		    catch (Exception ex)
		    {
		        MessageBox.Show(ex.ToString());
                return;
		    }

		    if (System.IO.File.Exists("NotDev"))
		    {
		        var form = new MainForm(false);
                Application.Run(form);
		    }
		    else
		    {
		        Application.Run(new Login());
		    }
		}
	}
}
