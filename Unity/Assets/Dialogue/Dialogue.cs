using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "NPC/Dialogue/Dialogue")]
public class Dialogue : ScriptableObject //ScriptableObject or Serializable?
{
    public string[] sentences;
    public DialogueEnding ending;
    public Dialogue previousDialogue;

    //check if this dialogue needs certain requirements
    public bool requirements = false;
    public int stageReq = 0;
    public int checkReq = 0;

}
