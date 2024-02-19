using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class princess : MonoBehaviour
{
    public int keyCount;
    [SerializeField] PlayerActions playerActions;
    
   private void OnTriggerEnter2D(Collider2D collider)
   {
    if(collider.tag == "Key"){
       Destroy(collider.gameObject);
       keyCount++;
    } else if(collider.tag == "LockedDoor"){
       if( collider.GetComponent<LockedDoor>().keyId <= keyCount){
        Destroy(collider.GetComponent<LockedDoor>().doorCollider);
       }
    
    }else if(collider.tag == "Checkpoint"){
        //save checkpoint number in game manager
    }else if (collider.tag == "HidingPlace"){
            playerActions.SetCanHide(true);
            tag = "Untagged";
        }
   }
   
    private void OnTriggerExit2D(Collider2D collider){
        if (collider.tag == "HidingPlace"){
            playerActions.SetCanHide(false);
             tag = "Player";
        }
    }
}
