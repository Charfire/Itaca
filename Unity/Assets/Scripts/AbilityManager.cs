using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    private bool hasAxe;

    // Start is called before the first frame update
    void Start()
    {
        //start out without axe
        hasAxe = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetAxe()
    {
        hasAxe = true;
    }

    public void UseAxe()
    {
        if (hasAxe)
        {

        }
    }
}
