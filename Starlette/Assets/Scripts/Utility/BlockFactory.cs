
using System;
using System.Collections.Generic;
using Mono.Cecil.Cil;
using TMPro;
using UnityEngine;

public enum BlockType
{
    Literal_Int,
    Literal_Float,
    Literal_Bool,
    Variable_Int,
    Variable_Float,
    Variable_Bool,
    AssignmentOperator,
    LogicalOperator,
    ArithmeticOperator,
    ComparisonOperator,
    Parenthesis,
}

public class BlockFactory : MonoBehaviour
{
    public static BlockFactory Instance;
    [Serializable]
    public struct BlockEntry
    {
        public BlockType BlockType;
        public GameObject Prefab;
    }

    public List<BlockEntry> BlockEntries;
    private Dictionary<BlockType, GameObject> blockPrefabs;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        blockPrefabs = new Dictionary<BlockType, GameObject>();
        foreach (var entry in BlockEntries)
        {
            blockPrefabs[entry.BlockType] = entry.Prefab;
        }
    }

    public GameObject CreateBlock(BlockType type, object value, Transform parent = null)
    {
        if (!blockPrefabs.ContainsKey(type))
        {
            throw new ArgumentException($"Block type {type} not found in factory.");
        }

        GameObject prefab = blockPrefabs[type];
        GameObject instance = Instantiate(prefab, parent);
        if (value != null)
        {
            CodeBlock block = instance.GetComponent<CodeBlock>();
            if (block != null)
            {
                block.Init(value);
            }
            TextMeshProUGUI text = instance.GetComponentInChildren<TextMeshProUGUI>();
            if (text != null)
            {
                text.text = block.ToString();
            }
        }
        return instance;
    }
}