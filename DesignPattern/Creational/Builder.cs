using System;

namespace DesignPattern.Creational
{
	public abstract class DominosFoodItem
	{
		public string ItemName { get; protected set; }
		public float Price { get; protected set; }

		public virtual void TakeOrder()
		{
			Console.WriteLine("Order Taken for " + this.ItemName);
		}

		public abstract void ProcessOrder();
		public abstract void DeliverFoodItem();
	}

	public class Pizza : DominosFoodItem
	{
		public Pizza()
		{
			this.ItemName = "Dominos Cheese Pizza";
			this.Price = 475.0f;
		}

		public override void ProcessOrder()
		{
			Console.WriteLine(this.ItemName + "Order will take 15 mins to cook");
		}

		public override void DeliverFoodItem()
		{
			Console.WriteLine(this.ItemName + " costed INR. " + this.Price + "/-, Received payment and Delivered");
		}
	}

	public class Pasta : DominosFoodItem
	{
		public Pasta()
		{
			this.ItemName = "Italian Red Pasta";
			this.Price = 129.0f;
		}

		public override void ProcessOrder()
		{
			Console.WriteLine(this.ItemName + "Order will take 8 mins to cook");
		}

		public override void DeliverFoodItem()
		{
			Console.WriteLine(this.ItemName + " costed INR. " + this.Price + "/-, Received payment and Delivered");
		}
	}

	public class ChocoLava : DominosFoodItem
	{
		public ChocoLava()
		{
			this.ItemName = "Choco Lava";
			this.Price = 89.0f;
		}

		public override void ProcessOrder()
		{
			Console.WriteLine(this.ItemName + "Order will take 0 mins to cook");
		}

		public override void DeliverFoodItem()
		{
			Console.WriteLine(this.ItemName + " costed INR. " + this.Price + "/-, Received payment and Delivered");
		}
	}

	public class Cashier /* Director to Construct Object */
	{
		public void PlaceOrder(DominosFoodItem foodItem)
		{
			if (null != foodItem)
			{
				foodItem.TakeOrder();		// Step-1
				foodItem.ProcessOrder();	// Step-2
				foodItem.DeliverFoodItem();	// Step-3
			}
		}
	}

	public class BuilderProgram
	{
		public static void RunBuilder()
		{
			Cashier windowOne = new Cashier();
			DominosFoodItem orderPizza = new Pizza();
			DominosFoodItem orderChocoLava = new ChocoLava();

			windowOne.PlaceOrder(orderPizza);
			windowOne.PlaceOrder(orderChocoLava);
		}
	}
}
