using UnityEngine;

public class FirstPart : MonoBehaviour, Interactable, IShowModal
{

    [SerializeField] private Canvas canvas;
    private CanvasHandler canvasHandler;
    private void Awake()
    {
        canvasHandler = CanvasHandler.Instance;
        if (canvas == null)
        {
            Debug.LogError("Canvas is not assigned in the inspector.");
        }
    }
    public void Interact()
    {
        // Execute the puzzle logic when the object is interacted with
        Debug.Log("Interacted with FirstPart!");
        // PuzzleScript puzzleScript = GetComponent<PuzzleScript>();
        // if (puzzleScript != null)
        // {
        //     puzzleScript.executePuzzle();
        // }
        ToggleModal();
    }

    public void ToggleModal()
    {
        canvasHandler.ToggleCanvas("testing");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
