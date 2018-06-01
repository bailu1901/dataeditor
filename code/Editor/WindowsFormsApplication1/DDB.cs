using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
namespace WindowsFormsApplication1
{
	public class DDB : IXmlSerializable
	{
		private Dictionary<string, DDataTable> mTables = new Dictionary<string, DDataTable>();
		public string Name
		{
			get;
			set;
		}
		public string Charset
		{
			get;
			set;
		}
		public string ConnectionString
		{
			get;
			set;
		}
		public string UserName
		{
			get;
			set;
		}
		public string Password
		{
			get;
			set;
		}
		public Dictionary<string, DDataTable> Table
		{
			get
			{
				return this.mTables;
			}
		}

		public XmlSchema GetSchema()
		{
			throw new NotImplementedException();
		}
		public void ReadXml(XmlReader reader)
		{
			while (reader.Read())
			{
				if (reader.NodeType == XmlNodeType.Element && reader.Name == "DB")
				{
					this.Name = reader.GetAttribute("name");
					this.Charset = reader.GetAttribute("charset");
				}
				if (reader.NodeType == XmlNodeType.Element && reader.Name == "connection")
				{
					this.ConnectionString = reader.GetAttribute("url");
					this.UserName = reader.GetAttribute("username");
					this.Password = reader.GetAttribute("password");
				}
				if (reader.NodeType == XmlNodeType.Element && reader.Name == "table")
				{
					DDataTable dDataTable = new DDataTable();
					dDataTable.ReadXml(reader);
					this.mTables.Add(dDataTable.Name, dDataTable);
				}
			}
		}
		public void WriteXml(XmlWriter writer)
		{
			throw new NotImplementedException();
		}
	}
}
