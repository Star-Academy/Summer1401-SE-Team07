using System;
using SimpleCalculator.Business;
using SimpleCalculator.Business.Enums;
using SimpleCalculator.Business.Abstraction;
using SimpleCalculator.Business.OperatorBusiness;
using SimpleCalculator.Business.OperatorBusiness.Operators;


public class OperatorExceptionTester
{
    private const int MaxInt = Int32.MaxValue;
    private const int MinInt = Int32.MinValue;
    private readonly SumOperator sumOperator = new SumOperator();
    private readonly SubOperator subOperator = new SubOperator();
    private readonly MultiplyOperator multOperator = new MultiplyOperator();
    private readonly DivisionOperator divOperator = new DivisionOperator();


    [Theory]
    [InlineData(MaxInt, 1)]
    [InlineData(MinInt, -1)]
    public void SumOverflowTest(int firstNumber, int secondNumber)
    {
        Action act = () => this.sumOperator.Calculate(firstNumber, secondNumber);
        Assert.Throws<Exception>(act);
    }

    [Theory]
    [InlineData(MaxInt, -1)]
    [InlineData(MinInt, 1)]
    public void SubOverflowTest(int firstNumber, int secondNumber)
    {
        Action act = () => this.subOperator.Calculate(firstNumber, secondNumber);
        Assert.Throws<Exception>(act);
    }

    [Theory]
    [InlineData(MaxInt, 2)]
    [InlineData(MinInt, 2)]
    public void MultOverflowTest(int firstNumber, int secondNumber)
    {
        Action act = () => this.multOperator.Calculate(firstNumber, secondNumber);
        Assert.Throws<Exception>(act);
    }

    [Theory]
    [InlineData(MaxInt, 0.5)]
    [InlineData(MinInt, 0.5)]
    public void DivOverflowTest(int firstNumber, int secondNumber)
    {
        Action act = () => this.divOperator.Calculate(firstNumber, secondNumber);
        Assert.Throws<Exception>(act);
    }

    [Theory]
    [InlineData(7, 0)]
    [InlineData(13, 0)]
    public void DivByZeroTest(int firstNumber, int secondNumber)
    {
        Action act = () => this.divOperator.Calculate(firstNumber, secondNumber);
        Assert.Throws<DivideByZeroException>(act);
    }
}