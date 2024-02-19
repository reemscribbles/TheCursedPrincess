using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//responsible for getting the guard to pace from point A to point B, 
//detecting possessed objects and catching the princess.
public class GuardController : MonoBehaviour
{
    [SerializeField]  float direction ;
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer guardSprite;

    public static event Action OnCaught;
    private bool isScared;
    void FixedUpdate()
        {
            Move(direction);
        }
    
        void Move(float direction)
        {
            rb.velocity = new Vector2(direction,0) * speed * Time.fixedDeltaTime;
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            if(collider.tag == "Right" && !isScared){
                direction = 1;
                guardSprite.flipX = true;
            }else if(collider.tag == "Left" && !isScared){
                direction = -1;
                guardSprite.flipX = false;
            }else if(collider.tag == "Player"){
                OnCaught?.Invoke();
            }else if(collider.tag == "SafeSpot"){
                direction = 0;
            }
        }

        void OnTriggerStay2D(Collider2D collider){
            if(collider.tag == "Possessed"){
            isScared = true;
            direction = -1;
            }
        }

        void ScaredCoolDown(){

        }
}