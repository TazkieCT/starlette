using System;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public enum AssignmentType {Assign, AddAsign}
public class AssignmentOperatorBlock : OperatorBlock
{
    public AssignmentType BlockType;
    public void SetOperands(CodeBlock leftOperand, CodeBlock rightOperand)
    {
        leftOperandBlock = leftOperand;
        rightOperandBlock = rightOperand;
    }

    public override object Evaluate(CompilerContext context)
    {
        //left operator will always be a VariableBlock
        if (leftOperandBlock is VariableBlock variableBlock)
        {
            var variableName = variableBlock.VariableName;

            // right operand will always be a CodeBlock
            LiteralBlock value = (LiteralBlock)rightOperandBlock.Evaluate(context);
            variableBlock.SetValue(value);

            // Assign the value to the variable in the context
            context.AssignVariable(variableName, variableBlock);

            return value;
        }
        else
        {
            throw new System.Exception("Left operand must be a VariableBlock");
        }
    }

    public override string ToString()
    {
        return "=";
    }
    public override void Init(object value)
    {
        if (value is AssignmentType assignmentType)
        {
            BlockType = assignmentType;
        }
        else
        {
            throw new ArgumentException("Invalid value type for AssignmentOperatorBlock");
        }
    }
}   