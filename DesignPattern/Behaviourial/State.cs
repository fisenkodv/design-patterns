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
    public BronzeState()
    {
    }

    public BronzeState(double balance, Account account)
    {
      StateName = "BRONZE";
      Balance = balance;
      LowerLimit = 1000.0;
      UpperLimit = 50000.0;
      Account = account;
    }

    public override void EnsureState()
    {
      if (Balance > UpperLimit)
        Account.AccountState = new SilverState(Balance, Account);
    }
  }

  public class SilverState : State
  {
    public SilverState()
    {
    }

    public SilverState(double balance, Account account)
    {
      StateName = "SILVER";
      Balance = balance;
      LowerLimit = 50001.0;
      UpperLimit = 1000000.0;
      Account = account;
    }

    public override void EnsureState()
    {
      if (Balance > UpperLimit)
        Account.AccountState = new GoldState(Balance, Account);
      else if (Balance <= LowerLimit)
        Account.AccountState = new BronzeState(Balance, Account);
    }
  }

  public class GoldState : State
  {
    public GoldState()
    {
    }

    public GoldState(double balance, Account account)
    {
      StateName = "GOLD";
      Balance = balance;
      LowerLimit = 1000001.0;
      UpperLimit = double.MaxValue;
      Account = account;
    }

    public override void EnsureState()
    {
      if (Balance <= LowerLimit)
        Account.AccountState = new SilverState(Balance, Account);
    }
  }

  public class Account
  {
    public Account(string customerName)
    {
      CustomerName = customerName;
      AccountState = new BronzeState(1000.0, this);
      Console.WriteLine(CustomerName + " Opend Account with Deposit RS." + AccountState.Balance + "/-. Account State: " +
                        AccountState.StateName);
    }

    public string CustomerName { get; }
    public State AccountState { get; set; }

    public void Deposit(double amount)
    {
      AccountState.Balance += amount;
      AccountState.EnsureState();

      Console.WriteLine(CustomerName + " deposited RS." + amount + "/-");
      Console.WriteLine("Total Account Balance: RS." + AccountState.Balance + "/-. Account State: " +
                        AccountState.StateName);
    }

    public void Withdraw(double amount)
    {
      AccountState.Balance -= amount;
      AccountState.EnsureState();

      Console.WriteLine(CustomerName + " withdrawn RS." + amount + "/-");
      Console.WriteLine("Total Account Balance: RS." + AccountState.Balance + "/-. Account State: " +
                        AccountState.StateName);
    }

    public void PayIntrest(double percentage)
    {
      AccountState.Balance += AccountState.Balance*percentage*100.0;
      AccountState.EnsureState();

      Console.WriteLine("Bank paid intrest of " + percentage + "%");
      Console.WriteLine("Total Account Balance: RS." + AccountState.Balance + "/-. Account State: " +
                        AccountState.StateName);
    }
  }

  public class StateProgram
  {
    public static void RunState()
    {
      var linus = new Account("Linus Torvalds");
      linus.Deposit(60000.0);
      linus.Deposit(20000000.0);

      linus.Withdraw(2055000.0);
      linus.PayIntrest(10.0);
    }
  }
}