using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    private BoxCollider2D wall;
    private GameObject graphic;
    private GameObject collider1;
    private GameObject collider2;
    public bool test = false;

    private void Start()
    {
        wall = this.GetComponent<BoxCollider2D>();
        graphic = this.transform.GetChild(0).gameObject;
        collider1 = this.transform.GetChild(1).gameObject;
        collider2 = this.transform.GetChild(2).gameObject;
    }

    public void BuildBridge()
    {
        if (!graphic.activeInHierarchy)
        {
            graphic.SetActive(true);
            collider1.SetActive(true);
            collider2.SetActive(true);
            Destroy(wall);
        }
    }
}
