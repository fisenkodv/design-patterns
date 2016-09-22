using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPattern.Structural
{
  public class Product
  {
    public Product(string name, string brand, int qty, float price)
    {
      Name = name;
      Brand = brand;
      Quantity = qty;
      Price = price;
    }

    public string Name { get; }
    public string Brand { get; }
    public int Quantity { get; }
    public float Price { get; }

    public string GetDetails()
    {
      return string.Format("Product Name: {0}, Brand: {1}, Quantity: {2}, Price: {3}",
        Name, Brand, Quantity, Price);
    }
  }

  public class PaymentGateway
  {
    public PaymentGateway(string bankName, long acNumber)
    {
      BankName = bankName;
      AccountNumber = acNumber;
    }

    public string BankName { get; }
    public long AccountNumber { get; }
    public float TotalAmount { get; set; }

    public void PayOnline()
    {
      Console.WriteLine(
        $"Paid thru Online Successfully. [Bank Name: {BankName}, A/c No: {AccountNumber}, Amount Deducted: {TotalAmount}]");
    }
  }

  public class BillInvoice
  {
    private readonly List<Product> _productCollection;

    public BillInvoice(List<Product> productCollection)
    {
      _productCollection = productCollection;
    }

    public void PrintInvoice()
    {
      foreach (var product in _productCollection)
        Console.WriteLine(product.GetDetails());
    }
  }

  public class OrderFacade
  {
    private BillInvoice _invoice;
    private PaymentGateway _payment;
    private List<Product> _productsInCart;

    public void PlaceOrder()
    {
      _productsInCart = new List<Product>
      {
        new Product("Laptop", "HP", 1, 50000.0f),
        new Product("Mouse", "Logitech", 1, 500.0f),
        new Product("Dock Station", "HP", 1, 650.0f),
        new Product("Head Phone", "Sony", 1, 400.0f)
      };
      _payment = new PaymentGateway("Citi Bank", 123456789);
      _invoice = new BillInvoice(_productsInCart);

      _payment.TotalAmount = _productsInCart.Sum(prod => prod.Quantity*prod.Price);
      _payment.PayOnline();

      _invoice.PrintInvoice();
    }
  }

  public class FacadeProgram
  {
    public static void RunFacade()
    {
      var orderFacade = new OrderFacade();
      orderFacade.PlaceOrder();
    }
  }
}