namespace CalculatorApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Calculator App!");
			var entry = Console.ReadLine();
			var numbers = InputParser.GetNumbersFromInput(entry!);
			if (numbers.Count() > 2) throw new Exception("Maximum of two numbers is supported");

			ICalculator calculator= new Calculator();
			var result = calculator.Sum(numbers.First(), numbers.Last());
			Console.WriteLine(result);
		}
	}
}