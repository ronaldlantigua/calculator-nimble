namespace CalculatorApp
{
	public static class InputParser
	{
		public static IEnumerable<double> GetNumbersFromInput(string input)
		{
			var delimeter = ',';
			var numbers = input.Split(delimeter).Select(x => {
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

			if (numbers.Count() <= 1 || numbers.Count() > 2) throw new Exception("Invalid Input");
			return numbers;
		}
	}
}
