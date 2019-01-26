using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

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

    public event Action<Dialogue> DialogueSuccesfullyEnded;

    private void Awake()
    {
        dialogueManager = this;
    }

    private void Start()
    {
        sentences = new Queue<string>();
        inConversation = false;
        gameObject.SetActive(false);
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

    public void StartConversation(Dialogue dialogue, Sprite npcImage, string npcName)
    {
        nameText.text = npcName;
        npcSprite.sprite = npcImage;
        StartConversation(dialogue);
    }

    public void StartConversation(Dialogue dialogue)
    {
        if (dialogue == null)
        {
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
        if (currentDialogue.ending != null)
        {
            bool successfullyEndedDialogue = currentDialogue.ending.EndDialogue();
            if (successfullyEndedDialogue)
            {
                DialogueSuccesfullyEnded(currentDialogue);
            }
        }
    }

}
