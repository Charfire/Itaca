using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ability Ending", menuName = "NPC/Dialogue/Ending/Ability Ending")]
public class GainAbilityEnding : DialogueEnding
{
    public string ability;

    public override bool EndDialogue()
    {
        FindObjectOfType<PlayerController>().GainAbility(ability);
        return true;
    }
}
