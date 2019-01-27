using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public enum GameProgress { Start, Bridge, Rock, Boat };

//Use this for reference to NPCs
//public enum NonPC { Woodcutter, Hunter, Miner, Fisher, Electric };

public class ProgressManager : MonoBehaviour
{
    private int gameStage;

    private Dictionary<NonPC, int> npcCheckpoints;


    // Start is called before the first frame update
    void Start()
    {
        npcCheckpoints = new Dictionary<NonPC, int>();

        gameStage = (int)GameProgress.Start;

        ResetNPCChecks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsNPCCheckpointReached(NonPC npc, int checkpoint)
    {
        int checkValue = 0;
        
        npcCheckpoints.TryGetValue(npc, out checkValue);
        
        if (checkpoint <= checkValue)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SetNPCCheckpoint(NonPC npc, int checkpoint)
    {
        npcCheckpoints.Remove(npc);

        npcCheckpoints = new Dictionary<NonPC, int>();

        npcCheckpoints.Add(npc, checkpoint);

        Debug.Log("npc: " + npc.ToString() + " activated checkpoint " + checkpoint);
    }

    private void ResetNPCChecks()
    {

        npcCheckpoints.Clear();

        foreach (NonPC npc in Enum.GetValues(typeof(NonPC)))
        {
            npcCheckpoints.Add(npc, 0);
        }
    }

    public bool IsGameStageReached(int stageCheck)
    {
        if(stageCheck <= gameStage)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //call this when the next stage is reached (i.e. bridge is build or pickaxe is upgraded)
    public void setGameStage(GameProgress newStage)
    {
        if(gameStage < (int) newStage)
        {
            gameStage = (int)newStage;

            ResetNPCChecks();
        }
    }
}
