using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPattern.Structural
{
	public class Product
	{
		public string Name { get; private set; }
		public string Brand { get; private set; }
		public int Quantity { get; private set; }
		public float Price { get; private set; }

		public Product(string name, string brand, int qty, float price)
		{
			this.Name = name;
			this.Brand = brand;
			this.Quantity = qty;
			this.Price = price;
		}

		public string GetDetails()
		{
			return string.Format("Product Name: {0}, Brand: {1}, Quantity: {2}, Price: {3}",
				this.Name, this.Brand, this.Quantity, this.Price);
		}
	}

	public class PaymentGateway
	{
		public string BankName { get; private set; }
		public long AccountNumber { get; private set; }
		public float TotalAmount { get; set; }

		public PaymentGateway(string bankName, long acNumber)
		{
			this.BankName = bankName;
			this.AccountNumber = acNumber;
		}

		public void PayOnline()
		{
			Console.WriteLine($"Paid thru Online Successfully. [Bank Name: {this.BankName}, A/c No: {this.AccountNumber}, Amount Deducted: {this.TotalAmount}]");
		}
	}

	public class BillInvoice
	{
		private readonly List<Product> _productCollection = new List<Product>();

		public BillInvoice(List<Product> productCollection)
		{
			this._productCollection = productCollection;
		}

		public void PrintInvoice()
		{
			foreach (Product product in _productCollection)
			{
				Console.WriteLine(product.GetDetails());
			}
		}
	}

	public class OrderFacade
	{
		private List<Product> _productsInCart;
		private PaymentGateway _payment;
		private BillInvoice _invoice;

		public void PlaceOrder()
		{
			_productsInCart = new List<Product>()
			{
				new Product("Laptop", "HP", 1, 50000.0f),
				new Product("Mouse", "Logitech", 1, 500.0f),
				new Product("Dock Station", "HP", 1, 650.0f),
				new Product("Head Phone", "Sony", 1, 400.0f)
			};
			_payment = new PaymentGateway("Citi Bank", 123456789);
			_invoice = new BillInvoice(_productsInCart);

			_payment.TotalAmount = _productsInCart.Sum(prod => prod.Quantity * prod.Price);
			_payment.PayOnline();

			_invoice.PrintInvoice();
		}
	}

	public class FacadeProgram
	{
		public static void RunFacade()
		{
			OrderFacade orderFacade = new OrderFacade();
			orderFacade.PlaceOrder();
		}
	}
}
