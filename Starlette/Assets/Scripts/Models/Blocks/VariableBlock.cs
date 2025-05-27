

using UnityEngine.UIElements;

public class VariableBlock : CodeBlock
{
    public string VariableName { get; set; }
    public LiteralBlock Value;

    public LiteralBlock GetValue()
    {
        return Value;
    }

    public void SetValue(LiteralBlock value)
    {
        Value = value;
    }
    
    public DataType GetDataType()
    {
        return Value.GetValue();
    }


    public override object Evaluate(CompilerContext context = null) => Value.Evaluate();

    public override string ToString()
    {
        return Value.ToString();
    }
    public override void Init(object value)
    {

        if (value is DataType dataType)
        {
            Value.Init(dataType);
        }
        else if (value is string variableName)
        {
            VariableName = variableName;
        }
        else if (value is LiteralBlock literalBlock)
        {
            Value = literalBlock;
            VariableName = literalBlock.ToString();
        }
        else if(value is VariableBlock variableBlock)
        {
            VariableName = variableBlock.VariableName;
            Value = variableBlock.Value;
        }
        else
        {
            throw new System.Exception("Invalid value type for VariableBlock");
        }
    }
}