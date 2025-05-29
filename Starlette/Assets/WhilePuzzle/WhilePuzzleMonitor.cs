using UnityEngine;

public class WhilePuzzleMonitor : MonoBehaviour, Interactable
{
    [SerializeField] WhilePuzzleTask whilePuzzleTask;
    [SerializeField] GameController gameController;
    [SerializeField] GameObject whilePuzzleInterface;
    public void Interact()
    {
        if (whilePuzzleTask.GetIsDone())
        {
            whilePuzzleTask.successErrorManagerScreen.SetStatusSuccesScreen(true);
            return;
        }
        gameController.SetState("OnPuzzle");
        whilePuzzleInterface.SetActive(true);
    }
}
