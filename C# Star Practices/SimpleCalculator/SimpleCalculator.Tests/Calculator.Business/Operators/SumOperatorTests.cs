namespace SimpleCalculator.Tests.Operators;

using SimpleCalculator.Business.OperatorBusiness.Operators;

public class SumOperatorTests
{

    [Theory]
    [InlineData(3, -2, 1)]
    public void Add_TwoNumbers_ReturnsSum(int firstNumber, int secondNumber, int expected)
    {
        // Arrange
        var sumOperator = new SumOperator();
        // Act
        var result = sumOperator.Calculate(firstNumber, secondNumber);
        // Assert
        Assert.Equal(expected, result);
    }
}
