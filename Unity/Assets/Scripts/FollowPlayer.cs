using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform cameraLocation;
    void Start()
    {
        cameraLocation = this.GetComponent<Transform>();
    }

    void LateUpdate()
    {
        Transform player = GameObject.FindWithTag("Player").transform;
        Follow(player);
    }

    private void Follow(Transform player)
    {
        Vector3 newLocation = new Vector3(player.position.x,
                                            player.position.y,
                                            cameraLocation.position.z);
        this.transform.position = newLocation;
    }
}
