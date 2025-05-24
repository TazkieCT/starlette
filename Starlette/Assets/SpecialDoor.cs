using UnityEngine;

public class SpecialDoor : MonoBehaviour,Interactable
{
    public GameObject spawnPoint;
    public Check2Monitor check2Monitor;
    public void Interact()
    {
        bool isFinishHiddenPuzzle = check2Monitor.GetIsFinishHiddenPuzzle();

        // udah siapin hidden puzzle
        if (isFinishHiddenPuzzle)
        {
            Debug.Log("udh hidden");
        }
        // belum siapin hidden puzzle
        else
        {
            Debug.Log("blm hidden");
        }
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
