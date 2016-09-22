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
          _configuration = new Configuration();
        return _configuration;
      }
    }

    public string UserId { private get; set; }
    public string Password { private get; set; }
    public string LicenseKey { private get; set; }

    public void Save()
    {
      Console.WriteLine("Configuration Saved.");
    }

    public void Load()
    {
      Console.WriteLine("User ID: " + UserId + ", Password: " + Password + ", LicenseKey: " + LicenseKey);
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