using System;

namespace DesignPattern.Behaviourial
{
  public enum ApproveLevel
  {
    None = 0,
    Manager,
    SeniorManager,
    Director
  }

  public class ReImbursement
  {
    public ReImbursement(string empId, string empName, double amount, string reason)
    {
      EmployeeId = empId;
      EmployeeName = empName;
      Amount = amount;
      Reason = reason;

      IsApproved = null;
      ApprovedLevel = ApproveLevel.None;
      ApproveComment = "Not Processed";

      Console.WriteLine("ReImbursement submitted by {0} (Emp. ID: {1}) of Amount INR. {2}/-", EmployeeName, EmployeeId,
        Amount);
    }

    public string EmployeeId { get; }
    public string EmployeeName { get; }
    public double Amount { get; }
    public string Reason { get; private set; }

    public bool? IsApproved { get; set; }
    public ApproveLevel ApprovedLevel { get; set; }
    public string ApproveComment { get; set; }
  }

  public abstract class Approver
  {
    protected Approver NextEscalation;

    public Approver(string approverId, string approverName)
    {
      ApproverId = approverId;
      ApproverName = approverName;
    }

    public string ApproverId { get; private set; }
    public string ApproverName { get; private set; }
    public double LowerThreshold { get; protected set; }
    public double UpperThreshold { get; protected set; }

    public ApproveLevel Level { get; set; }

    public abstract bool Approve(ReImbursement reImbursement);

    public virtual void SetNextEscalation(Approver nextApprover)
    {
      NextEscalation = nextApprover;
    }
  }

  public class Manager : Approver
  {
    public Manager(string approverId, string approverName)
      : base(approverId, approverName)
    {
      Level = ApproveLevel.Manager;
      LowerThreshold = 0.0;
      UpperThreshold = 10000.0;
    }

    public override bool Approve(ReImbursement reImbursement)
    {
      if (reImbursement.Amount <= UpperThreshold)
      {
        reImbursement.IsApproved = true;
        reImbursement.ApprovedLevel = Level;
        reImbursement.ApproveComment = "Approval Done.";
        Console.WriteLine("For ReImbursement made by: " + reImbursement.EmployeeName +
                          ". Approved by Manager, Comment: " + reImbursement.ApproveComment);
        return true;
      }
      if (null != NextEscalation)
      {
        Console.WriteLine("For ReImbursement made by: " + reImbursement.EmployeeName + ". Escalated to next Level to " +
                          NextEscalation.Level);
        return NextEscalation.Approve(reImbursement);
      }
      return false;
    }
  }

  public class SeniorManager : Approver
  {
    public SeniorManager(string approverId, string approverName)
      : base(approverId, approverName)
    {
      Level = ApproveLevel.Manager;
      LowerThreshold = 10001.0;
      UpperThreshold = 50000.0;
    }

    public override bool Approve(ReImbursement reImbursement)
    {
      if ((reImbursement.Amount >= LowerThreshold) && (reImbursement.Amount <= UpperThreshold))
      {
        reImbursement.IsApproved = true;
        reImbursement.ApprovedLevel = Level;
        reImbursement.ApproveComment = "Approval Done.";
        Console.WriteLine("For ReImbursement made by: " + reImbursement.EmployeeName +
                          ". Approved by Senior Manager, Comment: " + reImbursement.ApproveComment);
        return true;
      }
      if (null != NextEscalation)
      {
        Console.WriteLine("For ReImbursement made by: " + reImbursement.EmployeeName + ". Escalated to next Level to " +
                          NextEscalation.Level);
        return NextEscalation.Approve(reImbursement);
      }
      return false;
    }
  }

  public class Director : Approver
  {
    public Director(string approverId, string approverName)
      : base(approverId, approverName)
    {
      Level = ApproveLevel.Manager;
      LowerThreshold = 50001.0;
      UpperThreshold = 1000000.0;
    }

    public override bool Approve(ReImbursement reImbursement)
    {
      if ((reImbursement.Amount >= LowerThreshold) && (reImbursement.Amount <= UpperThreshold))
      {
        reImbursement.IsApproved = true;
        reImbursement.ApprovedLevel = Level;
        reImbursement.ApproveComment = "Approval Done.";
        Console.WriteLine("Approved by Director, Comment: " + reImbursement.ApproveComment);
        return true;
      }
      return false;
    }
  }

  public class ChainOfResponsibilityProgram
  {
    public static void RunChainOfResponsibility()
    {
      var timCabRequest = new ReImbursement("R4322", "Tim Berners-Lee", 900.0, "Took Cab for Airport");
      var itRequest = new ReImbursement("IT", "Team IT", 35000.0, "Purchased Desktop for Team");

      Approver manager = new Manager("Q1234", "James Gosling");
      Approver srManager = new SeniorManager("W1234", "Bill Gates");
      Approver director = new Director("S1234", "Steve Jobs");

      manager.SetNextEscalation(srManager);
      srManager.SetNextEscalation(director);

      manager.Approve(timCabRequest);
      manager.Approve(itRequest);
    }
  }
}