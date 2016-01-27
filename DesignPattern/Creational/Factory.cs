using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DesignPattern.Creational
{
	[AttributeUsage(AttributeTargets.Field)]
	public class WhatType : Attribute
	{
		public Type TypeOf;
	}

	public enum HyundaiCars
	{
		[WhatType(TypeOf = typeof(Santro))]
		SantroCar,
		[WhatType(TypeOf = typeof(I10))]
		I10Car,
		[WhatType(TypeOf = typeof(I20))]
		I20Car,
		[WhatType(TypeOf = typeof(Verna))]
		VernaCar,
		[WhatType(TypeOf = typeof(Sonata))]
		SonataCar
	}

	public abstract class Hyundai
	{
		public abstract string Model { get; }
		public abstract int Year { get; }
		public abstract bool IsAutomatic { get; }
		public abstract bool HasAbs { get; }
		public abstract bool IsSedan { get; }
		public abstract float VolumeDisplacementCC { get; }

		public override string  ToString()
		{
 			 return string.Format("{0} = [Automatic: {1}, Sedan Class: {2}, ABS: {3}, CC: {4}]",
				 this.Model, this.IsAutomatic, this.IsSedan, this.HasAbs, this.VolumeDisplacementCC
			 );
		}
	}

	public class Santro : Hyundai
	{
		public override string Model { get { return "Santro"; } }
		public override int Year { get { return 2010; } }
		public override bool IsAutomatic { get { return false; } }
		public override bool HasAbs { get { return false; } }
		public override bool IsSedan { get { return false; } }
		public override float VolumeDisplacementCC { get { return 1000.0f; } }
	}

	public class I10 : Hyundai
	{
		public override string Model { get { return "I10"; } }
		public override int Year { get { return 2011; } }
		public override bool IsAutomatic { get { return true; } }
		public override bool HasAbs { get { return true; } }
		public override bool IsSedan { get { return false; } }
		public override float VolumeDisplacementCC { get { return 1197.0f; } }
	}

	public class I20 : Hyundai
	{
		public override string Model { get { return "I20"; } }
		public override int Year { get { return 2012; } }
		public override bool IsAutomatic { get { return true; } }
		public override bool HasAbs { get { return true; } }
		public override bool IsSedan { get { return false; } }
		public override float VolumeDisplacementCC { get { return 1350.0f; } }
	}

	public class Verna : Hyundai
	{
		public override string Model { get { return "Verna"; } }
		public override int Year { get { return 2012; } }
		public override bool IsAutomatic { get { return true; } }
		public override bool HasAbs { get { return true; } }
		public override bool IsSedan { get { return true; } }
		public override float VolumeDisplacementCC { get { return 1500.0f; } }
	}

	public class Sonata : Hyundai
	{
		public override string Model { get { return "Sonata"; } }
		public override int Year { get { return 2012; } }
		public override bool IsAutomatic { get { return true; } }
		public override bool HasAbs { get { return true; } }
		public override bool IsSedan { get { return true; } }
		public override float VolumeDisplacementCC { get { return 2000.0f; } }
	}

	public class HyundaiFactory
	{
		private Dictionary<HyundaiCars, Hyundai> _CarMapDictionary = new Dictionary<HyundaiCars, Hyundai>();

		public Hyundai GetCar(HyundaiCars carType)
		{
			Hyundai hyundai = null;

			/* Use Reflection to make job easy */
			MemberInfo memberInfo = typeof(HyundaiCars).GetMember(carType.ToString()).FirstOrDefault();
			WhatType whatType = (WhatType)memberInfo
					.GetCustomAttributes(typeof(WhatType), true)
					.FirstOrDefault();

			if (null != whatType)
			{
				if (!_CarMapDictionary.TryGetValue(carType, out hyundai))
				{
					hyundai = (Hyundai)Activator.CreateInstance(whatType.TypeOf);
					_CarMapDictionary.Add(carType, hyundai);
				}
				return hyundai;
			}
			else
			{
				//--- Alternate Approach (Simple Switch Case)---
				switch (carType)
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
			}
			return hyundai;
		}
	}

	public class FactoryProgram
	{
		public static void RunFactory()
		{
			Hyundai hyundai = null;
			HyundaiFactory factory = new HyundaiFactory();

			hyundai = factory.GetCar(HyundaiCars.VernaCar);
			Console.WriteLine(hyundai.ToString());

			hyundai = factory.GetCar(HyundaiCars.I20Car);
			Console.WriteLine(hyundai.ToString());
		}
	}
}
