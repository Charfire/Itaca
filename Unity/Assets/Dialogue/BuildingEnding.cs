using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Building Ending", menuName = "NPC/Dialogue/Ending/Building Ending")]
public class BuildingEnding : DialogueEnding
{
    [SerializeField]
    protected GameObject buildingToPlace;
    [SerializeField]
    protected Vector2 placeCoordinates;
    [SerializeField]
    protected int cost;
    [SerializeField]
    protected string resource;
    public Dialogue successDialogue;
    public Dialogue failDialogue;

    public override void EndDialogue()
    {
        if (resource == "wood")
        {
            if (ResManager.resourceManager.wood < cost)
            {
                DialogueManager.dialogueManager.StartConversation(failDialogue);
            }
            else
            {
                DialogueManager.dialogueManager.StartConversation(successDialogue);
                ResManager.resourceManager.wood = -cost;
                Vector3 position = new Vector3(placeCoordinates.x, placeCoordinates.y, 0);
                Instantiate(buildingToPlace, position, Quaternion.identity);
            }
        }
    }

}
