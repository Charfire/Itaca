using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text nameText;
    public Image npcSprite;
    public Text sentenceText;

    public Queue<string> sentences;

    private void Start()
    {
        sentences = new Queue<string>();
        dialogueBox.SetActive(false);
    }

    public void StartConversation(Dialogue dialogue)
    {
        nameText.text = dialogue.name;
        npcSprite.sprite = dialogue.npcImage;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        NextSentence();
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
        dialogueBox.SetActive(false);
    }

}
