using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "NPC/Dialogue")]
public class Dialogue : ScriptableObject //ScriptableObject or Serializable?
{
    public string[] sentences;

    //The variables below will be replaced by a reference to the NPC
    public string name;
    public Sprite npcImage;
}
