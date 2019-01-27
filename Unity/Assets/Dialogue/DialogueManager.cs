using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public enum NonPC { Woodcutter, Hunter, Miner, Fisher, Electric };

public class DialogueManager : MonoBehaviour
{

    [SerializeField]
    private Text nameText;
    [SerializeField]
    private Image npcSprite;
    [SerializeField]
    private Text sentenceText;

    public Dialogue currentDialogue;
    public Queue<string> sentences;
    public bool inConversation;

    public static DialogueManager dialogueManager;

    public event Action<Dialogue, GameObject> DialogueSuccesfullyEnded;

    private GameObject talkingPlayer;

    private ProgressManager progressMan;

    private void Awake()
    {
        dialogueManager = this;
    }

    private void Start()
    {
        sentences = new Queue<string>();
        inConversation = false;
        gameObject.SetActive(false);

        progressMan = new ProgressManager();

    }

    private void Update()
    {
        if (!inConversation)
        {
            return;
        }

        if (Input.GetButtonDown("Jump"))
        {
            NextSentence();
        }
    }

    public void StartConversation(Dialogue dialogue, Sprite npcImage, string npcName, GameObject obj)
    {
        nameText.text = npcName;
        npcSprite.sprite = npcImage;
        StartConversation(dialogue);
        talkingPlayer = obj;
    }

    public void StartConversation(Dialogue dialogue)
    {
        bool continueDialogue = true;
        
        if (dialogue == null)
        {
            return;
        }

        //check if any unmet requirements exist
        if (dialogue.requirements == true)
        {
            if(dialogue.stageReq > 0)
            {
                if (progressMan.IsGameStageReached(dialogue.stageReq) == false)
                {
                    continueDialogue = false;
                }
            }

            if(dialogue.checkReq > 0)
            {
                if(progressMan.IsNPCCheckpointReached(dialogue.checkNPC, dialogue.checkReq) == false)
                {
                    continueDialogue = false;
                }
            }
        }

        if(continueDialogue == false)
        {
            //!!!!!
            //TODO: Make the requirements failed sentence come up
            //!!!!!

            return;
        }


        currentDialogue = dialogue;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        NextSentence();
        inConversation = true;
        gameObject.SetActive(true);


    }

    public void NextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        sentenceText.text = sentence;

    }

    public void EndDialogue()
    {
        inConversation = false;
        gameObject.SetActive(false);
        if (talkingPlayer.name == "Player")
        {
            return;
        }
        if (currentDialogue.ending != null)
        {
            bool successfullyEndedDialogue = currentDialogue.ending.EndDialogue(talkingPlayer);
            if (successfullyEndedDialogue)
            {
                DialogueSuccesfullyEnded(currentDialogue, talkingPlayer);
            }
        }
    }
    
    

}
