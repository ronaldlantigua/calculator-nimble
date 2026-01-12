using System.Linq;
using System.Text.RegularExpressions;

namespace CalculatorApp
{
	public static class InputParser
	{
		public static IEnumerable<double> GetNumbersFromInput(string input)
		{
			var baseDelimeter = ",";
			var extraDelimeter = "\n";
			var customDelimeter = GetCustomDelimeter(input);

			input = input.Replace(extraDelimeter, baseDelimeter);

			if(!string.IsNullOrEmpty(customDelimeter))
			{
				input = input.Replace(customDelimeter, baseDelimeter);
			}

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

				if (number > 1000) return 0;

				return number;
			});


			if (numbers.Count() <= 1) throw new Exception("Invalid Input");

			
			return numbers;
		}

		private static string GetCustomDelimeter(string input)
		{
			var customSingleDelimeterPattern = "//.\n";
			var customDelimeterPattern = "//\\[.+\\]\n";
			var singleMatch = Regex.Match(input, customSingleDelimeterPattern);
			var match = Regex.Match(input, customDelimeterPattern);
			if (singleMatch.Success && singleMatch.Index == 0) 
			{
				return singleMatch.Groups[0].Value.Replace("//", "").Replace("\n", "");
			}
			
			if (match.Success && match.Index == 0) 
			{
				return match.Groups[0].Value.Replace("//[", "").Replace("]\n", "");
			}
			return string.Empty;
		}
	}
}
