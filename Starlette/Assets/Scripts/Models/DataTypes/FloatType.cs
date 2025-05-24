using System;
using UnityEngine;


public class FloatType : DataType
{

    public override object GetRandomValue()
    {
        return UnityEngine.Random.Range(float.MinValue, float.MaxValue);
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