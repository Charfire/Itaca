using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField]
    Dialogue dialogue;

    DialogueManager dialogueManager;



    private void Start()
    {
        dialogueManager = DialogueManager.dialogueManager;
        //dialogueManager = GameObject.Find("Dialogue Box").GetComponent<DialogueManager>(); //Switch to singleton later
    }

    public void TriggerDialogue()
    {
        dialogueManager.StartConversation(dialogue);
    }
}
