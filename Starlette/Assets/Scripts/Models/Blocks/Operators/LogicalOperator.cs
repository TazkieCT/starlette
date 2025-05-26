
using System;

public enum LogicalOperatorType
{
    AND,
    OR
}
public class LogicalOperator : OperatorBlock
{
    public LogicalOperatorType Operator;

    public LogicalOperator(CodeBlock left, CodeBlock right, LogicalOperatorType op)
    {
        leftOperandBlock = left;
        rightOperandBlock = right;
        Operator = op;
    }

    public override object Evaluate(CompilerContext context)
    {
        bool leftValue = (bool)leftOperandBlock.Evaluate(context);
        bool rightValue = (bool)rightOperandBlock.Evaluate(context);

        return Operator switch
        {
            LogicalOperatorType.AND => leftValue && rightValue,
            LogicalOperatorType.OR => leftValue || rightValue,
            _ => throw new System.Exception("Invalid logical operator")
        };
    }

    public override string ToString()
    {
        return Operator switch
        {
            LogicalOperatorType.AND => "&&",
            LogicalOperatorType.OR => "||",
            _ => throw new System.Exception("Invalid logical operator")
        };
    }

    /// <summary>
    /// Initializes the logical operator with a specific value.
    /// recieves LogicalOperatorType Value
    /// </summary>
    /// <param name="value"></param>
    /// <exception cref="ArgumentException"></exception>
    public override void Init(object value)
    {
        if (value is LogicalOperatorType logicalOperatorType)
        {
            Operator = logicalOperatorType;
        }
        else
        {
            throw new ArgumentException("Invalid value type for LogicalOperator");
        }
    }
    public override int Precedence => 1;
}