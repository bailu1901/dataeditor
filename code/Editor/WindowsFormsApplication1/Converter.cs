using System;
using System.Collections.Generic;
using System.Data;
namespace WindowsFormsApplication1
{
	public class Converter
	{
		private static Dictionary<string, string> _name;
		public static Type ToType(ColumnTypes type)
		{
			switch (type)
			{
			case ColumnTypes.Enum:
				return typeof(int);
			case ColumnTypes.Refid:
				return typeof(long);
			case ColumnTypes.String:
				return typeof(string);
			case ColumnTypes.Integer:
				return typeof(long);
			case ColumnTypes.Long:
				return typeof(long);
			case ColumnTypes.Float:
				return typeof(double);
			case ColumnTypes.Set:
				return typeof(long);
			default:
				throw new Exception("wrong type");
			}
		}
		public static SqlDbType ToDbType(ColumnTypes type)
		{
			switch (type)
			{
			case ColumnTypes.Enum:
				return SqlDbType.Int;
			case ColumnTypes.Refid:
				return SqlDbType.BigInt;
			case ColumnTypes.String:
				return SqlDbType.NVarChar;
			case ColumnTypes.Integer:
				return SqlDbType.BigInt;
			case ColumnTypes.Long:
				return SqlDbType.BigInt;
			case ColumnTypes.Float:
				return SqlDbType.Float;
			case ColumnTypes.Set:
				return SqlDbType.BigInt;
			default:
				throw new Exception("bad type");
			}
		}
		public static string PortedType(Type t)
		{
			if (t == typeof(int) || t == typeof(long))
			{
				return "INT";
			}
			if (t == typeof(string))
			{
				return "STRING";
			}
			if (t == typeof(double))
			{
				return "FLOAT";
			}
			throw new Exception("bad type");
		}
		static Converter()
		{
			Converter._name = new Dictionary<string, string>();
		}
		public static string ToDbName(string name)
		{
			if (Converter._name.ContainsKey(name))
			{
				return Converter._name[name];
			}
			return name;
		}
	}
}
