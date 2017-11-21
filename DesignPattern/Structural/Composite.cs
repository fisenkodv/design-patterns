using System;
using System.Collections.Generic;

namespace DesignPattern.Structural
{
  public interface IEmployee
  {
    string Name { get; set; }
    string Department { get; set; }
    string Designation { get; set; }

    bool AddSubordinate(IEmployee employee);
    bool RemoveSubordinate(IEmployee employee);
    void Display(int level);
  }

  public class Branch : IEmployee
  {
    private readonly IList<IEmployee> _subordinates = new List<IEmployee>();

    public Branch(string name, string designation, string department)
    {
      Name = name;
      Designation = designation;
      Department = department;
    }

    public string Name { get; set; }

    public string Department { get; set; }

    public string Designation { get; set; }

    public bool AddSubordinate(IEmployee employee)
    {
      _subordinates.Add(employee);
      return true;
    }

    public bool RemoveSubordinate(IEmployee employee)
    {
      return _subordinates.Remove(employee);
    }

    public void Display(int level)
    {
      Console.WriteLine($"{new string('-', level)}{Name} ({Designation}) [Dept: {Department}]");

      level += 3;
      foreach (var subordinate in _subordinates)
      {
        subordinate.Display(level);
      }
    }
  }

  public class Leaf : IEmployee
  {
    public Leaf(string name, string designation, string department)
    {
      Name = name;
      Designation = designation;
      Department = department;
    }

    public string Name { get; set; }

    public string Department { get; set; }

    public string Designation { get; set; }

    public bool AddSubordinate(IEmployee employee)
    {
      throw new NotImplementedException("Invalid Leaf Operation: AddSubordinate().");
    }

    public bool RemoveSubordinate(IEmployee employee)
    {
      throw new NotImplementedException("Invalid Leaf Operation: RemoveSubordinate().");
    }

    public void Display(int level)
    {
      var empDisp = new string('-', level) + Name + " (" + Designation + ") [Dept: " + Department + "]";
      Console.WriteLine(empDisp);
    }
  }

  public class CompositeProgram
  {
    public static void RunComposite()
    {
      IEmployee director = new Branch("John", "Director", "GSE");
      IEmployee manager = new Branch("Steve", "Manager", "GSE");
      IEmployee srTechSpec1 = new Branch("David", "Sr. Technical Specialist", "GSE");
      IEmployee srTechSpec2 = new Branch("Bill", "Sr. Technical Specialist", "GSE");
      IEmployee srSoftEng = new Leaf("Ted", "Sr. Software Engineer", "GSE");
      IEmployee softEng = new Leaf("Tim", "Software Engineer", "GSE");

      srTechSpec1.AddSubordinate(srSoftEng);
      srTechSpec2.AddSubordinate(softEng);

      manager.AddSubordinate(srTechSpec1);
      manager.AddSubordinate(srTechSpec2);

      director.AddSubordinate(manager);
      director.Display(1);
    }
  }
}