using UnityEngine;

public class LeaveCapsule : MonoBehaviour, Interactable
{
    public GameObject endingScene;

    public void Interact()
    {
        endingScene.SetActive(true);
    }
}
