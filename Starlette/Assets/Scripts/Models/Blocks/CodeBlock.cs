using UnityEngine;

public abstract class CodeBlock : MonoBehaviour, IStringable
{
    public string BlockId { get; set; }
    public override abstract string ToString();
    public abstract object Evaluate(CompilerContext context);

    public abstract void Init(object value);
}
