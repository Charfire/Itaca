using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource backgroundAudio;
    [SerializeField]
    private AudioSource soundEffects;
    public static AudioManager audioManager;

    private void Awake()
    {
        audioManager = this;
    }

    public void PlaySoundEffect(AudioClip audioClip)
    {
        soundEffects.PlayOneShot(audioClip);
    }
}
