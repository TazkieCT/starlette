using System;
using TMPro;
using UnityEngine;


public enum ArithmeticType { Add, Substract, Multiply, Divide, Modulo, Random }


public class ArithmeticOperatorBlock : OperatorBlock
{

    public ArithmeticType BlockType;
    protected override void AdditionalAwake()
    {
        if (BlockType == ArithmeticType.Random)
        {
            BlockType = (ArithmeticType)UnityEngine.Random.Range(0, 5);
            // Debug.Log($"Random Arithmetic Operator: {BlockType}, {ToString()}");
            gameObject.GetComponentInChildren<TextMeshProUGUI>().text = ToString();
        }   
    }
    public override object Evaluate(CompilerContext context = null)
    {
        // Anggap left sama right itu udah pasti antara Literal Atau Variable
        // Kalau variable ntar Evaluatenya otomatis ke Evaluatenya literal block
        object left = leftOperandBlock.Evaluate();
        object right = rightOperandBlock.Evaluate();

        // Kondisinya itu kiri antar
        Debug.Log($"Evaluating Arithmetic: {left} {BlockType} {right}");
        try
        {
                    if (left is float t || right is float r||
        (FloatType.ParseValue(left) % FloatType.ParseValue(right) != 0.0f && BlockType == ArithmeticType.Divide) || 
        ((int)left % (int)right != 0 && BlockType == ArithmeticType.Divide))
        {
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
            // hasilnya pasti integer. (kecuali bagi)
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
        catch (Exception)
        {
            return PayloadResultModel.ResultError("Wrong Block Inserted...");
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
        else if (value is ArithmeticOperatorBlock arithmeticOperatorBlock)
        {
            BlockType = arithmeticOperatorBlock.BlockType;
        }
        else
        {
            throw new ArgumentException("Invalid value type for ArithmeticOperatorBlock");
        }
    }
}
