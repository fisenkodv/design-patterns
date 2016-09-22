using System;
using DesignPattern.Behaviourial;
using DesignPattern.Creational;
using DesignPattern.Structural;

namespace DesignPattern
{
  public class Program
  {
    public delegate void RunDesignPatternMethod();

    public static void Main(string[] args)
    {
      RunDesignPatternMethod runDesignPatternMethod = AdapterProgram.RunAdapter;
      runDesignPatternMethod += BridgeProgram.RunBridge;
      runDesignPatternMethod += CompositeProgram.RunComposite;
      runDesignPatternMethod += DecoratorProgram.RunDecorator;
      runDesignPatternMethod += FacadeProgram.RunFacade;
      runDesignPatternMethod += FlyweightProgram.RunFlyweight;
      runDesignPatternMethod += ProxyProgram.RunProxy;

      runDesignPatternMethod += ChainOfResponsibilityProgram.RunChainOfResponsibility;
      runDesignPatternMethod += IteratorProgram.RunIterator;
      runDesignPatternMethod += MediatorProgram.RunMediator;
      runDesignPatternMethod += MementoProgram.RunMemento;
      runDesignPatternMethod += ObserverProgram.RunObserver;
      runDesignPatternMethod += StateProgram.RunState;
      runDesignPatternMethod += StrategyProgram.RunStrategy;
      runDesignPatternMethod += TemplateProgram.RunTemplate;
      runDesignPatternMethod += VisitorProgram.RunVisitor;

      runDesignPatternMethod += AbstractFactoryProgram.RunAbstractFactory;
      runDesignPatternMethod += BuilderProgram.RunBuilder;
      runDesignPatternMethod += FactoryProgram.RunFactory;
      runDesignPatternMethod += PrototypeProgram.RunPrototype;
      runDesignPatternMethod += SingletonProgram.RunSingleton;

      foreach (var @delegate in runDesignPatternMethod.GetInvocationList())
      {
        Console.WriteLine("****** " + @delegate.Method.DeclaringType?.Name + "." + @delegate.Method.Name + " ******");
        @delegate.DynamicInvoke(null);
        Console.WriteLine(new string('=', 80));
      }
      Console.ReadLine();
    }
  }
}