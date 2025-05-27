using System;
using UnityEditor.VersionControl;
using UnityEngine;

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
            object value = rightOperandBlock.Evaluate(context);
            Debug.Log($"Evaluating assignment: {variableName} = {value}");
            PayloadResultModel result = MatchDataType(variableBlock, value);
            if (!result.Success)
            {
                Debug.LogError(result.Message);
                throw new Exception(result.Message);
            }
            variableBlock.GetValue().Init(result.Payload);

            // Assign the value to the variable in the context
            PayloadResultModel declareResult = context.DeclareVariable(variableName);
            if (!declareResult.Success)
            {
                throw new Exception($"{declareResult.Message}");
            }
            declareResult = context.AssignVariable(variableName, variableBlock);
            if (!declareResult.Success)
            {
                throw new Exception($"{declareResult.Message}");
            }

            
            return variableBlock;
        }
        else
        {
            throw new Exception("Left operand must be a VariableBlock");
        }
    }

    private PayloadResultModel MatchDataType(VariableBlock variableBlock, object result)
    {
        DataType variableType = variableBlock.GetDataType();
        // Debug.Log($"Type of variable: {(variableType is Integer ? "Integer ni" : "Kontol")}, Result type: {(result is int ? "int" : "maklo")}");
        if (variableType is Integer && result is int)
        {
            variableType.Value = Integer.ParseValue(result);
        }
        else if (variableType is FloatType && result is float)
        {
            variableType.Value = FloatType.ParseValue(result);
        }
        else if (variableType is Boolean && result is bool)
        {
            variableType.Value = Boolean.ParseValue(result);
        }
        else if (result is null)
        {
            Debug.LogError("Assignment result is null.");
            return new PayloadResultModel("Assignment result is null.", false);
        }
        else
        {
            Debug.LogError("Execution Failed.");
            return new PayloadResultModel("Execution Failed.", false);
        }

        return new PayloadResultModel("Execution Successful.", true, variableType);
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
        else if (value is AssignmentOperatorBlock assignmentOperatorBlock)
        {
            BlockType = assignmentOperatorBlock.BlockType;
        }
        else
        {
            throw new ArgumentException("Invalid value type for AssignmentOperatorBlock");
        }
    }
    public override int Precedence => BlockType switch
    {
        AssignmentType.Assign => 0,
        AssignmentType.AddAsign => 0,
        _ => throw new NotImplementedException(),
    };
}   