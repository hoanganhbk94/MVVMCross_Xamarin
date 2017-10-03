using System;
namespace HelloWorld
{
	public class CalculationService : ICalculationService
	{
		public double TipAmount(double subTotal, int generosity)
		{
			return subTotal * ((double)generosity) / 100.0;
		}
	}
}
