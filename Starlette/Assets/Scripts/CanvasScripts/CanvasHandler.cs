using UnityEngine;

public class CanvasHandler: MonoBehaviour
{
    private static CanvasHandler _instance;
    [SerializeField] private GameObject _backgroundCanvas;

    public static CanvasHandler Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<CanvasHandler>();
            }
            return _instance;
        }
    }

    public Canvas GetCanvasByName(string name)
    {
        GameObject canvasObject = GameObject.Find(name);
        if (canvasObject != null)
        {
            return canvasObject.GetComponent<Canvas>();
        }
        else
        {
            Debug.LogError("Canvas not found: " + name);
            return null;
        }
    }



    public void ToggleCanvas(string name)
    {
        _backgroundCanvas.SetActive(!_backgroundCanvas.activeSelf);

    }
}
