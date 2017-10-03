using System;
namespace HelloWorld
{
	public interface ICalculationService
	{
		double TipAmount(double subTotal, int generosity);
	}
}
