using UnityEngine;


public class PanelInteractBehavior : MonoBehaviour, Interactable
{
    [SerializeField] public GameObject panelInterface;
    [SerializeField] public GameObject panelChild;
    [SerializeField] public GameObject backgroundPanel;
    public void Interact()
    {
        if (panelInterface == null)
        {
            Debug.LogError("Panel Interface is not assigned.");
            return;
        }
        // Debug.Log($"Interacting with panel: {panelInterface.name}");
        if (panelChild == null)
        {
            backgroundPanel.GetComponent<OpenCloseBehavior>().OpenPanel(panelInterface.name);
        }
        else
        {
            backgroundPanel.GetComponent<OpenCloseBehavior>().OpenPanel(panelInterface.name);
            foreach (Transform child in panelInterface.transform)
            {
                if (child.gameObject.name == panelChild.name)
                {
                    child.gameObject.SetActive(true);
                }
                else
                {
                    child.gameObject.SetActive(false);
                }
            }
        }
        
    }
}