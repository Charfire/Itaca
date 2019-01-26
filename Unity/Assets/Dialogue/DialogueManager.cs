using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private GameObject dialogueBox;
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

    private void Awake()
    {
        dialogueManager = this;
    }

    private void Start()
    {
        sentences = new Queue<string>();
        inConversation = false;
        dialogueBox.SetActive(false);
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
        currentDialogue = dialogue;
        nameText.text = npcName;
        npcSprite.sprite = npcImage;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        NextSentence();
        inConversation = true;
        dialogueBox.SetActive(true);
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
        dialogueBox.SetActive(false);
        currentDialogue.ending.EndDialogue();
    }

}
