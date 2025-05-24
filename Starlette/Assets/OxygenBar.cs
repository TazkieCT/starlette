using UnityEngine;
using UnityEngine.UI; 

public class OxygenBar : MonoBehaviour
{
    public Image oxygenImage;
    public float speed;
    void Start()
    {
        if (oxygenImage != null)
        {
            oxygenImage.fillAmount = 0f; 
        }
    }

    public void Update()
    {
        if (oxygenImage != null)
        {
            oxygenImage.fillAmount += speed * Time.deltaTime;

           
        }
    }
}
