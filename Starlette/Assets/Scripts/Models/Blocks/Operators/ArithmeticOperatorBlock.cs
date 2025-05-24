using System;
using Mono.Cecil.Cil;
using NUnit.Framework.Constraints;
using UnityEngine;


public enum ArithmeticType { Add, Substract, Multiply, Divide, Modulo }

public class ArithmeticOperatorBlock : OperatorBlock
{

    public ArithmeticType BlockType { get; set; }

    public override object Evaluate(CompilerContext context = null)
    {
        // Anggap left sama right itu udah pasti antara Literal Atau Variable
        // Kalau variable ntar Evaluatenya otomatis ke Evaluatenya literal block
        DataType left = (DataType)leftOperandBlock.Evaluate();
        DataType right = (DataType)rightOperandBlock.Evaluate();

        // Kondisinya itu kiri antar
        if (left is FloatType || right is FloatType)
        {
            // hasilnya pasti float.
            float leftFloat = FloatType.ParseValue(left.GetValue());
            float rightFloat = FloatType.ParseValue(right.GetValue());
            return BlockType switch
            {
                ArithmeticType.Add => leftFloat + rightFloat,
                ArithmeticType.Substract => leftFloat - rightFloat,
                ArithmeticType.Multiply => leftFloat * rightFloat,
                ArithmeticType.Divide => rightFloat == 0 ? throw new Exception("Divide By Zero") : leftFloat / rightFloat,
                ArithmeticType.Modulo => leftFloat % rightFloat,
                _ => throw new NotImplementedException()
            };
        }
        else
        {
            // hasilnya pasti integer.
            int leftInt = Integer.ParseValue(left.GetValue());
            int rightInt = Integer.ParseValue(right.GetValue());
            return BlockType switch
            {
                ArithmeticType.Add => leftInt + rightInt,
                ArithmeticType.Substract => leftInt - rightInt,
                ArithmeticType.Multiply => leftInt * rightInt,
                ArithmeticType.Divide => rightInt == 0 ? throw new Exception("Divide By Zero") : leftInt / rightInt,
                ArithmeticType.Modulo => leftInt % rightInt,
                _ => throw new NotImplementedException()
            };
        }
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

    public static int GetPrecedence(ArithmeticType arithmeticType)
    {
        return arithmeticType switch
        {
            ArithmeticType.Add => 1,
            ArithmeticType.Substract => 1,
            ArithmeticType.Multiply => 2,
            ArithmeticType.Divide => 2,
            ArithmeticType.Modulo => 2,
            _ => 0,
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
