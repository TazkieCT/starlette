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
        object left = leftOperandBlock.Evaluate();
        object right = rightOperandBlock.Evaluate();

        // Kondisinya itu kiri antar
        if (left is float || right is float)
        {
            // hasilnya pasti float.
            float leftFloat = FloatType.ParseValue(left);
            float rightFloat = FloatType.ParseValue(right);
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
            int leftInt = Integer.ParseValue(left);
            int rightInt = Integer.ParseValue(right);
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

    public override int Precedence => BlockType switch
    {
        ArithmeticType.Add => 2,
        ArithmeticType.Substract => 2,
        ArithmeticType.Multiply => 3,
        ArithmeticType.Divide => 3,
        ArithmeticType.Modulo => 3,
        _ => 0,
    };

    /// <summary>
    ///  Initializes the arithmetic operator with a specific value.
    /// Receives ArithmeticType value.
    /// </summary>
    /// <param name="value"></param>
    /// <exception cref="ArgumentException"></exception>
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
