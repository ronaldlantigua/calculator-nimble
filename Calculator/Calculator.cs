
namespace CalculatorApp
{
	public interface ICalculator
	{
		double Sum(double num1, double num2);
	}

	public class Calculator : ICalculator
	{
		public double Sum(double num1, double num2)
		{
			return num1 + num2;
		}
	}
}
