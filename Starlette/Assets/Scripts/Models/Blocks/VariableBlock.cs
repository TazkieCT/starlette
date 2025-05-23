

public class VariableBlock: CodeBlock, IDataType
{
    public string VariableName { get; set; }
    public LiteralBlock Value;
    public VariableBlock(LiteralBlock value)
    {
        Value = value;
    }

    public LiteralBlock GetValue()
    {
        return Value;
    }

    public void SetValue(LiteralBlock value)
    {
        Value = value;
    }
    

    public override object Evaluate(CompilerContext context) => context.GetVariable(VariableName);

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
        else
        {
            throw new System.Exception("Invalid value type for VariableBlock");
        }
    }

    public DataType GetDataType()
    {
        return Value.GetDataType();
    }
}