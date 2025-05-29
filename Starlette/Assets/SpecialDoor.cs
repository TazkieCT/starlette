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

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = spawnPoint.transform.position;

            Vector2 faceDirection = Vector2.up;
            player.GetComponent<PlayerMovement>().SetFacingDirection(faceDirection);
            Debug.Log("Interacting with UserTeleporter");
        }
        else
        {
            Debug.LogWarning("Player not found");
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
