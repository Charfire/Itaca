using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 2.5f;
    private Transform playerLocation;
    
    void Start()
    {
        playerLocation = this.GetComponent<Transform>();
    }

    void Update()
    {
        float xMovement = Input.GetAxisRaw("Horizontal") * Time.deltaTime * movementSpeed;
        float yMovement = Input.GetAxisRaw("Vertical") * Time.deltaTime * movementSpeed;

        playerLocation.position = new Vector3(  playerLocation.position.x + xMovement,
                                                playerLocation.position.y + yMovement,
                                                playerLocation.position.z);
    }
}
