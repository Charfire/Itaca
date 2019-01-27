using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 2.5f;
    [SerializeField]
    private float interactionReach = 2f;
    private Transform playerLocation;

    //abilities
    private bool hasAxe;
    [SerializeField]
    private bool hasPickaxe;

    //resource manager
    [SerializeField]
    private ResManager resources;

    public event Action<RaycastHit2D> PlayerInteraction;

    //Animation
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Dialogue chopWoodDialogue;
    [SerializeField]
    private Dialogue mineStoneDialogue;
    [SerializeField]
    private Sprite dialogueImage;

    private void Start()
    {
        playerLocation = this.GetComponent<Transform>();

    }

    private void Update()
    {
        if (DialogueManager.dialogueManager.inConversation)
        {
            return;
        }

        MovePlayer();

        if (Input.GetButtonDown("Jump"))
        {
            Interact(playerLocation.TransformDirection(Vector3.up));
        }
    }

    private void LateUpdate()
    {
        //animation
        animator.SetFloat("Speed_hor", Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("Speed_ver", Input.GetAxisRaw("Vertical"));
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
        RaycastHit2D hit = Physics2D.Raycast(playerLocation.position, direction, interactionReach, LayerMask.GetMask("Interactable"));
        if (hit.collider != null)
        {
            Debug.Log("Found " + hit.collider.tag);
            if(PlayerInteraction != null)
            {
                PlayerInteraction(hit);
            }

            if (hit.collider.tag == "Wood")
            {
                UseAxe(hit.collider.gameObject);
            }
            
            if (hit.collider.tag == "Stone")
            {
                UsePickaxe(hit.collider.gameObject);
            }

            if (hit.collider.gameObject.name == "Axe")
            {
                GainAbility("Axe");
                hit.collider.gameObject.SetActive(false);
            }
        }
    }




    //abilities
    private void UseAxe(GameObject go)
    {
        if (hasAxe)
        {
            ResManager.resourceManager.AddResourceAmount(Resource.Wood, 1);
            go.GetComponent<Tree>().chopAtTree(1);

        }
        else
        {
            DialogueManager.dialogueManager.StartConversation(chopWoodDialogue, dialogueImage, name, gameObject);
        }

    }

    private void UsePickaxe(GameObject go)
    {
        if (hasPickaxe)
        {
            ResManager.resourceManager.AddResourceAmount(Resource.Stone , 1);
            go.GetComponent<Stone>().pickStone(1);

        }
        else
        {
            DialogueManager.dialogueManager.StartConversation(mineStoneDialogue, dialogueImage, name, gameObject);
        }

    }

    //Dialogues can call to this to unlock abilities
    //Doesn't really need to be public atm, but is in anticipation of extra functions
    public void GainAbility(string ability)
    {
        if (ability == "Axe")
        {
            hasAxe = true;
        }
        if (ability == "Pickaxe")
        {
            hasPickaxe = true;
        }

    }
}
