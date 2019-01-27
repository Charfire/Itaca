using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public enum Resource { Wood, Stone};

public class ResManager : MonoBehaviour
{

    private Dictionary<Resource, int> resources;
    private Dictionary<Resource, TextMeshProUGUI> resourceTexts;

    [SerializeField]
    private TextMeshProUGUI woodText;
    [SerializeField]
    private TextMeshProUGUI stoneText;

    

    public static ResManager resourceManager;

    private void Awake()
    {
        resourceManager = this;
    }

    private void Start()
    {
        resources = new Dictionary<Resource, int>();
        resourceTexts = new Dictionary<Resource, TextMeshProUGUI>();
        foreach (Resource resource in Enum.GetValues(typeof(Resource)))
        {
            resources.Add(resource, 0);
        }

        resourceTexts.Add(Resource.Stone, stoneText);
        resourceTexts.Add(Resource.Wood, woodText);
        
    }

    void Update()
    {
        UpdateResourceTexts();
    }

    public int GetResourceAmount(Resource resource)
    {
        return resources[resource];
    }

    public void AddResourceAmount(Resource resource, int value)
    {
        resources[resource] += value;
    }

    public void UpdateResourceTexts()
    {
        foreach (KeyValuePair<Resource, int> kvp in resources)
        {
            resourceTexts[kvp.Key].text = kvp.Value.ToString();
        }
    }

    public void AddTool(String tool)
    {
        GameObject.Find(tool + " graphic").GetComponent<Image>().enabled = true;
    }
}
