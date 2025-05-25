using UnityEngine;
using UnityEngine.UI;

public abstract class CodeBlock : MonoBehaviour, IStringable
{
    void Awake()
    {
        Button button = gameObject.AddComponent<Button>();
        button.onClick.AddListener(BlockClicked);
    }
    public string BlockId { get; set; }
    public override abstract string ToString();
    public abstract object Evaluate(CompilerContext context = null);

    public abstract void Init(object value);

    private void BlockClicked()
    {
        // take holder parent
        // transfer this block only 
        BaseBlockContainer container = gameObject.GetComponentInParent<BaseBlockContainer>();
        Debug.Log(container.gameObject.name);
        container.TransferBlockToPartner(gameObject);
    }
}
