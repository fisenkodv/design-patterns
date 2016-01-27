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
		public string EmployeeId { get; private set; }
		public string EmployeeName { get; private set; }
		public double Amount { get; private set; }
		public string Reason { get; private set; }

		public bool? IsApproved { get; set; }
		public ApproveLevel ApprovedLevel { get; set; }
		public string ApproveComment { get; set; }

		public ReImbursement(string empID, string empName, double amount, string reason)
		{
			this.EmployeeId = empID;
			this.EmployeeName = empName;
			this.Amount = amount;
			this.Reason = reason;

			this.IsApproved = null;
			this.ApprovedLevel = ApproveLevel.None;
			this.ApproveComment = "Not Processed";

			Console.WriteLine("ReImbursement submitted by {0} (Emp. ID: {1}) of Amount INR. {2}/-", this.EmployeeName, this.EmployeeId, this.Amount);
		}
	}

	public abstract class Approver
	{
		public string ApproverId { get; private set; }
		public string ApproverName { get; private set; }
		public double LowerThreshold { get; protected set; }
		public double UpperThreshold { get; protected set; }

		public ApproveLevel Level { get; set; }

		protected Approver NextEscalation;

		public Approver(string approverId, string approverName)
		{
			this.ApproverId = approverId;
			this.ApproverName = approverName;
		}

		public abstract bool Approve(ReImbursement reImbursement);

		public virtual void SetNextEscalation(Approver nextApprover)
		{
			this.NextEscalation = nextApprover;
		}
	}

	public class Manager : Approver
	{
		public Manager(string approverId, string approverName)
			: base(approverId, approverName)
		{
			this.Level = ApproveLevel.Manager;
			this.LowerThreshold = 0.0;
			this.UpperThreshold = 10000.0;
		}

		public override bool Approve(ReImbursement reImbursement)
		{
			if (reImbursement.Amount <= this.UpperThreshold)
			{
				reImbursement.IsApproved = true;
				reImbursement.ApprovedLevel = this.Level;
				reImbursement.ApproveComment = "Approval Done.";
				Console.WriteLine("For ReImbursement made by: " + reImbursement.EmployeeName + ". Approved by Manager, Comment: " + reImbursement.ApproveComment);
				return true;
			}
			else
			{
				if (null != this.NextEscalation)
				{
					Console.WriteLine("For ReImbursement made by: " + reImbursement.EmployeeName + ". Escalated to next Level to " + this.NextEscalation.Level.ToString());
					return this.NextEscalation.Approve(reImbursement);
				}
				return false;
			}
		}
	}

	public class SeniorManager : Approver
	{
		public SeniorManager(string approverId, string approverName)
			: base(approverId, approverName)
		{
			this.Level = ApproveLevel.Manager;
			this.LowerThreshold = 10001.0;
			this.UpperThreshold = 50000.0;
		}

		public override bool Approve(ReImbursement reImbursement)
		{
			if (reImbursement.Amount >= this.LowerThreshold && reImbursement.Amount <= this.UpperThreshold)
			{
				reImbursement.IsApproved = true;
				reImbursement.ApprovedLevel = this.Level;
				reImbursement.ApproveComment = "Approval Done.";
				Console.WriteLine("For ReImbursement made by: " + reImbursement.EmployeeName + ". Approved by Senior Manager, Comment: " + reImbursement.ApproveComment);
				return true;
			}
			else
			{
				if (null != this.NextEscalation)
				{
					Console.WriteLine("For ReImbursement made by: " + reImbursement.EmployeeName + ". Escalated to next Level to " + this.NextEscalation.Level);
					return this.NextEscalation.Approve(reImbursement);
				}
				return false;
			}
		}
	}

	public class Director : Approver
	{
		public Director(string approverID, string approverName)
			: base(approverID, approverName)
		{
			this.Level = ApproveLevel.Manager;
			this.LowerThreshold = 50001.0;
			this.UpperThreshold = 1000000.0;
		}

		public override bool Approve(ReImbursement reImbursement)
		{
			if (reImbursement.Amount >= this.LowerThreshold && reImbursement.Amount <= this.UpperThreshold)
			{
				reImbursement.IsApproved = true;
				reImbursement.ApprovedLevel = this.Level;
				reImbursement.ApproveComment = "Approval Done.";
				Console.WriteLine("Approved by Director, Comment: " + reImbursement.ApproveComment);
				return true;
			}
			else
			{
				return false;
			}
		}
	}

	public class ChainOfResponsibilityProgram
	{
		public static void RunChainOfResponsibility()
		{
			ReImbursement timCabRequest = new ReImbursement("R4322", "Tim Berners-Lee", 900.0, "Took Cab for Airport");
			ReImbursement itRequest = new ReImbursement("IT", "Team IT", 35000.0, "Purchased Desktop for Team");

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
