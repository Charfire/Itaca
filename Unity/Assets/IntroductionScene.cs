using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroductionScene : MonoBehaviour
{
    private List<Sprite> cutscenes;
    private Image panel;
    private Canvas canvas;
    private GameObject fadeIn;

    // Start is called before the first frame update
    void Start()
    {
        canvas = FindObjectOfType<Canvas>();
        Instantiate(fadeIn, canvas.transform);
    }

}
