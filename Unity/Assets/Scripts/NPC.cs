using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
  
    [SerializeField]
    private Sprite dialogueImage;

    [SerializeField]
    private Dialogue[] allDialogues;

    private Queue<Dialogue> dialogueQueue;

    private Dialogue currentDialogue;


    void Start()
    {
        DialogueManager.dialogueManager.DialogueSuccesfullyEnded += OnDialogueEnded;
        FindObjectOfType<PlayerController>().PlayerInteraction += OnPlayerInteraction;
        dialogueQueue = new Queue<Dialogue>();
        foreach(Dialogue dialogue in allDialogues)
        {
            dialogueQueue.Enqueue(dialogue);
        }
        NextDialogue();
    }


    public void OnPlayerInteraction(RaycastHit2D hit)
    {
        if (hit.transform.gameObject != gameObject)
        {
            return;
        }

        DialogueManager.dialogueManager.StartConversation(currentDialogue, dialogueImage, name);
    }

    public void OnDialogueEnded(Dialogue dialogue)
    {
        Debug.Log("Dialogue is: " + dialogue.name);
        Debug.Log("Current dialogue is: " + currentDialogue.name);
        if (currentDialogue.previousDialogue == null)
        {
            return;
        }
        if (dialogue != currentDialogue.previousDialogue)
        {
            return;
        }
        Debug.Log("Previous Dialoge ended");
        NextDialogue();
    }

    public void NextDialogue()
    {
        if (dialogueQueue.Count == 0)
        {
            return;
        }
        currentDialogue = dialogueQueue.Dequeue();
    }
}
