using System;
using System.Xml.Linq;

namespace DesignPattern.Behaviourial
{
  public interface IVisitor
  {
    void Visit(Details details);
  }

  public class XmlVisitor : IVisitor
  {
    public void Visit(Details details)
    {
      if (details is Employee employee)
        EmployeeToXml(employee);
      else if (details is Address address)
        AddressToXml(address);
      else if (details is Contact contact)
        ContactToXml(contact);
    }

    private static void EmployeeToXml(Employee employee)
    {
      var element = new XElement("Employee",
        new XElement("Name", employee.Name),
        new XElement("Number", employee.RegNumber),
        new XElement("Designation", employee.Designation),
        new XElement("Department", employee.Department)
      );
      Console.WriteLine(element.ToString());
    }

    private static void AddressToXml(Address address)
    {
      var element = new XElement("Address",
        new XElement("Building", address.Building),
        new XElement("City", address.City),
        new XElement("Country", address.Country)
      );
      Console.WriteLine(element.ToString());
    }

    private static void ContactToXml(Contact contact)
    {
      var element = new XElement("Contact",
        new XElement("Mobile", contact.Mobile),
        new XElement("Office", contact.Office),
        new XElement("Fax", contact.Fax)
      );
      Console.WriteLine(element.ToString());
    }
  }

  public class TextVisitor : IVisitor
  {
    public void Visit(Details details)
    {
      if (details is Employee employee)
        EmployeeToText(employee);
      else if (details is Address address)
        AddressToText(address);
      else if (details is Contact contact)
        ContactToText(contact);
    }

    private static void EmployeeToText(Employee employee)
    {
      Console.WriteLine("Employee: [Name: {0}, Number:{1}, Designation: {2}, Department: {3}]", employee.Name,
        employee.RegNumber, employee.Designation, employee.Department);
    }

    private static void AddressToText(Address address)
    {
      Console.WriteLine("Address: [Building: {0}, City: {1}, Country: {2}]", address.Building, address.City,
        address.Country);
    }

    private static void ContactToText(Contact contact)
    {
      Console.WriteLine("Contact: [Mobile: {0}, Office:{1}, Fax: {2}]", contact.Mobile, contact.Office, contact.Fax);
    }
  }

  public class Details
  {
    public virtual void Accept(IVisitor visitor)
    {
      visitor.Visit(this);
    }
  }

  public class Employee : Details
  {
    public Employee(string name, string regNumber, string designation, string dept)
    {
      Name = name;
      RegNumber = regNumber;
      Designation = designation;
      Department = dept;
    }

    public string Name { get; }
    public string RegNumber { get; }
    public string Designation { get; }
    public string Department { get; }
  }

  public class Address : Details
  {
    public Address(string building, string city, string country)
    {
      Building = building;
      City = city;
      Country = country;
    }

    public string Building { get; }
    public string City { get; }
    public string Country { get; }
  }

  public class Contact : Details
  {
    public Contact(string mobile, string office, string fax)
    {
      Mobile = mobile;
      Office = office;
      Fax = fax;
    }

    public string Mobile { get; }
    public string Office { get; }
    public string Fax { get; }
  }

  public class VisitorProgram
  {
    public static void RunVisitor()
    {
      IVisitor xmlVisitor = new XmlVisitor();
      IVisitor textVisitor = new TextVisitor();

      Details detail = new Employee("Bill Gates", "12345", "Bill and Melinda Gates Foundation", "CEO");
      detail.Accept(xmlVisitor);
      detail.Accept(textVisitor);

      detail = new Address("98102", "Seattle", "USA");
      detail.Accept(xmlVisitor);
      detail.Accept(textVisitor);

      detail = new Contact("9243110669", "08041893228", "08041893333");
      detail.Accept(xmlVisitor);
      detail.Accept(textVisitor);
    }
  }
}