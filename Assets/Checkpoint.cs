using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
   public GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player"){
            gameManager.UpdateCheckpoint(transform.position.x);
            Debug.Log("CHECKPOINT");
        }
    }
}
