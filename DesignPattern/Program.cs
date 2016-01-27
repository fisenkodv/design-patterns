using System;

namespace DesignPattern
{
	public class Program
	{
		public delegate void RunDesignPatternMethod();

		public static void Main(string[] args)
		{
			RunDesignPatternMethod runDesignPatternMethod = new RunDesignPatternMethod(Structural.AdapterProgram.RunAdapter);
			runDesignPatternMethod += Structural.BridgeProgram.RunBridge;
			runDesignPatternMethod += Structural.CompositeProgram.RunComposite;
			runDesignPatternMethod += Structural.DecoratorProgram.RunDecorator;
			runDesignPatternMethod += Structural.FacadeProgram.RunFacade;
			runDesignPatternMethod += Structural.FlyweightProgram.RunFlyweight;
			runDesignPatternMethod += Structural.ProxyProgram.RunProxy;

			runDesignPatternMethod += Behaviourial.ChainOfResponsibilityProgram.RunChainOfResponsibility;
			runDesignPatternMethod += Behaviourial.IteratorProgram.RunIterator;
			runDesignPatternMethod += Behaviourial.MediatorProgram.RunMediator;
			runDesignPatternMethod += Behaviourial.MementoProgram.RunMemento;
			runDesignPatternMethod += Behaviourial.ObserverProgram.RunObserver;
			runDesignPatternMethod += Behaviourial.StateProgram.RunState;
			runDesignPatternMethod += Behaviourial.StrategyProgram.RunStrategy;
			runDesignPatternMethod += Behaviourial.TemplateProgram.RunTemplate;
			runDesignPatternMethod += Behaviourial.VisitorProgram.RunVisitor;

			runDesignPatternMethod += Creational.AbstractFactoryProgram.RunAbstractFactory;
			runDesignPatternMethod += Creational.BuilderProgram.RunBuilder;
			runDesignPatternMethod += Creational.FactoryProgram.RunFactory;
			runDesignPatternMethod += Creational.PrototypeProgram.RunPrototype;
			runDesignPatternMethod += Creational.SingletonProgram.RunSingleton;

			foreach (Delegate @delegate in runDesignPatternMethod.GetInvocationList())
			{
				Console.WriteLine("****** " + @delegate.Method.DeclaringType.Name + "." + @delegate.Method.Name + " ******");
				@delegate.DynamicInvoke(null);
				Console.WriteLine(new string('=', 80));
			}
			Console.ReadLine();
		}
	}
}
