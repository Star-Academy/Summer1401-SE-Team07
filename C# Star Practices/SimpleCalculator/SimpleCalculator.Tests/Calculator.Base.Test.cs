namespace SimpleCalculator.Tests;

using SimpleCalculator.Business;
using SimpleCalculator.Business.Enums;

// test Calculator object

public class CalculatorSumTest
{
    private readonly Calculator _calculator = new Calculator();

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(2, 2, 4)]
    [InlineData(3, -2, 1)]
    public void Add_TwoNumbers_ReturnsSum(int firstNumber, int secondNumber, int expected)
    {
        var result = _calculator.Calculate(firstNumber, secondNumber, OperatorEnum.sum);

        Assert.Equal(expected, result);
    }
}

public class CalculatorSubtractTest
{
    private readonly Calculator _calculator = new Calculator();

    [Theory]
    [InlineData(1, 2, -1)]
    [InlineData(2, 2, 0)]
    [InlineData(3, 2, 1)]
    public void Subtract_TwoNumbers_ReturnsDifference(int firstNumber, int secondNumber, int expected)
    {
        var result = _calculator.Calculate(firstNumber, secondNumber, OperatorEnum.sub);

        Assert.Equal(expected, result);
    }
}

public class CalculatorMultiplyTest
{
    private readonly Calculator _calculator = new Calculator();
    
    [Theory]
    [InlineData(1, 2, 2)]
    [InlineData(2, 2, 4)]
    [InlineData(-999, 0, 0)]
    [InlineData(3, 2, 6)]
    public void Multiply_TwoNumbers_ReturnsProduct(int firstNumber, int secondNumber, int expected)
    {
        var result = _calculator.Calculate(firstNumber, secondNumber, OperatorEnum.multiply);

        Assert.Equal(expected, result);
    }
}

public class CalculatorDivisonTest
{
    private readonly Calculator _calculator = new Calculator();
    
    [Theory]
    [InlineData(1, 2, 0.5)]
    [InlineData(2, 2, 1)]
    [InlineData(3, 2, 1.5)]
    public void Divide_TwoNumbers_ReturnsQuotient(int firstNumber, int secondNumber, double expected)
    {
        var result = _calculator.Calculate(firstNumber, secondNumber, OperatorEnum.division);

        Assert.Equal(expected, result);
    }
}