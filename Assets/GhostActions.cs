using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GhostActions : MonoBehaviour
{
    [SerializeField] PlayerActions playerActions;
    private float ghostTime = 300; //in seconds
    public bool ghostTimerNeeded;
   private void OnTriggerEnter2D(Collider2D collider)
   {
    if(collider.tag == "Princess"){
        //switching animation
        playerActions.SwitchToPrincess();
    }else if(collider.tag == "PossessableObject"){
        //ghost possesses animal animation
        collider.tag = "Possessed";
    }
   }

    private void Update(){
        if(ghostTimerNeeded){
        ghostTime -= Time.deltaTime;
        if(ghostTime <=0){
            playerActions.SwitchToPrincess();
            ghostTimerNeeded = false;
        }
        }
    }
}
