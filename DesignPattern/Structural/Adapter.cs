using System;

namespace DesignPattern.Structural
{
	public interface IMyRemoteDesktop
	{
		string IPAddress { get; set; }

		bool InitiateConnection();
		void LookIntoDesktop();
		void CloseConnection();
	}

	public class MyRemoteDestopWrapper : IMyRemoteDesktop
	{
		public string IPAddress { get; set; }

		public bool InitiateConnection()
		{
			Console.WriteLine("My-RDP Initiated Connection to IP: " + this.IPAddress);
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

	public class RealVNCRemoteDesktopAdapter : IMyRemoteDesktop
	{
		private RealVNCRemoteDesktopWrapper _QLots = new RealVNCRemoteDesktopWrapper();

		public string IPAddress { get; set; }

		public bool InitiateConnection()
		{
			return _QLots.ConnectTo(this.IPAddress);
		}

		public void LookIntoDesktop()
		{
			_QLots.StartRemoteDesktop();
		}

		public void CloseConnection()
		{
			_QLots.CloseDesktop();
		}
	}

	public interface IRealVNCRemoteDesktop
	{
		bool ConnectTo(string ipAddress);
		void StartRemoteDesktop();
		void CloseDesktop();
	}

	public class RealVNCRemoteDesktopWrapper : IRealVNCRemoteDesktop
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
			IMyRemoteDesktop psaLots = new MyRemoteDestopWrapper();
			psaLots.IPAddress = "10.10.10.10";
			psaLots.InitiateConnection();
			psaLots.LookIntoDesktop();
			psaLots.CloseConnection();

			IMyRemoteDesktop questraLots = new RealVNCRemoteDesktopAdapter();
			questraLots.IPAddress = "20.20.20.20";
			questraLots.InitiateConnection();
			questraLots.LookIntoDesktop();
			questraLots.CloseConnection();
		}
	}
}
