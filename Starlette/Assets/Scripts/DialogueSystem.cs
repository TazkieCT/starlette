using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    [Header("Text References")]
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI continuePrompt;

    [Header("Settings")]
    [SerializeField] private float typingSpeed = 0.05f;
    [SerializeField] private float continuePromptDelay = 0.2f;

    [Header("Dialogue Setup")]
    [SerializeField] private DialogTextDB dialogDB;
    [SerializeField] private RoomID selectedRoom;
    [SerializeField] private DialogueID selectedDialogue;

    private List<string> dialogueLines;
    private int currentLineIndex = 0;
    private bool isTyping = false;
    private bool skipTyping = false;
    private Coroutine typingCoroutine;

    private void Start()
    {
        if (continuePrompt != null)
            continuePrompt.gameObject.SetActive(false);

        dialogueLines = dialogDB.GetDialogueLines(selectedRoom, selectedDialogue);

        if (dialogueLines == null || dialogueLines.Count == 0)
        {
            Debug.LogWarning($"Dialog kosong untuk Room: {selectedRoom} dan Dialog: {selectedDialogue}");
            return;
        }

        StartDialogue();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
                skipTyping = true;
            else
            {
                if (continuePrompt != null)
                    continuePrompt.gameObject.SetActive(false);

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
            dialogueText.text = "";
            if (continuePrompt != null)
                continuePrompt.gameObject.SetActive(false);
        }
    }
}
