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
        for (int i = 0; i < 3; i++)
        {
            RandomizeBlocks(holder);
        }
    }

    private void RandomizeBlocks(BlockHolder holder)
    {

        BlockType randomType = GetRandomType();
        if (randomType == BlockType.Literal_Float)
        {
            FloatType randomValue = FloatType.GetRandomValue();
            GameObject block = factory.CreateBlock(randomType, randomValue, holder.transform);
            holder.AddBlock(block);
        }
        else if (randomType == BlockType.Literal_Int)
        {
            Integer randomValue = Integer.GetRandomValue();
            GameObject block = factory.CreateBlock(randomType, randomValue, holder.transform);
            holder.AddBlock(block);
        }
        else if (randomType == BlockType.Literal_Bool)
        {
            Boolean randomValue = Boolean.GetRandomValue();
            GameObject block = factory.CreateBlock(randomType, randomValue, holder.transform);
            holder.AddBlock(block);
        }

    }

    private BlockType GetRandomType()
    {
        int randomIndex = Random.Range(0, 3);
        return randomIndex switch
        {
            0 => BlockType.Literal_Float,
            1 => BlockType.Literal_Int,
            2 => BlockType.Literal_Bool,
            _ => BlockType.Literal_Int // Default case
        };
    }
}
