﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroductionScene : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> cutscenes;
    private Image panel;
    private Canvas canvas;
    [SerializeField]
    private GameObject fadeIn;
    private Queue<Sprite> cutsceneQueue;
    
    private void Awake()
    {
        panel = GetComponent<Image>();
        cutsceneQueue = new Queue<Sprite>();
        canvas = FindObjectOfType<Canvas>();
        Instantiate(fadeIn, canvas.transform);
        foreach (Sprite scene in cutscenes)
        {
            cutsceneQueue.Enqueue(scene);
        }
        panel.sprite = cutsceneQueue.Dequeue();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (cutsceneQueue.Count == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            } else
            {
                panel.sprite = cutsceneQueue.Dequeue();
            }
        }
    }
}
