using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "NPC/Dialogue/Ending/Building Success")]
public class BuildingSuccessEnding : BuildingEnding
{
    public override bool EndDialogue()
    {
        Vector3 position = new Vector3(placeCoordinates.x, placeCoordinates.y, 0);
        Instantiate(buildingToPlace, position, Quaternion.identity);
        return true;
    }
}
