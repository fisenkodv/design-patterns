using System;
using System.Collections.Generic;

namespace DesignPattern.Behaviourial
{
  public interface IMessenger
  {
    void AddPerson(ChatPerson person);
    void Send(string message, ChatPerson originator);
  }

  public class Messenger : IMessenger
  {
    private readonly List<ChatPerson> _persons = new List<ChatPerson>();

    public Messenger(string messengerName)
    {
      Console.WriteLine(messengerName + " Messenger Started");
    }

    public void AddPerson(ChatPerson person)
    {
      _persons.Add(person);
      Console.WriteLine(person.Name + " added to Messenger");
    }

    public void Send(string message, ChatPerson originator)
    {
      foreach (var person in _persons)
        if (person != originator)
          person.ReceiveMessage(message, originator);
    }
  }

  public class ChatPerson : IEquatable<ChatPerson>
  {
    private readonly IMessenger _messenger;

    public ChatPerson(string name, IMessenger messenger)
    {
      Name = name;
      _messenger = messenger;
    }

    public string Name { get; }

    public bool Equals(ChatPerson other)
    {
      return Name.Equals(other.Name);
    }

    public void SendMessage(string message)
    {
      _messenger.Send(message, this);
    }

    public void ReceiveMessage(string message, ChatPerson person)
    {
      Console.WriteLine(Name + " received from " + person.Name + ": " + message);
    }
  }

  public class MediatorProgram
  {
    public static void RunMediator()
    {
      IMessenger messenger = new Messenger("M-Talk");

      var james = new ChatPerson("James Gosling", messenger);
      var bill = new ChatPerson("Bill Gates", messenger);
      var steve = new ChatPerson("Steve Jobs", messenger);

      messenger.AddPerson(james);
      messenger.AddPerson(bill);
      messenger.AddPerson(steve);

      james.SendMessage("Hi All...");
      bill.SendMessage("Hello, Hope you are doing good.");
    }
  }
}