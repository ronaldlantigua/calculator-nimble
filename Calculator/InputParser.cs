using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CalculatorApp
{
	public static class InputParser
	{
		public static IEnumerable<double> GetNumbersFromInput(string input)
		{
			var baseDelimeter = ",";
			var extraDelimeter = "\n";
			var customDelimeters = GetCustomDelimeters(input);

			input = input.Replace(extraDelimeter, baseDelimeter);

			foreach (var customDelimeter in customDelimeters) 
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


			if (numbers.Count() <= 0) return [0,0];
			if (numbers.Count() == 1) return [numbers.First(), 0];

			
			return numbers;
		}

		private static List<string> GetCustomDelimeters(string input)
		{
			var customSingleDelimeterPattern = "//.\n";
			var customDelimeterPattern = "//(\\[.+\\])+\n";

			var singleMatch = Regex.Match(input, customSingleDelimeterPattern);
			var match = Regex.Match(input, customDelimeterPattern);

			if (singleMatch.Success && singleMatch.Index == 0) 
			{
				var delimeter = singleMatch.Groups[0].Value.Replace("//", "").Replace("\n", "");
				return [delimeter];
			}

			var result = new List<string>();

			if (match.Success && match.Index == 0) 
			{
				var delimeters = match.Groups[0].Value.Replace("//", "").Replace("\n", "");
				var temp = new StringBuilder();

				foreach(var character in delimeters)
				{
					if (character == '[') continue;

					if(character == ']')
					{
						result.Add(temp.ToString());
						temp.Clear();
						continue;
					}

					temp.Append(character.ToString());
				}

			}
			
			return result;
		}
	}
}
