using UnityEngine;

public enum GameState { FreeRoam, Interacting }
public class GameController : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;

    GameState state;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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

    // Update is called once per frame
    private void Update()
    {
        if(state == GameState.FreeRoam){
            playerMovement.HandleUpdate();
        }else if(state == GameState.Interacting){
            DialogManager.Instance.HandleUpdate();
        }
    }
}
