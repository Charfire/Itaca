using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    private int woodAmount;

    private void Start()
    {
        woodAmount = 10;
    }

    public void chopAtTree(int amount)
    {
        woodAmount -= amount;
        if(woodAmount <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
