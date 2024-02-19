using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerModel model;

    [SerializeField] InputActionReference BecomeGhostInput, Hide;

    [SerializeField] Sprite sleepingPrincess, standingPrincess, hidingPrincess;
    [SerializeField] SpriteRenderer princessSprite;
    [SerializeField] GhostActions ghostActions;
    [SerializeField] GameObject ghost, princess;
    private bool canHide, toggleBool;

    void Awake(){
        BecomeGhostInput.action.performed += SwitchToGhost;
        Hide.action.performed += HidePrincess;
    }

    void OnDestroy(){
        BecomeGhostInput.action.performed -= SwitchToGhost;
        Hide.action.performed -= HidePrincess;
    }
    //on button click
   public void SwitchToGhost(InputAction.CallbackContext ctx){
    //check if I am princess n&& is cooldown over else exit
    // play transition animation
    ghostActions.ghostTimerNeeded = true;
    ghost.SetActive(true);
    princessSprite.sprite = sleepingPrincess;
    if(canHide){
        princessSprite.sortingOrder = -1;
    }

    model.iAm = "Ghost";
    playerMovement.rb = model.ghostRb;
    //start ghost timer();
   }

    //on ghost timer ends or on enter princess
    public void SwitchToPrincess(){
        //play transition animation
        //destroy ghost 
        ghost.SetActive(false);
        
        if(canHide){
            princessSprite.sprite = hidingPrincess;
        } else{
            princessSprite.sprite = standingPrincess;
        }
        model.iAm = "Princess";
        playerMovement.rb = model.princessRb;
        // start cooldown timer
    }

    //on button click
    public void Possess(){
        // check if I am princess else exit
        //check if enemy within reach(collider on their back) else exit
        //play transition animation
        model.iAm = "Enemy";
        //start possesssion timer
    }    

    public void SetCanHide(bool status){
        canHide = status;
    }

    //On button click
    public void HidePrincess(InputAction.CallbackContext ctx){
        if(canHide){
        toggleBool = !toggleBool;
        if(toggleBool){
            princessSprite.sortingOrder = -1;
            princessSprite.sprite = hidingPrincess;
            //princess.transform.position = 
        }
        else{
              princessSprite.sortingOrder = 1;
            princessSprite.sprite = standingPrincess;
        }
        playerMovement.isHiding = toggleBool;
        }
    }
}
