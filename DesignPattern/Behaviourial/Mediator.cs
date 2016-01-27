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
			foreach (ChatPerson person in _persons)
			{
				if (person != originator)
				{
					person.ReceiveMessage(message, originator);
				}
			}
		}
	}

	public class ChatPerson : IEquatable<ChatPerson>
	{
		public string Name { get; private set; }
		private readonly IMessenger _messenger;

		public ChatPerson(string name, IMessenger messenger)
		{
			this.Name = name;
			this._messenger = messenger;
		}

		public void SendMessage(string message)
		{
			_messenger.Send(message, this);
		}

		public void ReceiveMessage(string message, ChatPerson person)
		{
			Console.WriteLine(this.Name + " received from " + person.Name + ": " + message);
		}

		public bool Equals(ChatPerson other)
		{
			return this.Name.Equals(other.Name);
		}
	}

	public class MediatorProgram
	{
		public static void RunMediator()
		{
			IMessenger messenger = new Messenger("M-Talk");

			ChatPerson james = new ChatPerson("James Gosling", messenger);
			ChatPerson bill = new ChatPerson("Bill Gates", messenger);
			ChatPerson steve = new ChatPerson("Steve Jobs", messenger);

			messenger.AddPerson(james);
			messenger.AddPerson(bill);
			messenger.AddPerson(steve);

			james.SendMessage("Hi All...");
			bill.SendMessage("Hello, Hope you are doing good.");
		}
	}
}
