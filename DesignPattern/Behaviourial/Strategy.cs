using System;

namespace DesignPattern.Behaviourial
{
	public interface IAlgorithm
	{
		void ApplyLogic();
	}

	public class FlyingLogic : IAlgorithm
	{
		public void ApplyLogic()
		{
			Console.WriteLine(" Is Flying!");
		}
	}

	public class FloatingLogic : IAlgorithm
	{
		public void ApplyLogic()
		{
			Console.WriteLine(" Is Floating!");
		}
	}

	public class RunningLogic : IAlgorithm
	{
		public void ApplyLogic()
		{
			Console.WriteLine(" Is Running!");
		}
	}

	public abstract class Vehicle
	{
		public IAlgorithm Algorithm { get; protected set; }
		public abstract void Go();
	}

	public class Helicopter : Vehicle
	{
		private readonly string _model;
		public Helicopter(string model)
		{
			this._model = model;
			Algorithm = new FlyingLogic();
		}

		public override void Go()
		{
			Console.WriteLine(this._model);
			Algorithm.ApplyLogic();
		}
	}

	public class Boat : Vehicle
	{
		private readonly string _model;
		public Boat(string model)
		{
			this._model = model;
			Algorithm = new FloatingLogic();
		}

		public override void Go()
		{
			Console.WriteLine(this._model);
			Algorithm.ApplyLogic();
		}
	}

	public class Car : Vehicle
	{
		private readonly string _model;
		public Car(string model)
		{
			this._model = model;
			Algorithm = new RunningLogic();
		}

		public override void Go()
		{
			Console.WriteLine(this._model);
			Algorithm.ApplyLogic();
		}
	}

	public class StrategyProgram
	{
		public static void RunStrategy()
		{
			Vehicle flyingObject = new Helicopter("Helicopter MIC 90");
			flyingObject.Go();

			Vehicle floatingObject = new Boat("Venus Boat");
			floatingObject.Go();

			Vehicle runningObject = new Car("Nissan Tiana Car");
			runningObject.Go();
		}
	}
}
