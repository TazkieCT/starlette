using System;
using UnityEngine;

public enum ComparisonType
{
    Equal, Less, Greater, LessEqual, GreaterEqual, NotEqual
}

public class ComparisonOperatorBlock : OperatorBlock
{
    public ComparisonType ComparisonType;


    public override object Evaluate(CompilerContext context)
    {
        var leftValue = leftOperandBlock.Evaluate(context);
        var rightValue = rightOperandBlock.Evaluate(context);

        return ComparisonType switch
        {
            ComparisonType.Equal => leftValue.Equals(rightValue),
            ComparisonType.Less => (float)leftValue < (float)rightValue,
            ComparisonType.Greater => (float)leftValue > (float)rightValue,
            ComparisonType.LessEqual => (float)leftValue <= (float)rightValue,
            ComparisonType.GreaterEqual => (float)leftValue >= (float)rightValue,
            ComparisonType.NotEqual => (object)!leftValue.Equals(rightValue),
            _ => throw new System.NotImplementedException(),
        };
    }
    public override string ToString()
    {
        return ComparisonType switch
        {
            ComparisonType.Equal => "==",
            ComparisonType.Less => "<",
            ComparisonType.Greater => ">",
            ComparisonType.LessEqual => "<=",
            ComparisonType.GreaterEqual => ">=",
            _ => "?"
        };
    }
    public override void Init(object value)
    {
        if (value is ComparisonType comparisonType)
        {
            ComparisonType = comparisonType;
        }
        else
        {
            throw new ArgumentException("Invalid value type for ComparisonOperatorBlock");
        }
    }
}