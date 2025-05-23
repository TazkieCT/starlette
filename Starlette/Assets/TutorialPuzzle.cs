using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPuzzle : MonoBehaviour
{
    public GameObject[] listChoiceButton;

    public Sprite defaultChoiceSprite;
   
    ArrayList listUserChoice;
    public TabletManager tabletManager;
    private string answer = "include, main, scanf, printf, return";
    void Start()
    {
        listUserChoice = new ArrayList();
    }

  

    public void addChoice(TextMeshProUGUI choice)
    {
        Debug.Log(choice.text);
        listUserChoice.Add(choice.text);
    }

    public void checkResult()
    {
        Debug.Log(string.Join(", ", listUserChoice.ToArray()));
        if (string.Join(", ", listUserChoice.ToArray()).Equals(answer))
        {
            tabletManager.greetingText.text = "Hello, " + tabletManager.getUsername();
            tabletManager.setStatusPuzzleInterface (false);
            tabletManager.setStatusSuccessInterface(true);
        }
        else
        {
            tabletManager.setStatusPuzzleInterface (false);
            tabletManager.setStatusErrorInterface(true);
        }
    }

    public void resetChoice()
    {

        foreach (GameObject item in listChoiceButton)
        {
            item.GetComponent<Image>().sprite = defaultChoiceSprite;
        }
        listUserChoice.Clear();
    }
}
