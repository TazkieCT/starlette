using UnityEngine;


public class PanelInteractBehavior : MonoBehaviour, Interactable
{
    [SerializeField] public GameObject panelInterface;
    [SerializeField] public OpenCloseBehavior backgroundPanel;
    public void Interact()
    {
        
        backgroundPanel.OpenPanel(panelInterface.name);
    }
}