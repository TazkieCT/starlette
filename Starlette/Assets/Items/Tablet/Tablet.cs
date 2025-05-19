using UnityEngine;
[CreateAssetMenu(menuName = "Items/Tablet")]
public class Tablet : Item
{
    public override void Use()
    {
        GameController gameController = FindObjectOfType<GameController>();

        gameController.SetState("OnTablet");

        TabletManager tabletManager = gameController.GetComponent<TabletManager>();
        
        

        tabletManager.setStatusTabletInterface(true);
        tabletManager.setStatusMaterialOneInterface(true);
        Debug.Log("Tablet activated");
        Debug.Log("this is tablet");
    }
}
