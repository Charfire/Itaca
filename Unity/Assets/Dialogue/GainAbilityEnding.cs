using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ability Ending", menuName = "NPC/Dialogue/Ending/Ability Ending")]
public class GainAbilityEnding : DialogueEnding
{
    public string ability;
    public Sprite newModel;

    public override bool EndDialogue(GameObject obj)
    {
        FindObjectOfType<PlayerController>().GainAbility(ability);
        obj.GetComponentInChildren<SpriteRenderer>().sprite = newModel;
        return true;
    }
}
