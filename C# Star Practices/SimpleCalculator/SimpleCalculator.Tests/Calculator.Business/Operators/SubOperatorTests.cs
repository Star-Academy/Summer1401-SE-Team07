namespace SimpleCalculator.Tests;

using SimpleCalculator.Business.OperatorBusiness.Operators;

public class SubOperatorTests
{

    [Theory]
    [InlineData(1, 2, -1)]
    public void Subtract_TwoNumbers_ReturnsDifference(int firstNumber, int secondNumber, int expected)
    {
        // Arrange
        var subOperator = new SubOperator();
        // Act
        var result = subOperator.Calculate(firstNumber, secondNumber);
        // Assert
        Assert.Equal(expected, result);
    }
}
