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
    protected Resource resource;
    public Dialogue successDialogue;
    public Dialogue failDialogue;

    public override bool EndDialogue()
    {

            if (ResManager.resourceManager.GetResourceAmount(resource) < cost)
            {
                DialogueManager.dialogueManager.StartConversation(failDialogue);
            return false;
            }
            else
            {
                DialogueManager.dialogueManager.StartConversation(successDialogue);
                ResManager.resourceManager.AddResourceAmount(resource, -cost);

                if (buildingToPlace != null)
                {
                    Vector3 position = new Vector3(placeCoordinates.x, placeCoordinates.y, 0);
                    Instantiate(buildingToPlace, position, Quaternion.identity);
                }
            return true;
            }
    }


}
