using System;
using UnityEngine;


public class FloatType : DataType
{

    public static FloatType GetRandomValue()
    {
        FloatType randomFloat = new()
        {
            Value = UnityEngine.Random.Range(0f, 20f) // Random float between -20 and 20
        };
        return randomFloat;
    }
    
    public static float ParseValue(object value)
    {
        return Convert.ToSingle(value);
    }

    public override bool IsValidValue(object value)
    {
        return value is float;
    }

    public override string ToString()
    {
        return ((float)Value).ToString();
    }
}