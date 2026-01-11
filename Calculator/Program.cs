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
			IValidator validator = new Validator();
			if (!validator.IsValid(numbers)) { return; }

			ICalculator calculator= new Calculator();
			var result = calculator.Sum(numbers);
			Console.WriteLine(result);
		}
	}
}