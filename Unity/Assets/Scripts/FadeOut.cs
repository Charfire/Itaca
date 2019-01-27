using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private GameObject fadeIn;
    private Canvas canvas;

    private void Start()
    {
        animator = GetComponent<Animator>();
        canvas = FindObjectOfType<Canvas>();
    }

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Ended"))
        {
            Instantiate(fadeIn, canvas.transform);
            Destroy(gameObject);
        }
    }
}
