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
        if (dialogue == null)
        {
            return;
        }

        if (dialogue.requirements == true)
        {



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
        if (currentDialogue.ending != null)
        {
            bool successfullyEndedDialogue = currentDialogue.ending.EndDialogue(talkingPlayer);
            if (successfullyEndedDialogue)
            {
                DialogueSuccesfullyEnded(currentDialogue, talkingPlayer);
            }
        }
    }

    private void ResetNPCChecks()
    {

    }

}
