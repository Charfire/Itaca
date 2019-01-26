using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Axe ending", menuName = "NPC/Dialogue/Ending/GiveAxe")]
public class GiveAxeEnding : DialogueEnding
{
    public override void EndDialogue()
    {
        FindObjectOfType<PlayerController>().GainAbility("Axe");
    }
}
