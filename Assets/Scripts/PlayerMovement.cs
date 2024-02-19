using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] PlayerModel player;
    [SerializeField] float speed = 100f;
    [SerializeField] InputActionReference moveInput;
    public Rigidbody2D rb;
    float xDirectionMovement;
    float yDirectionMovement;
    Vector2 directionVector;

    public bool isHiding;

void Start(){
    rb = player.princessRb;
    
}
    void Update()
    {
        
        directionVector = moveInput.action.ReadValue<Vector2>().normalized;
        if(player.iAm == "Princess"){
            directionVector.y=0;
        }
    }

    void FixedUpdate()
    {
        Move(directionVector);
    }
 
    void Move(Vector2 direction)
    {
        if(!isHiding || player.iAm == "Ghost"){
        rb.velocity = direction * speed * Time.fixedDeltaTime;
        }
    }
}