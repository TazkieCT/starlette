using System;
using TMPro;
using UnityEngine;

public enum ComparisonType
{
    Equal, Less, Greater, LessEqual, GreaterEqual, NotEqual, Random
}

public class ComparisonOperatorBlock : OperatorBlock
{
    public ComparisonType ComparisonType;

    protected override void AdditionalAwake()
    {
        if (ComparisonType == ComparisonType.Random)
        {
            ComparisonType = (ComparisonType)UnityEngine.Random.Range(0, 6);
        }
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = ToString();
    }

    public override object Evaluate(CompilerContext context)
    {
        float leftValue = FloatType.ParseValue(leftOperandBlock.Evaluate(context));
        float rightValue = FloatType.ParseValue(rightOperandBlock.Evaluate(context));
        //Debug.Log($"Evaluating Comparison: {leftValue} {ComparisonType} {rightValue}");
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
            ComparisonType.NotEqual => "!=",
            _ => "?"
        };
    }
    public override void Init(object value)
    {
        if (value is ComparisonType comparisonType)
        {
            ComparisonType = comparisonType;
        }
        else if (value is ComparisonOperatorBlock comparisonOperatorBlock)
        {
            ComparisonType = comparisonOperatorBlock.ComparisonType;
        }
        else if (value is string strValue)
        {
            switch (strValue)
            {
                case "==":
                    ComparisonType = ComparisonType.Equal;
                    break;
                case "<":
                    ComparisonType = ComparisonType.Less;
                    break;
                case ">":
                    ComparisonType = ComparisonType.Greater;
                    break;
                case "<=":
                    ComparisonType = ComparisonType.LessEqual;
                    break;
                case ">=":
                    ComparisonType = ComparisonType.GreaterEqual;
                    break;
                case "!=":
                    ComparisonType = ComparisonType.NotEqual;
                    break;
                default:
                    throw new ArgumentException("Invalid string value for ComparisonOperator");
            }
        }
        else
        {
            throw new ArgumentException("Invalid value type for ComparisonOperatorBlock");
        }
    }

    public override int Precedence => 1;
}