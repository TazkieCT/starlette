using UnityEngine;

public class DoorRoom : MonoBehaviour, Interactable
{
    public GameObject spawnPoint;
    public GameObject character;
    public RoomID currentRoom;

    public void Interact()
    {
        var roomData = RoomProgressManager.Instance.GetRoomData(currentRoom);

        if (roomData.progress >= 100f)
        {
            character.transform.position = spawnPoint.transform.position;
            RoomProgressManager.Instance.EndRoom(roomData.roomID);
            Debug.Log("Move to next room.");
        }
        else
        {
            Debug.Log($"Cant move to next room. Progress {roomData.progress}%");
            //Nanti disini kita panggil dialogue
        }
    }
}
