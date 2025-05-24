using UnityEngine;


public class LiteralBlock : CodeBlock
{
    private DataType Value;
    public void SetValue(DataType value)
    {
        Value = value;
    }

    public DataType GetValue()
    {
        return Value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    public override void Init(object value)
    {
        if (value is DataType dataType)
        {
            Value = dataType;
        }
        else
        {
            throw new System.Exception("Invalid value type for LiteralBlock");
        }
    }

    public override object Evaluate(CompilerContext context = null) => Value;
}