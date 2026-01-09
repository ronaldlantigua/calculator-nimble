
namespace CalculatorApp
{
	public interface ICalculator
	{
		double Sum(IEnumerable<double> numbers);
	}

	public class Calculator : ICalculator
	{
		public double Sum(IEnumerable<double> numbers)
		{
			return numbers.Sum();
		}
	}
}
