using UnityEngine;

public class MonitorRoom : MonoBehaviour, Interactable
{
    public GameController gameController;
    public GameObject puzzleInterface;
    public void Interact()
    {
        gameController.SetState("OnPuzzle");
        puzzleInterface.SetActive(true);
    }

   
}
