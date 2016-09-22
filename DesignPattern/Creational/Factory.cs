using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPattern.Creational
{
  [AttributeUsage( AttributeTargets.Field )]
  public class WhatType : Attribute
  {
    public Type TypeOf;
  }

  public enum HyundaiCars
  {
    [WhatType( TypeOf = typeof( Santro ) )]
    SantroCar,
    [WhatType( TypeOf = typeof( I10 ) )]
    I10Car,
    [WhatType( TypeOf = typeof( I20 ) )]
    I20Car,
    [WhatType( TypeOf = typeof( Verna ) )]
    VernaCar,
    [WhatType( TypeOf = typeof( Sonata ) )]
    SonataCar
  }

  public abstract class Hyundai
  {
    public abstract string Model { get; }
    public abstract int Year { get; }
    public abstract bool IsAutomatic { get; }
    public abstract bool HasAbs { get; }
    public abstract bool IsSedan { get; }
    public abstract float VolumeDisplacementCc { get; }

    public override string ToString()
    {
      return $"{Model} = [Automatic: {IsAutomatic}, Sedan Class: {IsSedan}, ABS: {HasAbs}, CC: {VolumeDisplacementCc}]";
    }
  }

  public class Santro : Hyundai
  {
    public override string Model => "Santro";

    public override int Year => 2010;

    public override bool IsAutomatic => false;

    public override bool HasAbs => false;

    public override bool IsSedan => false;

    public override float VolumeDisplacementCc => 1000.0f;
  }

  public class I10 : Hyundai
  {
    public override string Model => "I10";

    public override int Year => 2011;

    public override bool IsAutomatic => true;

    public override bool HasAbs => true;

    public override bool IsSedan => false;

    public override float VolumeDisplacementCc => 1197.0f;
  }

  public class I20 : Hyundai
  {
    public override string Model => "I20";

    public override int Year { get; } = 2012;

    public override bool IsAutomatic => true;

    public override bool HasAbs => true;

    public override bool IsSedan => false;

    public override float VolumeDisplacementCc => 1350.0f;
  }

  public class Verna : Hyundai
  {
    public override string Model => "Verna";

    public override int Year => 2012;

    public override bool IsAutomatic => true;

    public override bool HasAbs => true;

    public override bool IsSedan => true;

    public override float VolumeDisplacementCc => 1500.0f;
  }

  public class Sonata : Hyundai
  {
    public override string Model => "Sonata";

    public override int Year => 2012;

    public override bool IsAutomatic => true;

    public override bool HasAbs => true;

    public override bool IsSedan => true;

    public override float VolumeDisplacementCc => 2000.0f;
  }

  public class HyundaiFactory
  {
    private readonly Dictionary<HyundaiCars, Hyundai> _carMapDictionary = new Dictionary<HyundaiCars, Hyundai>();

    public Hyundai GetCar( HyundaiCars carType )
    {
      Hyundai hyundai = null;

      /* Use Reflection to make job easy */
      var memberInfo = typeof( HyundaiCars ).GetMember( carType.ToString() ).FirstOrDefault();
      if ( memberInfo != null )
      {
        var whatType = (WhatType)memberInfo
          .GetCustomAttributes( typeof( WhatType ), true )
          .FirstOrDefault();

        if ( null != whatType )
        {
          if ( !_carMapDictionary.TryGetValue( carType, out hyundai ) )
          {
            hyundai = (Hyundai)Activator.CreateInstance( whatType.TypeOf );
            _carMapDictionary.Add( carType, hyundai );
          }
          return hyundai;
        }
      }
      //--- Alternate Approach (Simple Switch Case)---
      switch ( carType )
      {
        case HyundaiCars.SantroCar:
          hyundai = new Santro();
          break;
        case HyundaiCars.I10Car:
          hyundai = new I10();
          break;
        case HyundaiCars.I20Car:
          hyundai = new I20();
          break;
        case HyundaiCars.VernaCar:
          hyundai = new Verna();
          break;
        case HyundaiCars.SonataCar:
          hyundai = new Sonata();
          break;
      }
      return hyundai;
    }
  }

  public class FactoryProgram
  {
    public static void RunFactory()
    {
      var factory = new HyundaiFactory();

      var hyundai = factory.GetCar( HyundaiCars.VernaCar );
      Console.WriteLine( hyundai.ToString() );

      hyundai = factory.GetCar( HyundaiCars.I20Car );
      Console.WriteLine( hyundai.ToString() );
    }
  }
}