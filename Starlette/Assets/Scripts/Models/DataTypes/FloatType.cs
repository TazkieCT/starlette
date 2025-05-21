using UnityEngine;


public class FloatType : DataType
{

    public override object GetRandomValue()
    {
        return Random.Range(float.MinValue, float.MaxValue);
    }

    public float ParseValue(object value)
    {
        return (float)value;
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