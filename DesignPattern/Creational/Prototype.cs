using System;

namespace DesignPattern.Creational
{
  public interface ICloneable<out T>
  {
    T Clone();
  }

  public class DnaSample : ICloneable<DnaSample>
  {
    public DnaSample(string owner, string samples)
    {
      OwnerName = owner;
      Samples = samples;
    }

    public string OwnerName { get; }
    public string Samples { get; }

    public DnaSample Clone()
    {
      var cloneDna = new DnaSample(OwnerName, Samples);
      return cloneDna;
    }
  }

  public abstract class DnaTest
  {
    public abstract void PerformTest(DnaSample sampleOne, DnaSample sampleTwo);
  }

  public class MitochondrialTest : DnaTest
  {
    public override void PerformTest(DnaSample sampleOne, DnaSample sampleTwo)
    {
      Console.WriteLine("Performed mtDNA Test to check whether " + sampleOne.OwnerName + " and " + sampleTwo.OwnerName +
                        " share a common ancester");
    }
  }

  public class PaternityTest : DnaTest
  {
    public override void PerformTest(DnaSample sampleOne, DnaSample sampleTwo)
    {
      Console.WriteLine("Performed Y-Chromosome Test to check whether  " + sampleOne.OwnerName + " and " +
                        sampleTwo.OwnerName + " having father-child relationship");
    }
  }

  public class PrototypeProgram
  {
    public static void RunPrototype()
    {
      var sampleOne = new DnaSample("Bill", "ACTGAGTCGTCA");
      var sampleTwo = new DnaSample("Steve", "GTACAGTCATGG");
      var sampleThree = new DnaSample("Linus", "CGTAAAGTGCTT");

      DnaTest dnaTestObject = new MitochondrialTest();
      dnaTestObject.PerformTest(sampleOne.Clone(), sampleTwo.Clone());

      dnaTestObject = new PaternityTest();
      dnaTestObject.PerformTest(sampleOne.Clone(), sampleThree.Clone());
    }
  }
}