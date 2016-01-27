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
			if (details is Employee)
			{
				EmployeeToXml(details as Employee);
			}
			else if (details is Address)
			{
				AddressToXml(details as Address);
			}
			else if (details is Contact)
			{
				ContactToXml(details as Contact);
			}
		}

		private void EmployeeToXml(Employee employee)
		{
			XElement element = new XElement("Employee",
				new XElement("Name", employee.Name),
				new XElement("Number", employee.RegNumber),
				new XElement("Designation", employee.Designation),
				new XElement("Department", employee.Department)
			);
			Console.WriteLine(element.ToString());
		}

		private void AddressToXml(Address address)
		{
			XElement element = new XElement("Address",
				new XElement("Building", address.Building),
				new XElement("City", address.City),
				new XElement("Country", address.Country)
			);
			Console.WriteLine(element.ToString());
		}

		private void ContactToXml(Contact contact)
		{
			XElement element = new XElement("Contact",
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
			if (details is Employee)
			{
				EmployeeToText(details as Employee);
			}
			else if (details is Address)
			{
				AddressToText(details as Address);
			}
			else if (details is Contact)
			{
				ContactToText(details as Contact);
			}
		}

		private void EmployeeToText(Employee employee)
		{
			Console.WriteLine("Employee: [Name: {0}, Number:{1}, Designation: {2}, Department: {3}]", employee.Name, employee.RegNumber, employee.Designation, employee.Department);
		}

		private void AddressToText(Address address)
		{
			Console.WriteLine("Address: [Building: {0}, City: {1}, Country: {2}]", address.Building, address.City, address.Country);
		}

		private void ContactToText(Contact contact)
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
		public string Name { get; private set; }
		public string RegNumber { get; private set; }
		public string Designation { get; private set; }
		public string Department { get; private set; }

		public Employee(string name, string regNumber, string designation, string dept)
		{
			this.Name = name;
			this.RegNumber = regNumber;
			this.Designation = designation;
			this.Department = dept;
		}
	}

	public class Address : Details
	{
		public string Building { get; private set; }
		public string City { get; private set; }
		public string Country { get; private set; }

		public Address(string building, string city, string country)
		{
			this.Building = building;
			this.City = city;
			this.Country = country;
		}
	}

	public class Contact : Details
	{
		public string Mobile { get; private set; }
		public string Office { get; private set; }
		public string Fax { get; private set; }

		public Contact(string mobile, string office, string fax)
		{
			this.Mobile = mobile;
			this.Office = office;
			this.Fax = fax;
		}
	}

	public class VisitorProgram
	{
		public static void RunVisitor()
		{
			IVisitor xmlVisitor = new XmlVisitor();
			IVisitor textVisitor = new TextVisitor();
			Details detail = null;

			detail = new Employee("Bill Gates", "12345", "Bill and Melinda Gates Foundation", "CEO");
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
