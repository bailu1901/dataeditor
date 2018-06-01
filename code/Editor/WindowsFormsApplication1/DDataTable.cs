using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using WindowsFormsApplication1.Properties;
namespace WindowsFormsApplication1
{
	public class DDataTable : IXmlSerializable
	{
		private DataTable mDataTable = new DataTable();
		private bool mDataTableInited;
		private Dictionary<string, DColumn> mColumns = new Dictionary<string, DColumn>();
		private bool DataLoaded;
		private bool visbility;
		private string _virtual;
		private Dictionary<long, bool> mIdTable = new Dictionary<long, bool>();
		public string Name
		{
			get;
			set;
		}
		public string Alias
		{
			get;
			set;
		}
		public string Catalog
		{
			get;
			set;
		}
		public string Operate
		{
			get;
			set;
		}
		public bool Visibility
		{
			get
			{
				return this.visbility;
			}
		}
		public string Virtual
		{
			get
			{
				return this._virtual;
			}
		}

        public bool ToClient { get; set; }
        public bool ToServer { get; set; }

	    public PrimaryKey_ Key
		{
			get;
			set;
		}
		public long Id
		{
			get;
			set;
		}
		public bool IsCheckedOut
		{
			get;
			set;
		}
		public string User
		{
			get;
			set;
		}
		public DColumn SysIdColumn
		{
			get;
			set;
		}


        public HashSet<long> ImportedIds = new HashSet<long>();

