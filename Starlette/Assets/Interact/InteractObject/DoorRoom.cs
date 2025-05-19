using UnityEngine;

public class DoorRoomOne : MonoBehaviour, Interactable
{
    public GameObject spawnPoint;
    public GameObject character;
    public void Interact()
    {
        character.transform.position = spawnPoint.transform.position;
    }

}
