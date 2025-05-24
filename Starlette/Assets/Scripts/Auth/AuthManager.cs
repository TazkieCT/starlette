using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AuthManager : MonoBehaviour
{
    public void RegisterUser(string username, string password)
    {
        FirebaseManager.Instance.DBReference.Child("users").Child(username).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.LogError("Error checking user: " + task.Exception);
                return;
            }

            if (task.Result.Exists)
            {
                Debug.Log("User already exists.");
            }
            else
            {
                FirebaseManager.Instance.DBReference.Child("users").Child(username)
                    .Child("password").SetValueAsync(password).ContinueWithOnMainThread(setTask =>
                    {
                        if (setTask.IsCompleted)
                            Debug.Log("User registered successfully.");
                    });
            }
        });
    }

    public void LoginUser(string username, string password)
    {
        FirebaseManager.Instance.DBReference.Child("users").Child(username).Child("password")
            .GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if (task.IsFaulted || task.IsCanceled)
                {
                    Debug.LogError("Error logging in: " + task.Exception);
                    return;
                }

                if (task.Result.Exists && task.Result.Value.ToString() == password)
                {
                    Debug.Log("Login successful!");
                    SceneManager.LoadScene("sceneWithCutscene");
                }
                else
                {
                    Debug.Log("Invalid username or password.");
                }
            });
    }
}
