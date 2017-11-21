using System;

namespace DesignPattern.Creational
{
  public abstract class DominosFoodItem
  {
    public string ItemName { get; protected set; }
    public float Price { get; protected set; }

    public virtual void TakeOrder()
    {
      Console.WriteLine("Order Taken for " + ItemName);
    }

    public abstract void ProcessOrder();
    public abstract void DeliverFoodItem();
  }

  public class Pizza : DominosFoodItem
  {
    public Pizza()
    {
      ItemName = "Dominos Cheese Pizza";
      Price = 475.0f;
    }

    public override void ProcessOrder()
    {
      Console.WriteLine(ItemName + "Order will take 15 mins to cook");
    }

    public override void DeliverFoodItem()
    {
      Console.WriteLine(ItemName + " costed INR. " + Price + "/-, Received payment and Delivered");
    }
  }

  public class Pasta : DominosFoodItem
  {
    public Pasta()
    {
      ItemName = "Italian Red Pasta";
      Price = 129.0f;
    }

    public override void ProcessOrder()
    {
      Console.WriteLine(ItemName + "Order will take 8 mins to cook");
    }

    public override void DeliverFoodItem()
    {
      Console.WriteLine(ItemName + " costed INR. " + Price + "/-, Received payment and Delivered");
    }
  }

  public class ChocoLava : DominosFoodItem
  {
    public ChocoLava()
    {
      ItemName = "Choco Lava";
      Price = 89.0f;
    }

    public override void ProcessOrder()
    {
      Console.WriteLine(ItemName + "Order will take 0 mins to cook");
    }

    public override void DeliverFoodItem()
    {
      Console.WriteLine(ItemName + " costed INR. " + Price + "/-, Received payment and Delivered");
    }
  }

  public class Cashier
  {
    public void PlaceOrder(DominosFoodItem foodItem)
    {
      if (foodItem != null)
      {
        foodItem.TakeOrder(); // Step-1
        foodItem.ProcessOrder(); // Step-2
        foodItem.DeliverFoodItem(); // Step-3
      }
    }
  }

  public class BuilderProgram
  {
    public static void RunBuilder()
    {
      var windowOne = new Cashier();
      DominosFoodItem orderPizza = new Pizza();
      DominosFoodItem orderChocoLava = new ChocoLava();

      windowOne.PlaceOrder(orderPizza);
      windowOne.PlaceOrder(orderChocoLava);
    }
  }
}