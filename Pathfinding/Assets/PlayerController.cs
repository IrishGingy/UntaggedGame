using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool enteringLayer;
    
    Dictionary<string, string> scenes = new Dictionary<string, string> { ["Station"] = "TP Bagging", ["Bed"] = "SP Pasture", ["Door"] = "TP Outside", ["Inside"] = "TP House", ["Kickarounds"] = "TP Kickarounds", ["Cave01"] = "SP Cave01", ["InsideCave"] = "SP InsideCave" };

    [SerializeField] string sceneToLoad;
    [SerializeField] List<Sprite> beforeSprites;
    [SerializeField] List<Sprite> afterSprites;

    bool walkingDown;
    //FoodManager foodManager;
    bool canPickUpFood;
    GameObject foodToPickUp;

    Rigidbody2D rb;
    float inputHorizontal;
    float inputVertical;
    bool isFlipped;
    public float playerSpeed = 50f;

    // Player animation states
    Animator anim;
    string currentState;
    const string IDLE_LEFT = "PlayerIdleLeft";
    const string IDLE_RIGHT = "PlayerIdleRight";
    const string WALK_LEFT = "PlayerLeft";
    const string WALK_RIGHT = "PlayerRight";
    const string WALK_DOWN = "PlayerDown";
    const string WALK_UP = "PlayerUp";

    private void Awake()
    { 
        //base.Awake();
        //playerControls.Player.Enable();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //foodManager = FindObjectOfType<FoodManager>();
    }

    private void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
        /*if (playerControls.Player.Interact.WasPerformedThisFrame())
        {
            if (sceneToLoad != "")
            {
                manager.Load(sceneToLoad);
                sceneToLoad = "";
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            walkingDown = true;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            walkingDown = false;
        }*/

        /*if (canPickUpFood && Input.GetKeyDown(KeyCode.E))
        {
            foodManager.IncreaseAmountOfFood();
            Debug.Log($"Amount of food: {foodManager.foodPickedUp}");
            canPickUpFood = false;
            Destroy(foodToPickUp);
        }*/
    }

    private void FixedUpdate()
    {
        Vector3 moveDir = new Vector3(inputHorizontal, inputVertical).normalized;
        transform.position += moveDir * playerSpeed * Time.deltaTime;

        // up and down movements have precendence if you are pressing both keys

        // moving down
        if (moveDir.y < 0f && moveDir.x < 0f || moveDir.y < 0f && moveDir.x > 0f)
        {
            //ChangeAnimationState(WALK_DOWN);
            Debug.Log("OVERRIDE Down");
        }
        // moving up
        else if (moveDir.y > 0f && moveDir.x > 0f || moveDir.y > 0f && moveDir.x < 0f)
        {
            //ChangeAnimationState(WALK_UP);
            Debug.Log("OVERRIDE Up");
        }

        if (moveDir.y < 0f)
        {
            Debug.Log("Walking down...");
        }
        else if (moveDir.y > 0f)
        {
            Debug.Log("Walking up...");
        }

        // moving left
        if (moveDir.x < 0f)
        {
            ChangeAnimationState(WALK_LEFT);
        }
        // moving right
        else if (moveDir.x > 0f)
        {
            ChangeAnimationState(WALK_RIGHT);
        }
        
        // not moving
        if (moveDir.x == 0f && moveDir.y == 0f && currentState == WALK_LEFT)
        {
            ChangeAnimationState(IDLE_LEFT);
        }
        else if (moveDir.x == 0f && moveDir.y == 0f && currentState == WALK_RIGHT)
        {
            ChangeAnimationState(IDLE_RIGHT);
        }

        /*if ((inputHorizontal < 0 || inputHorizontal > 0) || (inputVertical > 0) || (inputVertical < 0))
        {
            // Flip player
            if (inputHorizontal > 0 && isFlipped)
            {
                FlipPlayer();
            }
            else if (inputHorizontal < 0 && !isFlipped)
            {
                FlipPlayer();
            }

            rb.AddForce(new Vector2(inputHorizontal * playerSpeed * Time.deltaTime, inputVertical * playerSpeed * Time.deltaTime).normalized, ForceMode2D.Impulse);
        }*/
        /*Vector2 inputVector = playerControls.Player.Movement.ReadValue<Vector2>();
        rb.velocity = new Vector2(inputVector.x, inputVector.y).normalized * walkSpeed;*/

        /*if (walkingDown)
        {
            anim.SetBool("walkingDown", true);
        }
        if (!walkingDown)
        {
            anim.SetBool("walkingDown", false);
        }*/
    }

    void FlipPlayer()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Ignores own circle trigger collider
        if (!collision.CompareTag("Player"))
        {
            if (collision.transform.parent && collision.transform.parent.CompareTag("Interactable"))
            {
                string tag = collision.transform.tag;
                switch (collision.transform.tag)
                {
                    case "Station":
                    case "Bed":
                    case "Door":
                    case "Cave01":
                    case "InsideCave":
                    case "Inside":
                    case "Kickarounds":
                        // Scene transition tags
                        sceneToLoad = scenes[tag];
                        break;
                    case "OtherStation":
                        Debug.Log("This is not your station.");
                        break;
                    case "Food":
                        // Pickup tags
                        Debug.Log("You found food! Show UI element");
                        collision.transform.GetComponent<SpriteRenderer>().sprite = afterSprites[0];
                        foodToPickUp = collision.gameObject;
                        canPickUpFood = true;
                        break;
                    default:
                        Debug.LogWarning($"The tag {tag} doesn't exist in the tag switch statment!");
                        break;
                }
            }
        }

        /*if (collision.transform.parent.CompareTag("Station") || collision.transform.parent.CompareTag("Bed") 
            || collision.transform.parent.CompareTag("Door") || collision.transform.parent.CompareTag("Cave01")
            || collision.transform.parent.CompareTag("Inside") || collision.transform.parent.CompareTag("Kickarounds"))
        {
            sceneToLoad = scenes[collision.transform.parent.tag];
        }
        else if (collision.transform.parent.CompareTag("OtherStation"))
        {
            Debug.Log("This is not your station.");
        }*/
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.parent)
        {
            if (collision.transform.parent.CompareTag("Interactable"))
            {
                sceneToLoad = "";
            }
            if (collision.transform.CompareTag("Food"))
            {
                collision.transform.GetComponent<SpriteRenderer>().sprite = beforeSprites[0];
                canPickUpFood = false;
            }
        }
    }

    private void ChangeAnimationState(string newState)
    {
        // Don't overwrite state if it's already playing the correct animation.
        if (newState == currentState)
        {
            return;
        }

        anim.Play(newState);

        currentState = newState;
    }

    bool IsAnimationPlaying(string stateName)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(stateName) &&
            anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}