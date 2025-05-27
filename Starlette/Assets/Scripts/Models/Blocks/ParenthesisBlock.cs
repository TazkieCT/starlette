public enum ParenthesisType { Open, Close }
public class ParenthesisBlock : CodeBlock
{
    public ParenthesisType Type { get; private set; }
    public int Precedence => 4;
    public override object Evaluate(CompilerContext context = null)
    {
        // Parentheses do not change the value, they just group expressions
        return Type == ParenthesisType.Open ? "(" : ")";
    }

    public override string ToString()
    {
        return Type == ParenthesisType.Open ? "(" : ")";
    }

    public override void Init(object value)
    {
        if (value is string strValue)
        {
            if (strValue == "(")
            {
                Type = ParenthesisType.Open;
            }
            else if (strValue == ")")
            {
                Type = ParenthesisType.Close;
            }
        }
        else if (value is ParenthesisType parenthesisType)
        {
            Type = parenthesisType;
        }
        else if (value is ParenthesisBlock parenthesisBlock)
        {
            Type = parenthesisBlock.Type;
        }
        else
        {
            throw new System.ArgumentException("Invalid value for ParenthesisBlock initialization");
        }
    }
}