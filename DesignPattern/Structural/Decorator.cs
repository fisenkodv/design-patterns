using System;

namespace DesignPattern.Structural
{
  public interface IPizza
  {
    double Cost { get; }
    string Description();
  }

  public class Pizza : IPizza
  {
    private readonly string _description;

    public Pizza(string description)
    {
      _description = description;
    }

    public string Description()
    {
      return _description;
    }

    public double Cost => 450.0;
  }

  public abstract class PizzaToppings : IPizza
  {
    protected IPizza Pizza;

    public abstract double Cost { get; }

    public abstract string Description();
  }

  public class ExtraSoya : PizzaToppings
  {
    public ExtraSoya(IPizza pizza)
    {
      Pizza = pizza;
    }

    public override double Cost => Pizza.Cost + 50;

    public override string Description()
    {
      return Pizza.Description() + " + Extra Soya";
    }
  }

  public class ExtraCheese : PizzaToppings
  {
    public ExtraCheese(IPizza pizza)
    {
      Pizza = pizza;
    }

    public override double Cost => Pizza.Cost + 75;

    public override string Description()
    {
      return Pizza.Description() + " + Extra Cheese";
    }
  }

  public class ExtraTomatoAndOnion : PizzaToppings
  {
    public ExtraTomatoAndOnion(IPizza pizza)
    {
      Pizza = pizza;
    }

    public override double Cost => Pizza.Cost + 90;

    public override string Description()
    {
      return Pizza.Description() + " + Extra Tomato & Onion";
    }
  }

  public class DecoratorProgram
  {
    public static void RunDecorator()
    {
      IPizza orderedPizza = new Pizza("Dominos Margareta Large (VEG)");
      orderedPizza = new ExtraSoya(orderedPizza);
      orderedPizza = new ExtraCheese(orderedPizza);

      Console.WriteLine(orderedPizza.Description());
      Console.WriteLine("Total Cost = " + orderedPizza.Cost);
    }
  }
}