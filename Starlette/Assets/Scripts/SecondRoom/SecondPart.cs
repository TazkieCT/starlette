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



    private void SetUpRightPart()
    {

    }


    public void ShowSecondPart()
    {
        firstPart.SetActive(false);
        secondPart.SetActive(true);
    }
}