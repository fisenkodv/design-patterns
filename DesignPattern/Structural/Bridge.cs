using System;

namespace DesignPattern.Structural
{
  public interface ITelevision
  {
    string BrandName { get; }
    void SwitchOn();
    void SwitchOff();
    void TuneChannel(int channel);
  }

  public class SonyTv : ITelevision
  {
    public SonyTv()
    {
      Console.WriteLine("Invoked " + BrandName);
    }

    public string BrandName => "Sony";

    public void SwitchOn()
    {
      Console.WriteLine("Switched On Sony TV");
    }

    public void SwitchOff()
    {
      Console.WriteLine("Switching Off Sony TV");
    }

    public void TuneChannel(int channel)
    {
      Console.WriteLine("Sony TV: Channel changed to " + channel);
    }
  }

  public class PhilipsTv : ITelevision
  {
    public PhilipsTv()
    {
      Console.WriteLine("Invoked " + BrandName);
    }

    public string BrandName => "Philips";

    public void SwitchOn()
    {
      Console.WriteLine("Switched On Philips TV");
    }

    public void SwitchOff()
    {
      Console.WriteLine("Switching Off Philips TV");
    }

    public void TuneChannel(int channel)
    {
      Console.WriteLine("Philips TV: Channel changed to " + channel);
    }
  }

  public abstract class RemoteControl
  {
    protected ITelevision Television;

    public void SetTelevision(ITelevision television)
    {
      Television = television;
    }

    public void On()
    {
      Television.SwitchOn();
    }

    public void Off()
    {
      Television.SwitchOff();
    }

    public virtual void ChangeChannel(int channel)
    {
      Television.TuneChannel(channel);
    }
  }

  public class RemoteController : RemoteControl
  {
    private int _currentChannel;

    public override void ChangeChannel(int channel)
    {
      _currentChannel = channel;
      Console.WriteLine(Television.BrandName + ": Switched Channel to " + _currentChannel);
    }

    public void GoNextChannel()
    {
      Television.TuneChannel(++_currentChannel);
    }

    public void GoPreviousChannel()
    {
      Television.TuneChannel(--_currentChannel);
    }
  }

  public class BridgeProgram
  {
    public static void RunBridge()
    {
      ITelevision philipsTv = new PhilipsTv();
      var remoteController = new RemoteController();
      remoteController.SetTelevision(philipsTv);

      remoteController.On();
      remoteController.ChangeChannel(10);
      remoteController.GoNextChannel();
      remoteController.Off();
    }
  }
}