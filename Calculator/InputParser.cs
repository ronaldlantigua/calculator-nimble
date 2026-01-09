namespace CalculatorApp
{
	public static class InputParser
	{
		public static IEnumerable<double> GetNumbersFromInput(string input)
		{
			var baseDelimeter = ",";
			var extraDelimeter = "\n";

			input = input.Replace(extraDelimeter, baseDelimeter.ToString());

			var numbers = input.Split(baseDelimeter).Select(x => {
				double result = 0;
				try
				{
					double.TryParse(x, out result);
				}
				catch (Exception)
				{
					return 0;
				}
				return result;
			});

			if (numbers.Count() <= 1) throw new Exception("Invalid Input");
			return numbers;
		}
	}
}
