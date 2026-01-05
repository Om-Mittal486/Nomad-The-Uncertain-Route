using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System; 

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    public static event Action OnDialogueEnded; 

    [Header("Dialogue Settings")]
    public Image characterIcon;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea;

    private Queue<DialogueLine> lines;

    public bool isDialogueActive = false;
    public float typingSpeed = 0.05f;
    public Animator animator;

    private bool isTyping;
    private string currentSentence;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        lines = new Queue<DialogueLine>();
    }

    void Update()
    {
        if (!isDialogueActive) return;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (isTyping)
            {
                StopAllCoroutines();
                dialogueArea.text = currentSentence;
                isTyping = false;
            }
            else
            {
                DisplayNextDialogueLine();
            }
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        isDialogueActive = true;
        animator.Play("show");

        lines.Clear();
        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
            lines.Enqueue(dialogueLine);

        DisplayNextDialogueLine();
    }

    public void DisplayNextDialogueLine()
    {
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine currentLine = lines.Dequeue();

        characterIcon.sprite = currentLine.character.Icon;
        characterName.text = currentLine.character.Name;

        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentLine.line));
    }

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        currentSentence = sentence;
        dialogueArea.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    void EndDialogue()
    {
        isDialogueActive = false;
        animator.Play("hide");

        OnDialogueEnded?.Invoke();
    }
}
