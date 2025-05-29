using UnityEngine;
using UnityEngine.UI;

public class ControlEnergyMonitorTask : MonoBehaviour
{

    GameObject selectedDoor;
    string chargedDoor;
    public GameObject doorCapsuleRoomUI;
    public GameObject door6UI;
    public Sprite selectedStatus;
    public Sprite unSelectedStatus;
    public GameObject doorCapsuleRoom;
    public GameObject doorRoom6;

    [SerializeField] ForPuzzleTask forPuzzleTask;
    [SerializeField] WhilePuzzleTask whilePuzzleTask;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (chargedDoor == "DoorToCapsule")
        {
            doorCapsuleRoomUI.transform.Find("DoorStat").gameObject.GetComponent<Image>().sprite = selectedStatus;
            door6UI.transform.Find("DoorStat").gameObject.GetComponent<Image>().sprite = unSelectedStatus;

            if (forPuzzleTask.GetIsDone() && whilePuzzleTask.GetIsDone())
            {
                ControlDoorsActiveGameObject("Interactable", "UI", true, false);
            }
        }
        else if (chargedDoor == "Door6")
        {
            doorCapsuleRoomUI.transform.Find("DoorStat").gameObject.GetComponent<Image>().sprite = unSelectedStatus;
            door6UI.transform.Find("DoorStat").gameObject.GetComponent<Image>().sprite = selectedStatus;

            if (forPuzzleTask.GetIsDone() && whilePuzzleTask.GetIsDone())
            {
                ControlDoorsActiveGameObject("UI", "Interactable", false, true);
            }
        }
    }

    void ControlDoorsActiveGameObject(string doorCapsuleRoomLayer, string doorRoom6Layer, bool doorCapsuleRoomBoolean, bool doorRoom6Boolean)
    {
        doorCapsuleRoom.layer = LayerMask.NameToLayer(doorCapsuleRoomLayer);
        doorCapsuleRoom.transform.Find("InteractRange").gameObject.SetActive(doorCapsuleRoomBoolean);
        doorRoom6.layer = LayerMask.NameToLayer(doorRoom6Layer);
        doorRoom6.transform.Find("InteractRange").gameObject.SetActive(doorRoom6Boolean);
    }
    
    public void ChargedDoor()
    {
        chargedDoor = selectedDoor.name;

    }

    public void SelectedDoor(GameObject gameObject)
    {
        gameObject.GetComponent<Image>().color = Color.white;
        selectedDoor = gameObject;
    }

    public void setColorDoor(GameObject gameObject)
    {
         if (ColorUtility.TryParseHtmlString("#878787", out Color newColor))
    {
        gameObject.GetComponent<Image>().color = newColor;
    }
    }
}
