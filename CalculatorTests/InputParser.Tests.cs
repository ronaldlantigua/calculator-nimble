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
		[InlineData(",",0, 0)]
		[InlineData("5,",5, 0)]
		[InlineData(",5",0, 5)]
		[InlineData("5,8", 5, 8)]
		[InlineData("5,nget", 5, 0)]
		[InlineData("20\n12", 20, 12)]

		public void GetNumbersFromInput_GivenCorrectInput_ReturnValidNumbers(string input, double expectedNumber1, double expectedNumber2)
		{
			//Arrange
			//Act
			var result = InputParser.GetNumbersFromInput(input);

			//Assertion
			Assert.Equal(expectedNumber1, result.First());
			Assert.Equal(expectedNumber2, result.Last());
		}

		[Fact]
		public void GetNumbersFromInput_GiveALongListOfNumbers_ReturnValidNumbers()
		{
			//Arrange
			var input = "4,5,74,8,74,tt,1,4,7,8,9";
			var expecteNumbers = new List<double>()
			{
				4,5,74,8,74,0,1,4,7,8,9
			};
			//Act
			var result = InputParser.GetNumbersFromInput(input);

			//Assertion
			Assert.True(expecteNumbers.All(result.Contains));
		}
	}
}
