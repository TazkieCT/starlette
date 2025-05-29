using System.Text;
using TMPro;
using UnityEngine;

public class LastPuzzleInterface : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI patternText;

    void Start()
    {
        patternText.text = CreateSquarePattern();
    }

    // Update is called once per frame
    void Update()
    {

    }

    string CreateSquarePattern()
    {
        int size = 5;
        StringBuilder patternBuilder = new StringBuilder();
        
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (i == 0 || i == size - 1 || j == 0 || j == size - 1)
                {
                    patternBuilder.Append("*");
                }
                else
                {
                    patternBuilder.Append(" ");
                }
            }
            patternBuilder.AppendLine(); 
        }
        return patternBuilder.ToString();
    }
    
    }
