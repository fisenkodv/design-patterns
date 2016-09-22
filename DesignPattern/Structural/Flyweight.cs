using System;
using System.Collections.Generic;

namespace DesignPattern.Structural
{
  public class EmployeeDetails
  {
    public string FullName { get; set; }
    public string Designation { get; set; }
    public string Department { get; set; }
  }

  public class Address
  {
    public string CompanyName { get; set; }
    public string Building { get; set; }
    public string Place { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string PinCode { get; set; }
  }

  public class Contact
  {
    public string Mobile { get; set; }
    public string Office { get; set; }
    public string Fax { get; set; }
  }

  public static class AddressFlyweight
  {
    public static Address Address = new Address
    {
      CompanyName = "Apple Inc.",
      Building = "Apple Store",
      Place = "Central Park",
      City = "NY",
      Country = "USA",
      PinCode = "12345"
    };
  }

  public class BusinessCard
  {
    private readonly Address _address;
    private readonly Contact _contact;
    private readonly EmployeeDetails _employee;

    public BusinessCard(string empName, string designation, string dept, string mobile, string office, string fax)
    {
      _employee = new EmployeeDetails
      {
        FullName = empName,
        Designation = designation,
        Department = dept
      };

      _address = AddressFlyweight.Address;

      _contact = new Contact
      {
        Office = office,
        Mobile = mobile,
        Fax = fax
      };
    }

    public void PrintBusinessCard()
    {
      Console.WriteLine(_employee.FullName);
      Console.WriteLine(_employee.Designation);
      Console.WriteLine(_employee.Department);

      Console.WriteLine(_address.CompanyName);
      Console.WriteLine(_address.Building);
      Console.WriteLine(_address.Place);
      Console.WriteLine(_address.City);
      Console.WriteLine(_address.Country);
      Console.WriteLine(_address.PinCode);

      Console.WriteLine(_contact.Office);
      Console.WriteLine(_contact.Mobile);
      Console.WriteLine(_contact.Fax);
    }
  }

  public class FlyweightProgram
  {
    public static void RunFlyweight()
    {
      var employeesCards = new List<BusinessCard>
      {
        new BusinessCard("John", "Sr. Software Engineer", "GSE", "9243110669", "08041893228", "08041893333"),
        new BusinessCard("Bill", "Sr. Tech Specialist", "GSE", "1234567890", "08041893118", "08041893333"),
        new BusinessCard("Ted", "Manager", "GSE", "9876543210", "08041893448", "08041893333")
      };

      foreach (var card in employeesCards)
        card.PrintBusinessCard();
    }
  }
}