using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Integer : DataType
{
    
    public override object GetRandomValue()
    {
        return Random.Range(int.MinValue, int.MaxValue);
    }

    public static int ParseValue(object value)
    {
        return (int)value;
    }

    public override bool IsValidValue(object value)
    {
        return value is int;
    }

    public override string ToString()
    {
        return ((int)Value).ToString();
    }
}