using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "NPC/Dialogue/Dialogue")]
public class Dialogue : ScriptableObject //ScriptableObject or Serializable?
{
    public string[] sentences;
    public DialogueEnding ending;
    public Dialogue previousDialogue;
}
