using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    private BoxCollider2D wall;
    private GameObject graphic;
    public bool test = false;

    private void Start()
    {
        wall = this.GetComponent<BoxCollider2D>();
        graphic = this.transform.GetChild(0).gameObject;
    }

    private void BuildBridge()
    {
        if (!graphic.activeInHierarchy)
        {
            graphic.SetActive(true);
            Destroy(wall);
        }
    }
}
