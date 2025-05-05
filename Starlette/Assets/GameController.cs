using UnityEngine;

public enum GameState { FreeRoam, Interacting }
public class GameController : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] OxygenBar oxygenBar;

    GameState state;
    private void Start()
    {
        
        DialogManager.Instance.OnShowDialog += () => {
            state = GameState.Interacting;
            Debug.Log("Interacting");
        };
        DialogManager.Instance.OnHideDialog += () => {
            if (state == GameState.Interacting){
                state = GameState.FreeRoam;
                Debug.Log("FreeRoam");
            }
        };
    }

    private void Update()
    {
        if(state == GameState.FreeRoam){
            playerMovement.HandleUpdate();
            oxygenBar.HandleUpdate();
        }else if(state == GameState.Interacting){
            DialogManager.Instance.HandleUpdate();
        }
    }
}
