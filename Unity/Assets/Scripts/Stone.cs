using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    private int stoneAmount;
    //private ParticleSystem particles;
    
    void Start()
    {
        stoneAmount = 5;
        //particles = gameObject.GetComponent<ParticleSystem>();
    }


    public void pickStone(int amount)
    {
        stoneAmount -= amount;

        //particles.Play();

        if (stoneAmount <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
