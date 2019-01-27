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
    [SerializeField]
    protected GameObject Fade;
    [SerializeField]
    protected Vector2 newPosition;
    [SerializeField]
    protected bool bridge;

    public Dialogue successDialogue;
    public Dialogue failDialogue;

    public override bool EndDialogue(GameObject obj)
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
                    Transform canvas = FindObjectOfType<Canvas>().transform;
                    Instantiate(Fade, canvas);
                    Vector3 position = new Vector3(placeCoordinates.x, placeCoordinates.y, 0);
                    Instantiate(buildingToPlace, position, Quaternion.identity);
                    obj.transform.position = newPosition;
                } else if (bridge)
                {
                    GameObject.Find("Bridge").GetComponent<Bridge>().BuildBridge();
                }
                
              
            if (newPosition != Vector2.zero)
            {

                obj.transform.position = newPosition;

            }

            return true;
            }
    }
}
