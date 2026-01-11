using System.Linq;

namespace CalculatorApp
{
	public static class InputParser
	{
		public static IEnumerable<double> GetNumbersFromInput(string input)
		{
			var baseDelimeter = ",";
			var extraDelimeter = "\n";

			input = input.Replace(extraDelimeter, baseDelimeter.ToString());

			var numbers = input.Split(baseDelimeter).Select(term => {
				double number = 0;
				try
				{
					double.TryParse(term, out number);
				}
				catch (Exception)
				{
					return 0;
				}

				return number;
			});


			if (numbers.Count() <= 1) throw new Exception("Invalid Input");
			return numbers;
		}
	}
}
