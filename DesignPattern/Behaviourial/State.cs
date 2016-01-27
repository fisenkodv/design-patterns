using System;

namespace DesignPattern.Behaviourial
{
	public abstract class State
	{
		public double Balance { get; set; }
		public string StateName { get; protected set; }
		public Account Account { get; protected set; }
		public double LowerLimit { get; protected set; }
		public double UpperLimit { get; protected set; }

		public abstract void EnsureState();
	}

	public class BronzeState : State
	{
		public BronzeState() { }

		public BronzeState(double balance, Account account)
		{
			this.StateName = "BRONZE";
			this.Balance = balance;
			this.LowerLimit = 1000.0;
			this.UpperLimit = 50000.0;
			this.Account = account;
		}

		public override void EnsureState()
		{
			if (this.Balance > this.UpperLimit)
			{
				this.Account.AccountState = new SilverState(this.Balance, this.Account);
			}
		}
	}

	public class SilverState : State
	{
		public SilverState() { }

		public SilverState(double balance, Account account)
		{
			this.StateName = "SILVER";
			this.Balance = balance;
			this.LowerLimit = 50001.0;
			this.UpperLimit = 1000000.0;
			this.Account = account;
		}

		public override void EnsureState()
		{
			if (this.Balance > this.UpperLimit)
			{
				this.Account.AccountState = new GoldState(this.Balance, this.Account);
			}
			else if (this.Balance <= this.LowerLimit)
			{
				this.Account.AccountState = new BronzeState(this.Balance, this.Account);
			}
		}
	}

	public class GoldState : State
	{
		public GoldState() { }

		public GoldState(double balance, Account account)
		{
			this.StateName = "GOLD";
			this.Balance = balance;
			this.LowerLimit = 1000001.0;
			this.UpperLimit = double.MaxValue;
			this.Account = account;
		}

		public override void EnsureState()
		{
			if (this.Balance <= this.LowerLimit)
			{
				this.Account.AccountState = new SilverState(this.Balance, this.Account);
			}
		}
	}

	public class Account
	{
		public string CustomerName { get; private set; }
		public State AccountState { get; set; }

		public Account(string customerName)
		{
			this.CustomerName = customerName;
			this.AccountState = new BronzeState(1000.0, this);
			Console.WriteLine(this.CustomerName + " Opend Account with Deposit RS." + this.AccountState.Balance + "/-. Account State: " + this.AccountState.StateName);
		}

		public void Deposit(double amount)
		{
			this.AccountState.Balance += amount;
			this.AccountState.EnsureState();

			Console.WriteLine(this.CustomerName + " deposited RS." + amount + "/-");
			Console.WriteLine("Total Account Balance: RS." + this.AccountState.Balance + "/-. Account State: " + this.AccountState.StateName);
		}

		public void Withdraw(double amount)
		{
			this.AccountState.Balance -= amount;
			this.AccountState.EnsureState();

			Console.WriteLine(this.CustomerName + " withdrawn RS." + amount + "/-");
			Console.WriteLine("Total Account Balance: RS." + this.AccountState.Balance + "/-. Account State: " + this.AccountState.StateName);
		}

		public void PayIntrest(double percentage)
		{
			this.AccountState.Balance += (this.AccountState.Balance * percentage) * 100.0;
			this.AccountState.EnsureState();

			Console.WriteLine("Bank paid intrest of " + percentage + "%");
			Console.WriteLine("Total Account Balance: RS." + this.AccountState.Balance + "/-. Account State: " + this.AccountState.StateName);
		}
	}

	public class StateProgram
	{
		public static void RunState()
		{
			Account linus = new Account("Linus Torvalds");
			linus.Deposit(60000.0);
			linus.Deposit(20000000.0);

			linus.Withdraw(2055000.0);
			linus.PayIntrest(10.0);
		}
	}
}
