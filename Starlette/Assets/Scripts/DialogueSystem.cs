using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class DialogueSystem : MonoBehaviour
{
    [Header("Text References")]
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI continuePrompt;

    [Header("Settings")]
    [SerializeField] private float typingSpeed = 0.05f;
    [SerializeField] private float continuePromptDelay = 0.2f;

    [Header("Dialogue Content")]
    [SerializeField] private List<string> dialogueLines = new List<string>();

    private int currentLineIndex = 0;
    private bool isTyping = false;
    private bool skipTyping = false;
    private Coroutine typingCoroutine;

    private void Start()
    {
        if (continuePrompt != null)
        {
            continuePrompt.gameObject.SetActive(false);
        }

        StartDialogue();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
                skipTyping = true;
            }
            else
            {
                if (continuePrompt != null)
                {
                    continuePrompt.gameObject.SetActive(false);
                }
                ShowNextLine();
            }
        }
    }

    public void StartDialogue()
    {
        currentLineIndex = 0;
        typingCoroutine = StartCoroutine(TypeDialogue(dialogueLines[currentLineIndex]));
    }

    private IEnumerator TypeDialogue(string line)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char letter in line.ToCharArray())
        {
            if (skipTyping)
            {
                dialogueText.text = line;
                skipTyping = false;
                break;
            }

            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;

        if (continuePrompt != null)
        {
            yield return new WaitForSeconds(continuePromptDelay);
            continuePrompt.gameObject.SetActive(true);
        }
    }

    private void ShowNextLine()
    {
        currentLineIndex++;

        if (currentLineIndex < dialogueLines.Count)
        {
            typingCoroutine = StartCoroutine(TypeDialogue(dialogueLines[currentLineIndex]));
        }
        else
        {
            // Dialogue ended
            dialogueText.text = "";
            if (continuePrompt != null)
            {
                continuePrompt.gameObject.SetActive(false);
            }
        }
    }

    public void SetDialogueLines(List<string> newLines)
    {
        dialogueLines = newLines;
        currentLineIndex = 0;
        StartDialogue();
    }
}