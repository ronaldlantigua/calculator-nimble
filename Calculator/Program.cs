using System.Linq;

namespace CalculatorApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Calculator App!");
			var entry = Console.ReadLine();
			var numbers = InputParser.GetNumbersFromInput(entry!);

			ICalculator calculator= new Calculator();
			var result = calculator.Sum(numbers);
			Console.WriteLine(result);
		}
	}
}