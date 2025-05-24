using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public AuthManager authManager;

    public void OnRegisterButton()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;
        Debug.Log("Username: " + username + " | password: " + password);
        authManager.RegisterUser(username, password);
    }

    public void OnLoginButton()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;
        Debug.Log("Username: " + username + " | password: " + password);
        authManager.LoginUser(username, password);
    }
}
