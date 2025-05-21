
using UnityEngine;

public class Boolean : DataType
{


    public override object GetRandomValue()
    {
        return Random.Range(0, 2) == 0;
    }

    public bool ParseValue(object value)
    {
        return (bool)value;
    }

    public override bool IsValidValue(object value)
    {
        return value is bool;
    }

    public override string ToString()
    {
        return ((bool)Value).ToString();
    }
}
