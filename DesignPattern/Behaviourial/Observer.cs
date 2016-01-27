using System;
using System.Collections.Generic;

namespace DesignPattern.Behaviourial
{
	public interface IStock
	{
		string Symbol { get; }
		double Price { get; set; }

		bool Register(IInvestor investor);
		bool UnRegister(IInvestor investor);
		void Notify();
	}

	public interface IInvestor
	{
		void Update(IStock stock);
	}

	public class Investor : IInvestor
	{
		public string Name { get; private set; }
		public long ID { get; private set; }

		public Investor(long id, string name)
		{
			this.ID = id;
			this.Name = name;
		}

		public void Update(IStock stock)
		{
			Stock stockObj = (stock as Stock);
			if (null != stockObj)
			{
				Console.WriteLine("Notified: {0}[Trading ID #{1}] Of {2} changed to {3:C}", this.Name, this.ID, stockObj.Symbol, stockObj.Price);
			}
		}
	}

	public class Stock : IStock
	{
		private readonly List<IInvestor> _investors = new List<IInvestor>();
		private double _price;

		public string Symbol { get; }

		public double Price
		{
			get { return _price; }
			set
			{
				_price = value;
				this.Notify();
			}
		}

		public Stock(string symbol, double price)
		{
			this.Symbol = symbol;
			this.Price = price;
		}

		public bool Register(IInvestor investor)
		{
			_investors.Add(investor);
			return true;
		}

		public bool UnRegister(IInvestor investor)
		{
			return _investors.Remove(investor);
		}

		public void Notify()
		{
			foreach (IInvestor investor in _investors)
			{
				investor.Update(this);
			}
		}
	}

	public class ObserverProgram
	{
		public static void RunObserver()
		{
			IInvestor steve = new Investor(100, "Steve Jobs");
			IInvestor bill = new Investor(101, "Bill Gates");
			IInvestor james = new Investor(102, "James Gosling");

			IStock philipsStock = new Stock("Apple Inc.", 1000.0);
			philipsStock.Register(steve);
			philipsStock.Register(bill);

			IStock aluStock = new Stock("Microsoft Corp.", 500.0);
			aluStock.Register(steve);
			aluStock.Register(james);

			philipsStock.Price += 2.0;
			aluStock.Price += 3.5;

			philipsStock.Price -= 0.7;
			aluStock.Price -= 1.4;
		}
	}

}
