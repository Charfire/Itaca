using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResManager : MonoBehaviour
{

    private int foodAmount;
    private int woodAmount;
    private int stoneAmount;

    [SerializeField] private GameObject foodObject;
    private TextMeshProUGUI foodText;

    [SerializeField] private GameObject woodObject;
    private TextMeshProUGUI woodText;

    [SerializeField] private GameObject stoneObject;
    private TextMeshProUGUI stoneText;

    // Start is called before the first frame update
    void Start()
    {
        foodText = foodObject.GetComponent<TextMeshProUGUI>();
        woodText = woodObject.GetComponent<TextMeshProUGUI>();
        stoneText = stoneObject.GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        foodText.text = foodAmount.ToString();
        woodText.text = woodAmount.ToString();
        stoneText.text = stoneAmount.ToString();
    }

    public int food
    {
        get
        {
            return this.foodAmount;
        }

        set
        {
            this.foodAmount += value;
        }
    }

    public int wood
    {
        get
        {
            return this.woodAmount;
        }

        set
        {
            this.woodAmount += value;
        }
    }

    public int stone
    {
        get
        {
            return this.stoneAmount;
        }

        set
        {
            this.stoneAmount += value;
        }
    }
}
