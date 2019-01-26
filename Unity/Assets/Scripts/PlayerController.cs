using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 2.5f;
    private Transform playerLocation;

    private void Start()
    {
        playerLocation = this.GetComponent<Transform>();
    }

    private void Update()
    {
        MovePlayer();
        if (Input.GetButtonDown("Jump"))
        {
            Interact(playerLocation.TransformDirection(Vector3.forward));
        }
    }

    private void MovePlayer()
    {
        float xMovement = Input.GetAxisRaw("Horizontal") * Time.deltaTime * movementSpeed;
        float yMovement = Input.GetAxisRaw("Vertical") * Time.deltaTime * movementSpeed;

        playerLocation.position = new Vector3(playerLocation.position.x + xMovement,
                                                playerLocation.position.y + yMovement,
                                                playerLocation.position.z);
    }

    private void Interact(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(playerLocation.position, direction, 2, LayerMask.GetMask("Interactable"));
        if (hit.collider != null)
        {
            Debug.Log("Interacted with " + hit.collider.tag);
        }
    }
}
