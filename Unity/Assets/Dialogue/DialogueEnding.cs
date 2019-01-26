using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "NPC/Dialogue/Ending")]
public abstract class DialogueEnding : ScriptableObject
{
    public abstract bool EndDialogue();
}
