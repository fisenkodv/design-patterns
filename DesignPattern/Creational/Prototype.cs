using System;

namespace DesignPattern.Creational
{
	public interface ICloneable<T>
	{
		T Clone();
	}

	public class DNASample : ICloneable<DNASample>
	{
		public string OwnerName { get; private set; }
		public string Samples { get; private set; }

		public DNASample(string owner, string samples)
		{
			this.OwnerName = owner;
			this.Samples = samples;
		}

		#region ICloneable Members

		public DNASample Clone()
		{
			DNASample cloneDna = new DNASample(this.OwnerName, this.Samples);
			return cloneDna;
		}

		#endregion
	}

	public abstract class DNATest
	{
		public abstract void PerformTest(DNASample sampleOne, DNASample sampleTwo);
	}

	public class MitochondrialTest : DNATest
	{
		public override void PerformTest(DNASample sampleOne, DNASample sampleTwo)
		{
			Console.WriteLine("Performed mtDNA Test to check whether " + sampleOne.OwnerName + " and " + sampleTwo.OwnerName + " share a common ancester");
		}
	}

	public class PaternityTest : DNATest
	{
		public override void PerformTest(DNASample sampleOne, DNASample sampleTwo)
		{
			Console.WriteLine("Performed Y-Chromosome Test to check whether  " + sampleOne.OwnerName + " and " + sampleTwo.OwnerName + " having father-child relationship");
		}
	}

	public class PrototypeProgram
	{
		public static void RunPrototype()
		{
			DNASample sampleOne = new DNASample("Bill", "ACTGAGTCGTCA");
			DNASample sampleTwo = new DNASample("Steve", "GTACAGTCATGG");
			DNASample sampleThree = new DNASample("Linus", "CGTAAAGTGCTT");

			DNATest dnaTestObject = new MitochondrialTest();
			dnaTestObject.PerformTest(sampleOne.Clone(), sampleTwo.Clone());

			dnaTestObject = new PaternityTest();
			dnaTestObject.PerformTest(sampleOne.Clone(), sampleThree.Clone());
		}
	}
}
