using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            string Text1 = "abc";
            string Text2 = "123";

            //    using (OdbcConnection odbcConnection = new OdbcConnection("Dsn=datadb;uid=dbuser;pwd=dbuser"))
            //    {
            //        odbcConnection.Open();
            //        new OdbcCommand
            //        {
            //            Connection = odbcConnection,
            //            CommandText = string.Concat(new string[]
            //            {
            //                "INSERT INTO User (UserName, Password, ViewRight, ModRight, DelRight, NewUserRight) VALUES (N'",
            //                Text1,
            //                "', N'",
            //                Text2,
            //                "', ",
            //                "1",
            //                ", ",
            //                "1",
            //                ", 0, ",
            //                "1",
            //                ")"
            //            })
            //        }.ExecuteNonQuery();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}


            long num = 0L;
            using (OdbcConnection odbcConnection = new OdbcConnection("Dsn=datadb;uid=dbuser;pwd=dbuser"))
            {
                odbcConnection.Open();
                OdbcCommand odbcCommand = odbcConnection.CreateCommand();
                odbcCommand.CommandText = string.Concat(new string[]
				{
					"SELECT UserName, Password, UserId, ModRight, NewUserRight, ViewRight  FROM User WHERE (UserName = '",
					Text1,
					"') AND (Password = '",
					Text2,
					"')"
				});
                try
                {
                    OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader();
                    if (odbcDataReader.Read() && odbcDataReader["UserName"].ToString().Trim() == Text1 && odbcDataReader["Password"].ToString().Trim() == Text2)
                    {
                        num = Convert.ToInt64(odbcDataReader["UserId"].ToString());
                        Console.WriteLine(num);
                    }
                }
                catch (Exception)
                {
                    num = 0L;
                }
            }

            Console.ReadKey();
        }

    }
}
