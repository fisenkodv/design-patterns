using System;

namespace DesignPattern.Creational
{
	public class Configuration
	{
		private static Configuration _configuration;

		public static Configuration Default
		{
			get
			{
				if (null == _configuration)
				{
					_configuration = new Configuration();
				}
				return _configuration;
			}
		}

		public string UserId { get; set; }
		public string Password { get; set; }
		public string LicenseKey { get; set; }

		public void Save()
		{
			Console.WriteLine("Configuration Saved.");
		}

		public void Load()
		{
			Console.WriteLine("User ID: " + this.UserId + ", Password: " + this.Password + ", LicenseKey: " + this.LicenseKey);
		}
	}

	public class SingletonProgram
	{
		public static void RunSingleton()
		{
			Configuration.Default.UserId = "Linus";
			Configuration.Default.Password = "!welcome123";
			Configuration.Default.LicenseKey = "ABCDEFGH";

			Configuration.Default.Save();
			Configuration.Default.Load();
		}
	}
}