		public DataTable DataTable
		{
			get
			{
				if (!this.mDataTableInited)
				{
					this.InitDataTable();
				}
				return this.mDataTable;
			}
		}
		public Dictionary<string, DColumn> Columns
		{
			get
			{
				return this.mColumns;
			}
		}
		public void UpdateIdTable()
		{
			this.mIdTable.Clear();
			foreach (DataRow dataRow in this.mDataTable.Rows)
			{
				this.mIdTable.Add((long)dataRow[0], true);
			}
		}
		public bool ContainsId(long i)
		{
			return this.mIdTable.ContainsKey(i);
		}
		public void InitDataTable()
		{
			foreach (KeyValuePair<string, DColumn> current in this.mColumns)
			{
				DataColumn dataColumn = new DataColumn(current.Key, Converter.ToType(current.Value.Type));
				try
				{
					switch (current.Value.Type)
					{
					case ColumnTypes.Enum:
					{
						string[] array = current.Value.Value.Split(new char[]
						{
							','
						});
						if (Convert.ToInt64(current.Value.DefaultValue) < (long)array.Length)
						{
							dataColumn.DefaultValue = Convert.ToInt64(current.Value.DefaultValue);
						}
						break;
					}
					case ColumnTypes.Refid:
						dataColumn.DefaultValue = Convert.ToInt64(current.Value.DefaultValue);
						break;
					case ColumnTypes.String:
						dataColumn.DefaultValue = current.Value.DefaultValue;
						break;
					case ColumnTypes.Integer:
						dataColumn.DefaultValue = Convert.ToInt64(current.Value.DefaultValue);
						break;
					case ColumnTypes.Long:
						dataColumn.DefaultValue = Convert.ToInt64(current.Value.DefaultValue);
						break;
					case ColumnTypes.Float:
						dataColumn.DefaultValue = Convert.ToSingle(current.Value.DefaultValue);
						break;
					case ColumnTypes.Set:
						dataColumn.DefaultValue = Convert.ToInt64(current.Value.DefaultValue);
						break;
					}
				}
				catch (Exception)
				{
				}
				if (current.Value.DefaultValue == null)
				{
					dataColumn.DefaultValue = 0;
				}
				dataColumn.Caption = current.Value.Alias;
				if (current.Value.Type == ColumnTypes.String)
				{
					dataColumn.MaxLength = current.Value.Length;
				}
				dataColumn.ReadOnly = current.Value.ReadOnly;
				dataColumn.AllowDBNull = !current.Value.NotNull;
				this.mDataTable.Columns.Add(dataColumn);
			}
			DataColumn[] array2 = new DataColumn[this.Key.Columns.Count];
			for (int i = 0; i < this.Key.Columns.Count; i++)
			{
				array2[i] = this.mDataTable.Columns[this.Key.Columns[i].Name];
			}
			this.mDataTable.PrimaryKey = array2;
			this.mDataTable.TableName = this.Name;
			this.mDataTableInited = true;
		}
		public void LoadData()
		{
		    using (OdbcConnection odbcConnection = new OdbcConnection(Settings.Default.testConnectionString))
		    {
		        using (OdbcDataAdapter odbcDataAdapter = new OdbcDataAdapter(string.Concat(new string[]
		        {
		            "select * from ",
		            this.Name,
		            " order by ",
		            this.Key.Columns[0].Name,
		            " asc"
		        }), odbcConnection))
                {
                    try
                    {
                        using (new OdbcCommandBuilder(odbcDataAdapter))
                        {
                            this.DataTable.Clear();
                            odbcConnection.Open();
                            odbcDataAdapter.Fill(this.DataTable);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Table name: " + this.Name, ex);
                    }
                }
		    }
		    this.UpdateIdTable();
		}

	    public void LoadDataFromFile()
	    {
            DataTable.Clear();

            System.IO.StreamReader streamReaderClient = null;
            System.IO.StreamReader streamReaderServer = null;
	        try
	        {
	            // load client
	            if (ToClient)
	            {
	                streamReaderClient = new System.IO.StreamReader("../../Client/Assets/Res/Table/" + this.Name + ".txt",
	                    System.Text.Encoding.UTF8);
	            }
	            // load server
	            if (ToServer)
	            {
	                streamReaderServer = new System.IO.StreamReader("../../Server/Tables/" + this.Name + ".txt",
	                    System.Text.Encoding.UTF8);
	            }
	        }
	        catch (Exception ex)
	        {
                MessageBox.Show(ex.ToString());
	        }

	        string client = null;
	        string server = null;

	        if (streamReaderClient != null)
	        {
	            streamReaderClient.ReadLine();
	            streamReaderClient.ReadLine();
	            client = streamReaderClient.ReadLine();
	        }

	        if (streamReaderServer != null)
	        {
	            streamReaderServer.ReadLine();
	            streamReaderServer.ReadLine();
	            server = streamReaderServer.ReadLine();
	        }

	        string[] ss, cs;

	        while (client != null || server != null)
	        {
	            if (client != null)
	            {
	                cs = client.Split(new char[] {'\t'});
	            }
	            else cs = null;

	            if (server != null)
	            {
	                ss = server.Split(new char[] {'\t'});
	            }
	            else ss = null;

	            DataRow dataRow = DataTable.NewRow();
	            try
	            {
	                int ci = 0;
                    int si = 0;
	                int i = 0;
	                foreach (var column in Columns)
	                {
	                    if (column.Value.ToClient && column.Value.ToServer)
	                    {
	                        if (cs == null || ss == null || ss[si] != cs[ci])
	                            throw new Exception("Server table is different from client table : " + Name);

	                        dataRow[column.Key] = cs[ci];
	                        ci++;
	                        si++;
	                    }
	                    else if (column.Value.ToClient)
	                    {
	                        if (cs == null)
	                            throw new Exception("Client table is NOT valid : " + Name);

	                        dataRow[column.Key] = cs[ci];
	                        ci++;
	                    }
	                    else if (column.Value.ToServer)
	                    {
	                        if (ss == null)
	                            throw new Exception("Server table is NOT valid : " + Name);

	                        dataRow[column.Key] = ss[si];
	                        si++;
	                    }
	                    else
	                    {
	                        //dataRow[column.Key] = null;
                        }
                        i++;
	                }

	                DataTable.Rows.Add(dataRow);

	                if (streamReaderClient != null)
	                {
	                    client = streamReaderClient.ReadLine();
	                }

	                if (streamReaderServer != null)
	                {
	                    server = streamReaderServer.ReadLine();
	                }

	            }
	            catch (Exception ex2)
	            {
	                if (streamReaderClient != null)
	                    streamReaderClient.Close();
	                if (streamReaderServer != null)
	                    streamReaderServer.Close();
	                MessageBox.Show(ex2.ToString());
	                return;
	            }
            }

            if (streamReaderClient != null)
                streamReaderClient.Close();
            if (streamReaderServer != null)
                streamReaderServer.Close();
	    }

        private string Skip_Comment(System.IO.StreamReader st)
        {
            string text = st.ReadLine();
            while (text != null && (text[0] == '#' || text[0] == '\t'))
            {
                text = st.ReadLine();
            }
            return text;
        }

		private void mDataTable_ColumnChanged(object sender, DataColumnChangeEventArgs e)
		{
		}
		public XmlSchema GetSchema()
		{
			throw new NotImplementedException();
		}
		public void ReadXml(XmlReader reader)
		{
			if (reader.Name == "table")
			{
				this.Name = reader.GetAttribute("name");
				this.Alias = reader.GetAttribute("alias");
				this.Catalog = reader.GetAttribute("catalog");
				this.Operate = reader.GetAttribute("operate");
                this.visbility = !Convert.ToBoolean(reader.GetAttribute("invisible"));
                this._virtual = reader.GetAttribute("virtual");
                this.ToClient = Convert.ToBoolean(reader.GetAttribute("client"));
                this.ToServer = Convert.ToBoolean(reader.GetAttribute("server"));
			}
			bool isEmptyElement = reader.IsEmptyElement;
			while (reader.Read())
			{
				if (reader.NodeType == XmlNodeType.Element && reader.Name == "column")
				{
					DColumn dColumn = new DColumn();
					dColumn.ReadXml(reader);
					this.mColumns.Add(dColumn.Name, dColumn);
				}
				if (reader.NodeType == XmlNodeType.Element && reader.Name == "primarykey")
				{
					PrimaryKey_ primaryKey_ = new PrimaryKey_();
					primaryKey_.Name = reader.GetAttribute("name");
					string attribute = reader.GetAttribute("column");
					string[] array = attribute.Split(new char[]
					{
						','
					});
					string[] array2 = array;
					for (int i = 0; i < array2.Length; i++)
					{
						string key = array2[i];
						primaryKey_.Columns.Add(this.mColumns[key]);
					}
					this.Key = primaryKey_;
					while (reader.Read() && reader.NodeType != XmlNodeType.EndElement)
					{
					}
				}
				if (isEmptyElement)
				{
					return;
				}
				if (reader.NodeType == XmlNodeType.EndElement)
				{
					return;
				}
			}
		}
		public void WriteXml(XmlWriter writer)
		{
			throw new NotImplementedException();
		}
	}
}
