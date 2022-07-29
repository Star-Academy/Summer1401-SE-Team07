namespace SimpleCalculator.Tests;

using SimpleCalculator.Business;
using SimpleCalculator.Business.OperatorBusiness;
using SimpleCalculator.Business.OperatorBusiness.Operators;

// test base operators

public class OperatorSumTest
{
    private readonly SumOperator _sumOperator = new SumOperator();

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(2, 2, 4)]
    [InlineData(3, -2, 1)]
    public void Add_TwoNumbers_ReturnsSum(int firstNumber, int secondNumber, int expected)
    {
        var result = this._sumOperator.Calculate(firstNumber, secondNumber);
        Assert.Equal(expected, result);
    }
}

public class OperatorSubTest
{
    private readonly SubOperator _subOperator = new SubOperator();

    [Theory]
    [InlineData(1, 2, -1)]
    [InlineData(2, 2, 0)]
    [InlineData(3, 2, 1)]
    public void Subtract_TwoNumbers_ReturnsDifference(int firstNumber, int secondNumber, int expected)
    {
        var result = this._subOperator.Calculate(firstNumber, secondNumber);
        Assert.Equal(expected, result);
    }
}

public class OperatorMultiplyTest
{
    private readonly MultiplyOperator _multOperator = new MultiplyOperator();
    
    [Theory]
    [InlineData(1, 2, 2)]
    [InlineData(2, 2, 4)]
    [InlineData(-999, 0, 0)]
    [InlineData(3, 2, 6)]
    public void Multiply_TwoNumbers_ReturnsProduct(int firstNumber, int secondNumber, int expected)
    {
        var result = this._multOperator.Calculate(firstNumber, secondNumber);
        Assert.Equal(expected, result);
    }
}

public class OperatorDivisonTest
{
    private readonly DivisionOperator _divOperator = new DivisionOperator();
    
    [Theory]
    [InlineData(1, 2, 0.5)]
    [InlineData(2, 2, 1)]
    [InlineData(3, 2, 1.5)]
    public void Divide_TwoNumbers_ReturnsQuotient(int firstNumber, int secondNumber, double expected)
    {
        var result = this._divOperator.Calculate(firstNumber, secondNumber);
        Assert.Equal(expected, result);
    }
}