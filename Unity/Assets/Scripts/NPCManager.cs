using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public static NPCManager npcManager;

    [SerializeField]
    private NPC woodcutter;
    [SerializeField]
    private NPC hunter;
    [SerializeField]
    private NPC miner;
    [SerializeField]
    private NPC fisherman;
    [SerializeField]
    private NPC electrician;
    //[SerializeField]
    //private NPC pet;

    private List<NPC> allNPCs;

    private void Awake()
    {
        npcManager = this;
    }

    private void Start()
    {
        allNPCs = new List<NPC>();
        allNPCs.Add(woodcutter);
        allNPCs.Add(hunter);
        allNPCs.Add(miner);
        allNPCs.Add(fisherman);
        allNPCs.Add(electrician);
    }


}
