using System;
using NUnit.Framework.Constraints;
using UnityEngine;


public enum ArithmeticType { Add, Substract, Multiply, Divide, Modulo }

public class ArithmeticOperatorBlock : OperatorBlock
{

    public ArithmeticType BlockType { get; set; }

    public override object Evaluate(CompilerContext context)
    {
        var left = Convert.ToDouble(leftOperandBlock.Evaluate(context));
        var right = Convert.ToDouble(rightOperandBlock.Evaluate(context));

        return BlockType switch
        {
            ArithmeticType.Add => left + right,
            ArithmeticType.Substract => left - right,
            ArithmeticType.Multiply => left * right,
            ArithmeticType.Divide => right == 0 ? throw new Exception("Divide By Zero") : left / right,
            ArithmeticType.Modulo => left % right,
            _ => throw new NotImplementedException()
        };
    }

    public override string ToString()
    {
        return BlockType switch
        {
            ArithmeticType.Add => "+",
            ArithmeticType.Substract => "-",
            ArithmeticType.Multiply => "*",
            ArithmeticType.Divide => "/",
            ArithmeticType.Modulo => "%",
            _ => throw new NotImplementedException(),
        };
    }

    public override void Init(object value)
    {
        if (value is ArithmeticType arithmeticType)
        {
            BlockType = arithmeticType;
        }
        else
        {
            throw new ArgumentException("Invalid value type for ArithmeticOperatorBlock");
        }
    }
}
