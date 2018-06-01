using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;
namespace WindowsFormsApplication1.Properties
{
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0"), CompilerGenerated]
	internal sealed class Settings : ApplicationSettingsBase
	{
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}
		[ApplicationScopedSetting, DefaultSettingValue("Data Source=HXAGE-0-091\\SQLEXPRESS;Initial Catalog=test;Integrated Security=True"), SpecialSetting(SpecialSetting.ConnectionString), DebuggerNonUserCode]
		public string testConnectionString
		{
			get
			{
				return (string)this["testConnectionString"];
			}
			set
			{
				this["testConnectionString"] = value;
			}
		}
		[ApplicationScopedSetting, DefaultSettingValue("Dsn=hlxj;uid=xiyoudb;pwd=xiyoudb"), SpecialSetting(SpecialSetting.ConnectionString), DebuggerNonUserCode]
		public string ConnectionString
		{
			get
			{
				return (string)this["ConnectionString"];
			}
		}
	}
}
