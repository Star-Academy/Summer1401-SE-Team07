namespace SimpleCalculator.Tests;

using Xunit;
using SimpleCalculator.Business;
using SimpleCalculator.Business.Enums;

public class CalculatorSumTest
{
    Calculator calculator = new Calculator();

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(2, 2, 4)]
    [InlineData(3, -2, 1)]
    public void Add_TwoNumbers_ReturnsSum(int a, int b, int expected)
    {
        var result = calculator.Calculate(a, b, OperatorEnum.sum);

        Assert.Equal(expected, result);
    }
}

public class CalculatorSubtractTest
{
    Calculator calculator = new Calculator();

    [Theory]
    [InlineData(1, 2, -1)]
    [InlineData(2, 2, 0)]
    [InlineData(3, 2, 1)]
    public void Subtract_TwoNumbers_ReturnsDifference(int a, int b, int expected)
    {
        var result = calculator.Calculate(a, b, OperatorEnum.sub);

        Assert.Equal(expected, result);
    }
}

public class CalculatorMultiplyTest
{
    Calculator calculator = new Calculator();
    
    [Theory]
    [InlineData(1, 2, 2)]
    [InlineData(2, 2, 4)]
    [InlineData(-999, 0, 0)]
    [InlineData(3, 2, 6)]
    public void Multiply_TwoNumbers_ReturnsProduct(int a, int b, int expected)
    {
        var result = calculator.Calculate(a, b, OperatorEnum.multiply);

        Assert.Equal(expected, result);
    }
}

public class CalculatorDivisonTest
{
    Calculator calculator = new Calculator();
    
    [Theory]
    [InlineData(1, 2, 0.5)]
    [InlineData(2, 2, 1)]
    [InlineData(3, 2, 1.5)]
    public void Divide_TwoNumbers_ReturnsQuotient(int a, int b, double expected)
    {
        var result = calculator.Calculate(a, b, OperatorEnum.division);

        Assert.Equal(expected, result);
    }
}