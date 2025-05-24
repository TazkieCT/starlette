using System.Collections.Generic;

public static class ExpressionTreeBuilder
{
    public static CodeBlock BuildExpressionTree(List<CodeBlock> blocks)
    {
        Stack<ArithmeticOperatorBlock> operatorStack = new();
        Stack<CodeBlock> operandStack = new();

        foreach (var token in blocks)
        {
            if (token is LiteralBlock or VariableBlock)
            {
                operandStack.Push(token);
            }
            else if (token is ArithmeticOperatorBlock op)
            {
                while (operatorStack.Count > 0 &&
                       ArithmeticOperatorBlock.GetPrecedence(op.BlockType) <= ArithmeticOperatorBlock.GetPrecedence(operatorStack.Peek().BlockType))
                {
                    ArithmeticOperatorBlock topOp = operatorStack.Pop();

                    CodeBlock right = operandStack.Pop();
                    CodeBlock left = operandStack.Pop();

                    topOp.setLeftChild(left);
                    topOp.setRightChild(right);
                    operandStack.Push(topOp);
                }

                operatorStack.Push(op);
            }
        }

        // Final pass
        while (operatorStack.Count > 0)
        {
            ArithmeticOperatorBlock op = operatorStack.Pop();

            CodeBlock right = operandStack.Pop();
            CodeBlock left = operandStack.Pop();

            op.setLeftChild(left);
            op.setRightChild(right);
            operandStack.Push(op);
        }

        return operandStack.Pop(); // final expression tree root
    }
}