namespace SimpleCalculator.Tests.Operators;

using SimpleCalculator.Business.OperatorBusiness.Operators;

public class DivisionOperatorTests
{
   
    [Theory]
    [InlineData(1, 2, 0.5)]
    [InlineData(2, 2, 1)]
    public void Divide_TwoNumbers_ReturnsQuotient(int firstNumber, int secondNumber, double expected)
    {
        // Arrange
        var divOperator = new DivisionOperator();
        // Act
        var result = divOperator.Calculate(firstNumber, secondNumber);
        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1, 0)]
    [InlineData(0, 0)]
    public void Divide_ByZero_ThrowsException(int firstNumber, int secondNumber)
    {
        // Arrange
        var divOperator = new DivisionOperator();
        // Act & Assert
        Assert.Throws<DivideByZeroException>(() => divOperator.Calculate(firstNumber, secondNumber));
    }
}
