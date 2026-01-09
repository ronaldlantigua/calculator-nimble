using Xunit;
using CalculatorApp;

namespace CalculatorTests
{
	public class CalcultorTests
	{
		private ICalculator sut = new Calculator();
		
		[Fact]
		public void Sum_TwoPositiveNumbers_ReturnValidResult()
		{
			//Arrange
			var numbers = new List<double> {10, 8};
			var expectedResult = 18;

			//Action

			var result = sut.Sum(numbers);

			//Asertions
			Assert.Equal(expectedResult, result);
		}
		
		[Fact]
		public void Sum_OnePositiveNumberAndOneNegativeNumber_ReturnValidResult()
		{
			//Arrange
			var numbers = new List<double> { -8, 10 };

			var expectedResult = 2;

			//Action

			var result = sut.Sum(numbers);

			//Asertions
			Assert.Equal(expectedResult, result);
		}
		
		[Fact]
		public void Sum_TwoNegativeNumbers_ReturnValidResult()
		{
			//Arrange
			var numbers = new List<double> { -8, -10 };

			var expectedResult = -18;

			//Action

			var result = sut.Sum(numbers);

			//Asertions
			Assert.Equal(expectedResult, result);
		}
	}
}