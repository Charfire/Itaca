using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "NPC/Dialogue/Ending/FailEnding")]
public class FailDialogueEnding : DialogueEnding
{
    public override bool EndDialogue(GameObject obj)
    {
        return false;
    }
}
