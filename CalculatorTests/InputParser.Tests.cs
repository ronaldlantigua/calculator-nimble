using CalculatorApp;
using Xunit;

namespace CalculatorTests
{
	public class InputParserTests
	{
		[Theory]
		[InlineData("")]
		[InlineData("5")]
		public void GetNumbersFromInput_GivenLessThanTwoNumberAsInput_ReturnException(string input) 
		{
			//Arrange
			var expectedMessage = "Invalid Input";

			//Act
			//Assertion
			var exception = Assert.Throws<Exception>(() => InputParser.GetNumbersFromInput(input));
			Assert.Equal(expectedMessage, exception.Message);
		}

		[Theory]
		[InlineData("5,14,1")]
		[InlineData("5,5,8,9,74,83")]
		public void GetNumbersFromInput_GivenMoreThanTwoNumberAsInput_ReturnException(string input)
		{
			//Arrange
			var expectedMessage = "Invalid Input";

			//Act
			//Assertion
			var exception = Assert.Throws<Exception>(() => InputParser.GetNumbersFromInput(input));
			Assert.Equal(expectedMessage, exception.Message);
		}
		
		
		[Theory]
		[InlineData(",",0, 0)]
		[InlineData("5,",5, 0)]
		[InlineData(",5",0, 5)]
		[InlineData("5,8", 5, 8)]
		public void GetNumbersFromInput_GivenCorrectInput_ReturnValidNumbers(string input, double expectedNumber1, double expectedNumber2)
		{
			//Arrange
			//Act
			var result = InputParser.GetNumbersFromInput(input);

			//Assertion
			Assert.Equal(expectedNumber1, result.First());
			Assert.Equal(expectedNumber2, result.Last());
		}
	}
}
