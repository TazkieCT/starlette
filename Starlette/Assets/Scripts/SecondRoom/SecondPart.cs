using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SecondPart : MonoBehaviour
{
    [SerializeField] private GameObject secondPart;
    [SerializeField] private GameObject firstPart;
    [SerializeField] private BlockFactory blockFactory;
    private CompilerContext context;

    private void Start()
    {
        context = GetComponentInParent<CompilerContext>();
        if (context == null)
        {
            Debug.LogError("CompilerContext not found in the parent.");
            return;
        }

        if (firstPart == null || secondPart == null)
        {
            Debug.LogError("First or Second part GameObject is not assigned.");
            return;
        }

        firstPart.SetActive(true);
        secondPart.SetActive(false);

        SetUpLeftPart();
        SetUpRightPart();
    }

    private void SetUpRightPart()
    {
        BlockHolder holder = secondPart.GetComponentInChildren<BlockHolder>();
        SetUpVariableBlocks(holder);
    }

    private void SetUpLeftPart()
    {
        // randomize 2 literal block at above
        SetUpLiteralBlock();
        SetUpOperatorBlock();
    }   

    private void SetUpLiteralBlock()
    {
        LiteralBlock[] intBlocks = firstPart.GetComponentsInChildren<LiteralBlock>();
        SetUpTopBlockListener(intBlocks[0]);
        SetUpTopBlockListener(intBlocks[1]);
    }

    private void SetUpTopBlockListener(LiteralBlock block)
    {
        // add listener to block
        block.gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
        block.gameObject.GetComponent<Button>().onClick.AddListener(() =>
        {
            // when clicked, transfer to the holder.
            if (block.GetComponentInParent<BlockHolder>() == null)
            {
                // state pindahin ke BlockHolder
                GameObject cloneBlock = blockFactory.CreateBlock(BlockType.Literal_Int, block.GetValue(), firstPart.transform);
                cloneBlock.GetComponent<Button>().onClick.AddListener(() =>
                {
                    // state pindahin ke BlockHolder
                    cloneBlock.GetComponent<Button>().onClick.RemoveAllListeners();
                    cloneBlock.GetComponentInParent<BlockHolder>().RemoveBlock(cloneBlock);
                    Destroy(cloneBlock);
                });

                firstPart.GetComponentInChildren<BlockHolder>().AddBlock(cloneBlock);
            }
            
        });
        block.Init(Integer.GetRandomValue());
        block.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = block.ToString();
    }

    private void SetUpOperatorBlock()
    {
        FreeBlockContainer container = firstPart.GetComponentInChildren<FreeBlockContainer>();
        if (container == null)
        {
            Debug.LogError("FreeBlockContainer not found in the first part.");
            return;
        }

        SetParenthesisBlock(container);
        SetUpAritmethicBlock(container);
        SetUpComparisonBlock(container);
    }

    private void SetParenthesisBlock(FreeBlockContainer container)
    {
        float x = -180.0f + container.GetSpacing();
        foreach (ParenthesisType type in System.Enum.GetValues(typeof(ParenthesisType)))
        {
            ParenthesisBlock parenthesisBlock = blockFactory.CreateBlock(BlockType.Parenthesis, type, container.transform).GetComponent<ParenthesisBlock>();
            parenthesisBlock.Init(type);
            parenthesisBlock.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = parenthesisBlock.ToString();
            parenthesisBlock.gameObject.transform.localPosition = new Vector3(x, 40, 0);
            x += FreeBlockContainer.GetBlockWidth(parenthesisBlock.gameObject) + container.GetSpacing();
        }
    }

    private void SetUpAritmethicBlock(FreeBlockContainer container)
    {
        float x = -180.0f + container.GetSpacing();
        foreach (ArithmeticType type in System.Enum.GetValues(typeof(ArithmeticType)))
        {
            ArithmeticOperatorBlock arithmeticBlock = blockFactory.CreateBlock(BlockType.ArithmeticOperator, type, container.transform).GetComponent<ArithmeticOperatorBlock>();
            arithmeticBlock.Init(type);
            arithmeticBlock.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = arithmeticBlock.ToString();
            arithmeticBlock.gameObject.transform.localPosition = new Vector3(x, 0, 0);
            x += FreeBlockContainer.GetBlockWidth(arithmeticBlock.gameObject) + container.GetSpacing();
        }
    }

    private void SetUpComparisonBlock(FreeBlockContainer container)
    {
        float x = -180.0f + container.GetSpacing();
        foreach (ComparisonType type in System.Enum.GetValues(typeof(ComparisonType)))
        {
            if( type == ComparisonType.LessEqual || type == ComparisonType.GreaterEqual || type == ComparisonType.NotEqual) continue; 
            ComparisonOperatorBlock comparisonBlock = blockFactory.CreateBlock(BlockType.ComparisonOperator, type, container.transform).GetComponent<ComparisonOperatorBlock>();
            comparisonBlock.Init(type);
            comparisonBlock.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = comparisonBlock.ToString();
            comparisonBlock.gameObject.transform.localPosition = new Vector3(x, -40, 0);
            x += FreeBlockContainer.GetBlockWidth(comparisonBlock.gameObject) + container.GetSpacing();
        }
    }

    public void ExecuteSequence(BaseBlockContainer holder)
    {
        // Implementation for executing the code block
        if (holder == null)
        {
            // bukain panel nanti
            Debug.LogError("Holder is null, cannot execute sequence.");
            return;
        }
        List<GameObject> blocks = holder.GetAllBlocks();
        // Debug.Log($"Executing sequence with {blocks.Count} blocks.");
        VariableBlock variableBlock = firstPart.GetComponentInChildren<VariableBlock>();
        if (variableBlock == null)
        {
            Debug.LogError("First block is not a VariableBlock.");
            return;
        }

        
        PayloadResultModel variableCheck = VariableBlockAdapter.IsValidVariableName(variableBlock.VariableName);
        if (variableCheck.Success == false)
        {
            // open panel
            Debug.LogError($"{variableCheck.Message}");
            return;
        }

        AssignmentOperatorBlock assignmentObject = firstPart.GetComponentInChildren<AssignmentOperatorBlock>();
        if (assignmentObject == null)
        {
            Debug.LogError("Assignment block is not of type AssignmentOperatorBlock.");
            return;
        }

        List<CodeBlock> codeBlocks = new List<CodeBlock>();
        foreach (GameObject block in blocks)
        {
            CodeBlock codeBlock = block.GetComponent<CodeBlock>();
            if (codeBlock == null)
            {
                Debug.LogError($"Block {block.name} is not a valid CodeBlock.");
                return;
            }
            Debug.Log($"Adding block {codeBlock.ToString()} to code blocks.");
            codeBlocks.Add(codeBlock);

        }

        List<CodeBlock> postFix = ExpressionTreeBuilder.ToPostfix(codeBlocks);
        CodeBlock root = ExpressionTreeBuilder.BuildExpressionTree(postFix);
        // Debug.Log($"Root of expression tree: {root.Evaluate(context)}");
        if (root == null)
        {
            Debug.LogError("Failed to build expression tree from blocks.");
            return;
        }


        assignmentObject.setLeftChild(variableBlock);
        assignmentObject.setRightChild(root);

        object result = assignmentObject.Evaluate(context);
        // Debug.Log($"Assignment result: {(result is VariableBlock ? "Yes" : "maklo")}");
        if (result is VariableBlock blockResult)
        {
            BlockHolder secondHolder = secondPart.GetComponentInChildren<BlockHolder>();
            if (secondHolder == null)
            {
                Debug.LogError("BlockHolder not found in the second part.");
                return;
            }

            BlockType blockType = BlockFactory.GetBlockTypeFromVariables(blockResult);
            GameObject newBlock = blockFactory.CreateBlock(blockType, blockResult, transform);
            secondHolder.AddBlock(newBlock);
        }
        ResetContainerState(holder);
    }

    private void ResetContainerState(BaseBlockContainer container)
    {
        // reset state field kalau semuanya berhasil. ( reset free from containernya doang.)
        // Instantiate VariableAdapter baru
        GameObject adapter = firstPart.GetComponentInChildren<VariableBlockAdapter>().gameObject;
        if (adapter == null)
        {
            Debug.LogError("VariableBlockAdapter not found in the first part.");
            return;
        }

        GameObject newAdapter = blockFactory.CreateBlock(BlockType.Variable_Adapter, DataType.CreateDataType<int>(null), firstPart.transform);
        // assign the same position and parent as the old adapter
        newAdapter.transform.position = adapter.transform.position;
        newAdapter.transform.SetParent(adapter.transform.parent);
        // destroy the old adapter
        Debug.Log($"Destroying adapter {adapter.name} and replacing it with a new VariableAdapter.");
        Destroy(adapter);
        List<GameObject> blocks = container.GetAllBlocks();

        // Go through each block
        for (int i = 0; i < blocks.Count; i++)
        {
            GameObject block = blocks[i];

            container.RemoveBlock(block);
            Destroy(block);
        }
        container.SetBlocks(blocks);
    }


    private void SetUpVariableBlocks(BlockHolder holder)
    {
        List<VariableBlock> variableBlocks = context.GetAllVariables();
        if (variableBlocks.Count == 0)
        {
            Debug.LogWarning("No variable blocks found in the context.");
            return;
        }

        foreach (VariableBlock block in variableBlocks)
        {
            holder.AddBlock(block.gameObject);
        }
    }
    public void ShowSecondPart()
    {
        firstPart.SetActive(false);
        secondPart.SetActive(true);
    }
}