using UnityEngine;


public class PanelInteractBehavior : MonoBehaviour, Interactable
{
    [SerializeField] public GameObject panelInterface;
    [SerializeField] public GameObject backgroundPanel;
    public void Interact()
    {
        if (panelInterface == null)
        {
            Debug.LogError("Panel Interface is not assigned.");
            return;
        }
        // Debug.Log($"Interacting with panel: {panelInterface.name}");
        backgroundPanel.GetComponent<OpenCloseBehavior>().OpenPanel(panelInterface.name);
    }
}