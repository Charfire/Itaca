using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{

    [SerializeField]
    private AudioClip audioClip;

    private int woodAmount;
    private ParticleSystem particles;

    private void Start()
    {
        woodAmount = 10;
        particles = gameObject.GetComponent<ParticleSystem>();
    }

    public void chopAtTree(int amount)
    {
        woodAmount -= amount;

        particles.Play();

        if(woodAmount <= 0)
        {
            AudioManager.audioManager.PlaySoundEffect(audioClip);
            Destroy(this.gameObject);
        }
    }
}
