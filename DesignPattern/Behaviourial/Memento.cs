using System;
using System.Collections.Generic;

namespace DesignPattern.Behaviourial
{
	public interface ICalc
	{
		double Add();
		double Subtract();
		double Multiply();
		double Divide();
	}

	public class SimpleCalculator : ICalc
	{
		public double FirstNumber { get; set; }
		public double SecondNumber { get; set; }

		public double Add()
		{
			double value = (FirstNumber + SecondNumber);
			ResultsCache.Remember(value);
			return value;
		}

		public double Subtract()
		{
			double value = (FirstNumber - SecondNumber);
			ResultsCache.Remember(value);
			return value;
		}

		public double Multiply()
		{
			double value = (FirstNumber * SecondNumber);
			ResultsCache.Remember(value);
			return value;
		}

		public double Divide()
		{
			if (0 == SecondNumber)
			{
				ResultsCache.Remember(double.NaN);
				return double.NaN;
			}
			double value = (FirstNumber / SecondNumber);
			ResultsCache.Remember(value);
			return value;
		}
	}

	public static class ResultsCache
	{
		private static readonly List<double> Cache = new List<double>();

		public static void Remember(double value)
		{
			Cache.Add(value);
		}

		public static void ClearMemory()
		{
			Cache.Clear();
		}

		public static double GetCachedResult(int index)
		{
			return Cache[index];
		}
	}

	public class MementoProgram
	{
		public static void RunMemento()
		{
			SimpleCalculator simpleCalc = new SimpleCalculator();
			simpleCalc.FirstNumber = 20;
			simpleCalc.SecondNumber = 10;

			Console.WriteLine("Add: " + simpleCalc.Add());
			Console.WriteLine("Subtract: " + simpleCalc.Subtract());
			Console.WriteLine("Multiply: " + simpleCalc.Multiply());
			Console.WriteLine("Manual Divide: " + (ResultsCache.GetCachedResult(0) / ResultsCache.GetCachedResult(2)));
		}
	}
}
