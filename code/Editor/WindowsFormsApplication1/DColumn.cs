using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
namespace WindowsFormsApplication1
{
	public class DColumn : IXmlSerializable
	{
		private DRange range;
		private int length;
		private string table;
		private string value;
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
		public ColumnTypes Type
		{
			get;
			set;
		}
		public bool NotNull
		{
			get;
			set;
		}
		public bool ReadOnly
		{
			get;
			set;
        }
        public bool ToClient { get; set; }
        public bool ToServer { get; set; }

	    public string CodeName { get; set; }

	    public DRange Range
		{
			get
			{
				if (this.Type == ColumnTypes.Integer || this.Type == ColumnTypes.Float)
				{
					return this.range;
				}
				throw new ArgumentException("range can only get when type is integer or float", "range");
			}
			set
			{
				if (this.Type == ColumnTypes.Integer || this.Type == ColumnTypes.Float)
				{
					this.range = value;
					return;
				}
				throw new ArgumentException("range can only get when type is integer or float", "range");
			}
		}
		public int Length
		{
			get
			{
				if (this.Type == ColumnTypes.String)
				{
					return this.length;
				}
				throw new ArgumentException("length can only get when type is string", "length");
			}
			set
			{
				if (this.Type == ColumnTypes.String)
				{
					this.length = value;
					return;
				}
				throw new ArgumentException("length can only set when type is string", "length");
			}
		}
		public string Desc
		{
			get;
			set;
		}
		public string Table
		{
			get
			{
				if (this.Type == ColumnTypes.Refid)
				{
					return this.table;
				}
				throw new ArgumentException("table can only get when type is refid", "table");
			}
			set
			{
				if (this.Type == ColumnTypes.Refid)
				{
					this.table = value;
					return;
				}
				throw new ArgumentException("table can only set when type is refid", "table");
			}
		}
		public string Value
		{
			get
			{
				if (this.Type == ColumnTypes.Set || this.Type == ColumnTypes.Enum)
				{
					return this.value;
				}
				throw new ArgumentException("value can only get when type is set or enum", "value");
			}
			set
			{
				if (this.Type == ColumnTypes.Set || this.Type == ColumnTypes.Enum)
				{
					this.value = value;
					return;
				}
				throw new ArgumentException("value can only set when type is set or enum", "value");
			}
		}
		public string DefaultValue
		{
			get;
			set;
		}
		public XmlSchema GetSchema()
		{
			throw new NotImplementedException();
		}
		public void ReadXml(XmlReader reader)
		{
			if (reader.NodeType == XmlNodeType.Element && reader.Name == "column")
			{
				this.Name = reader.GetAttribute("name");
				this.Alias = reader.GetAttribute("alias");

                this.ToClient = Convert.ToBoolean(reader.GetAttribute("client"));
                this.ToServer = Convert.ToBoolean(reader.GetAttribute("server"));
			    this.CodeName = reader.GetAttribute("codename");

				this.Type = (ColumnTypes)Enum.Parse(typeof(ColumnTypes), reader.GetAttribute("type"), true);
				switch (this.Type)
				{
				case ColumnTypes.Enum:
					this.Value = reader.GetAttribute("value");
					try
					{
						this.DefaultValue = reader.GetAttribute("default");
						goto IL_1FB;
					}
					catch (Exception)
					{
						goto IL_1FB;
					}
					break;
				case ColumnTypes.Refid:
					break;
				case ColumnTypes.String:
					goto IL_F1;
				case ColumnTypes.Integer:
					goto IL_123;
				case ColumnTypes.Long:
					goto IL_1FB;
				case ColumnTypes.Float:
					goto IL_17E;
				case ColumnTypes.Set:
					goto IL_1D4;
				default:
					goto IL_1FB;
				}
				this.Table = reader.GetAttribute("table");
				try
				{
					this.DefaultValue = reader.GetAttribute("default");
					goto IL_1FB;
				}
				catch (Exception)
				{
					goto IL_1FB;
				}
				IL_F1:
				this.Length = Convert.ToInt32(reader.GetAttribute("length"));
				try
				{
					this.DefaultValue = reader.GetAttribute("default");
					goto IL_1FB;
				}
				catch (Exception)
				{
					goto IL_1FB;
				}
				IL_123:
				string attribute = reader.GetAttribute("range");
				string[] array = attribute.Split(new char[]
				{
					','
				});
				DRange dRange = new DRange((double)Convert.ToInt64(array[0]), (double)Convert.ToInt64(array[1]));
				this.Range = dRange;
				try
				{
					this.DefaultValue = reader.GetAttribute("default");
					goto IL_1FB;
				}
				catch (Exception)
				{
					goto IL_1FB;
				}
				IL_17E:
				attribute = reader.GetAttribute("range");
				array = attribute.Split(new char[]
				{
					','
				});
				dRange = new DRange(Convert.ToDouble(array[0]), Convert.ToDouble(array[1]));
				this.Range = dRange;
				try
				{
					this.DefaultValue = reader.GetAttribute("default");
					goto IL_1FB;
				}
				catch (Exception)
				{
					goto IL_1FB;
				}
				IL_1D4:
				this.Value = reader.GetAttribute("value");
				try
				{
					this.DefaultValue = reader.GetAttribute("default");
				}
				catch (Exception)
				{
				}
				IL_1FB:
				this.NotNull = Convert.ToBoolean(reader.GetAttribute("not-null"));
				this.ReadOnly = Convert.ToBoolean(reader.GetAttribute("readonly"));
				this.Desc = reader.GetAttribute("description");
				if (!reader.IsEmptyElement)
				{
					while (reader.Read())
					{
						if (reader.NodeType == XmlNodeType.EndElement)
						{
							return;
						}
					}
				}
			}
		}
		public void WriteXml(XmlWriter writer)
		{
			throw new NotImplementedException();
		}
	}
}
