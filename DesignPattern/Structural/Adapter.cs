using System;

namespace DesignPattern.Structural
{
  public interface IMyRemoteDesktop
  {
    string IpAddress { get; set; }

    bool InitiateConnection();
    void LookIntoDesktop();
    void CloseConnection();
  }

  public class MyRemoteDesktopWrapper : IMyRemoteDesktop
  {
    public string IpAddress { get; set; }

    public bool InitiateConnection()
    {
      Console.WriteLine("My-RDP Initiated Connection to IP: " + IpAddress);
      return true;
    }

    public void LookIntoDesktop()
    {
      Console.WriteLine("My-RDP is Looking into Desktop...");
    }

    public void CloseConnection()
    {
      Console.WriteLine("My-RDP Closed Remote Desktop");
    }
  }

  public class RealVncRemoteDesktopAdapter : IMyRemoteDesktop
  {
    private readonly RealVncRemoteDesktopWrapper _qLots = new RealVncRemoteDesktopWrapper();

    public string IpAddress { get; set; }

    public bool InitiateConnection()
    {
      return _qLots.ConnectTo(IpAddress);
    }

    public void LookIntoDesktop()
    {
      _qLots.StartRemoteDesktop();
    }

    public void CloseConnection()
    {
      _qLots.CloseDesktop();
    }
  }

  public interface IRealVncRemoteDesktop
  {
    bool ConnectTo(string ipAddress);
    void StartRemoteDesktop();
    void CloseDesktop();
  }

  public class RealVncRemoteDesktopWrapper : IRealVncRemoteDesktop
  {
    public bool ConnectTo(string ipAddress)
    {
      Console.WriteLine("Real-VNC connection to IP: " + ipAddress);
      return true;
    }

    public void StartRemoteDesktop()
    {
      Console.WriteLine("Real-VNC Starting Remote Desktop...");
    }

    public void CloseDesktop()
    {
      Console.WriteLine("Real-VNC Closed Remote Connection.");
    }
  }

  public class AdapterProgram
  {
    public static void RunAdapter()
    {
      IMyRemoteDesktop psaLots = new MyRemoteDesktopWrapper();
      psaLots.IpAddress = "10.10.10.10";
      psaLots.InitiateConnection();
      psaLots.LookIntoDesktop();
      psaLots.CloseConnection();

      IMyRemoteDesktop questraLots = new RealVncRemoteDesktopAdapter();
      questraLots.IpAddress = "20.20.20.20";
      questraLots.InitiateConnection();
      questraLots.LookIntoDesktop();
      questraLots.CloseConnection();
    }
  }
}