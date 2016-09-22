using System;
using System.Globalization;

namespace DesignPattern.Structural
{
  public interface IPayment
  {
    void PayFund(float amount);
  }

  public class Payment : IPayment
  {
    public string BankName { get; set; }

    public long AccoutnNumber { get; set; }

    public DateTime PaymentDate { get; set; }

    public string RecepientName { get; set; }

    public void PayFund(float amount)
    {
      string response =
        $"Paid to Mr./Mrs./Miss. {RecepientName} Amount INR. {amount}/- [From A/C: {AccoutnNumber}, Bank: {BankName}] On date of {PaymentDate.ToString(CultureInfo.InvariantCulture)}";

      Console.WriteLine(response);
    }
  }

  public class CheckProxy : IPayment
  {
    private readonly bool _isSigned;
    private readonly Payment _payment = new Payment();

    public CheckProxy(long acNumber, string bankName, string receipientName)
    {
      _payment.AccoutnNumber = acNumber;
      _payment.BankName = bankName;
      _payment.RecepientName = receipientName;
      _payment.PaymentDate = DateTime.Now;

      _isSigned = true;
    }

    public void PayFund(float amount)
    {
      if (_isSigned)
      {
        _payment.PayFund(amount);
        Console.WriteLine("Paid thru Check #123456 Successfully.");
      }
    }
  }

  public class OnlineFundTransfer : IPayment
  {
    private readonly bool _isVerified;
    private readonly Payment _payment = new Payment();

    public OnlineFundTransfer(long acNumber, string bankName, string receipientName)
    {
      _payment.AccoutnNumber = acNumber;
      _payment.BankName = bankName;
      _payment.RecepientName = receipientName;
      _payment.PaymentDate = DateTime.Now;

      _isVerified = true;
    }

    public void PayFund(float amount)
    {
      if (_isVerified)
      {
        _payment.PayFund(amount);
        Console.WriteLine("Transferred Online Successfully. ACK #936782618.");
      }
    }
  }

  public class ProxyProgram
  {
    public static void RunProxy()
    {
      IPayment checkPayment = new CheckProxy(12345678, "ICICI", "UNICEF");
      checkPayment.PayFund(2500);

      IPayment onlinePayment = new OnlineFundTransfer(12345678, "CITI", "My Mother");
      onlinePayment.PayFund(30000);
    }
  }
}