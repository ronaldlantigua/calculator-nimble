namespace CalculatorApp
{
	public interface IValidator
	{
		bool IsValid(IEnumerable<double> numbers);
	}

	public class Validator : IValidator
	{
		public bool IsValid(IEnumerable<double> numbers) 
		{
			if (numbers.Any(n => n < 0))
			{
				var message = string.Join(",", numbers.Where(n => n < 0));
				throw new Exception(message);
			}

			return true;
		}
	}
}
