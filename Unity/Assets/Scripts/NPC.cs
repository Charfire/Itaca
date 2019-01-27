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
        if (dialogueQueue.Peek().previousDialogue == null)
        {
            NextDialogue();
        }
    }


    public void OnPlayerInteraction(RaycastHit2D hit)
    {
        if (hit.transform.gameObject != gameObject)
        {
            return;
        }

        NonPC npcName = NonPC.Electric;

        switch (name)
        {
            case "Woodcutter":
                npcName = NonPC.Woodcutter;
                break;
            case "Miner":
                npcName = NonPC.Miner;
                break;
            case "Hunter":
                npcName = NonPC.Hunter;
                break;
            case "Fisher":
                npcName = NonPC.Fisher;
                break;
            case "Electrician":
                npcName = NonPC.Electric;
                break;
        }


        DialogueManager.dialogueManager.StartConversation(currentDialogue, dialogueImage, npcName, gameObject);
    }

    public void OnDialogueEnded(Dialogue dialogue, GameObject obj)
    {
        if(obj != gameObject)
        {
            Debug.Log("Hoi1");
            return;
        }
        if (currentDialogue == null)
        {
            Debug.Log("Hoi2");
            return;
        }
        if (currentDialogue.previousDialogue == null)
        {
            Debug.Log("Hoi3");
            NextDialogue();
            return;
        }
        //if (dialogue.previousDialogue != currentDialogue)
        //{
        //    Debug.Log("Hoi4");
        //    return;
        //}
        Debug.Log("Hoi5");
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
