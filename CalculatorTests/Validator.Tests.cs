using CalculatorApp;
using Xunit;

namespace CalculatorTests
{
	public class ValidatorTests
	{
		[Fact]
		public void IsValid_GivenNegativeNumbers_ThrowException()
		{
			//Arrange
			var numbers = new List<double> { 1, -2, -500, 8};
			IValidator sut = new Validator();
			var expectedMessage = "-2,-500";

			//Action
			//Assertion
			var caughtException = Assert.Throws<Exception>(() => sut.IsValid(numbers));
			Assert.Equal(expectedMessage, caughtException.Message);
		}
	}
}
