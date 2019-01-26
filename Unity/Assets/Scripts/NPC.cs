using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField]
    private Dialogue currentDialogue;

    [SerializeField]
    private Sprite dialogueImage;


    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<PlayerController>().PlayerInteraction += OnPlayerInteraction;
    }


    public void OnPlayerInteraction(RaycastHit2D hit)
    {
        if (hit.transform.gameObject != gameObject)
        {
            return;
        }

        DialogueManager.dialogueManager.StartConversation(currentDialogue, dialogueImage, name);
    }
}
