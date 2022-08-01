namespace SimpleCalculator.Tests;

using SimpleCalculator.Business.OperatorBusiness.Operators;

public class MultiplyOperatorTests
{
    [Theory]
    [InlineData(1, 2, 2)]
    [InlineData(-999, 0, 0)]
    public void Multiply_TwoNumbers_ReturnsProduct(int firstNumber, int secondNumber, int expected)
    {
        // Arrange
        var multOperator = new MultiplyOperator();
        // Act
        var result = multOperator.Calculate(firstNumber, secondNumber);
        // Assert
        Assert.Equal(expected, result);
    }
}
