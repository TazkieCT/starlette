using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject startGameUI;
    public GameObject loginGameUI;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Username") && !string.IsNullOrEmpty(PlayerPrefs.GetString("Username")))
        {
            // Load the saved username and proceed to the main menu
            startGameUI.SetActive(true);
            loginGameUI.SetActive(false);
        }
        else
        {
            // Show the login UI if no username is saved
            startGameUI.SetActive(false);
            loginGameUI.SetActive(true);
        }
    }


    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }

    public void Leaderboard()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LeaderboardOverlay");
    }

    public void GoToAuth()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Auth");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}