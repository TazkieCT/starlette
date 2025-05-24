using UnityEngine;

public class FirstPart : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    BlockFactory factory;
    void Start()
    {
        factory = GameObject.FindFirstObjectByType<BlockFactory>();
        if (factory == null)
        {
            Debug.LogError("BlockFactory not found in the scene.");
            return;
        }
        BlockHolder holder = GetComponentInChildren<BlockHolder>();
        if (holder == null)
        {
            Debug.LogError("BlockHolder component not found in children.");
            return;
        }

        GameObject operatorBlock = factory.CreateBlock(BlockType.ArithmeticOperator, ArithmeticType.Add, holder.transform);
        GameObject value1 = factory.CreateBlock(BlockType.Literal_Float, DataType.CreateDataType<float>(7.5f), holder.transform);
        GameObject value2 = factory.CreateBlock(BlockType.Literal_Int, DataType.CreateDataType<int>(10), holder.transform);

        holder.AddExistingBlock(value1);
        holder.AddExistingBlock(operatorBlock);
        holder.AddExistingBlock(value2);

        operatorBlock.GetComponent<ArithmeticOperatorBlock>().setLeftChild(value1.GetComponent<CodeBlock>());
        operatorBlock.GetComponent<ArithmeticOperatorBlock>().setRightChild(value2.GetComponent<CodeBlock>());
        object result = operatorBlock.GetComponent<ArithmeticOperatorBlock>().Evaluate();

        if (result is int intValue)
        {
            Debug.Log($"Result of addition: {intValue}");
            holder.AddExistingBlock(factory.CreateBlock(BlockType.Literal_Int, DataType.CreateDataType<int>(intValue), holder.transform));
        }
        else if (result is float floatValue)
        {
            Debug.Log($"Result of addition: {floatValue}");
            holder.AddExistingBlock(factory.CreateBlock(BlockType.Literal_Float, DataType.CreateDataType<float>(floatValue), holder.transform));
        }
        else
        {
            Debug.LogError("Result is not a number.");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
