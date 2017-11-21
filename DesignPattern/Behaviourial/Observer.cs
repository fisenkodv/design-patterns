using System;
using System.Collections.Generic;

namespace DesignPattern.Behaviourial
{
  public interface IStock
  {
    string Symbol { get; }
    double Price { get; set; }

    bool Register(IInvestor investor);
    bool UnRegister(IInvestor investor);
    void Notify();
  }

  public interface IInvestor
  {
    void Update(IStock stock);
  }

  public class Investor : IInvestor
  {
    public Investor(long id, string name)
    {
      Id = id;
      Name = name;
    }

    public string Name { get; }
    public long Id { get; }

    public void Update(IStock stock)
    {
      if (stock is Stock stockObj)
      {
        Console.WriteLine($"Notified: {Name}[Trading ID #{Id}] Of {stockObj.Symbol} changed to {stockObj.Price:C}");
      }
    }
  }

  public class Stock : IStock
  {
    private readonly List<IInvestor> _investors = new List<IInvestor>();
    private double _price;

    public Stock(string symbol, double price)
    {
      Symbol = symbol;
      Price = price;
    }

    public string Symbol { get; }

    public double Price
    {
      get => _price;
      set
      {
        _price = value;
        Notify();
      }
    }

    public bool Register(IInvestor investor)
    {
      _investors.Add(investor);
      return true;
    }

    public bool UnRegister(IInvestor investor)
    {
      return _investors.Remove(investor);
    }

    public void Notify()
    {
      foreach (var investor in _investors)
      {
        investor.Update(this);
      }
    }
  }

  public class ObserverProgram
  {
    public static void RunObserver()
    {
      IInvestor steve = new Investor(100, "Steve Jobs");
      IInvestor bill = new Investor(101, "Bill Gates");
      IInvestor james = new Investor(102, "James Gosling");

      IStock aaplStock = new Stock("Apple Inc.", 1000.0);
      aaplStock.Register(steve);
      aaplStock.Register(bill);

      IStock msftStock = new Stock("Microsoft Corp.", 500.0);
      msftStock.Register(steve);
      msftStock.Register(james);

      aaplStock.Price += 2.0;
      msftStock.Price += 3.5;

      aaplStock.Price -= 0.7;
      msftStock.Price -= 1.4;
    }
  }
}