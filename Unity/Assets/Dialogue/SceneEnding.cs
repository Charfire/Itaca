using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "NPC/Dialogue/Ending/Scene Ending")]
public class SceneEnding : DialogueEnding
{
    public int newScene;

    public override bool EndDialogue(GameObject obj)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        return true;
    }
}
