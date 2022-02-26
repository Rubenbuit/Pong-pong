using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 15;
    private Rigidbody2D rb;
    private Vector2 moveAmount;  
    public float playerWidth;
    private GameScript gameScript;
    
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       playerWidth = transform.localScale.y; 
       gameScript= GetComponent<GameScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        moveAmount = moveInput.normalized * speed;

    }

    // Update on every frame
    void FixedUpdate()
    {
        Vector2 position = rb.position + moveAmount * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other) {
    if(other.gameObject.tag == "PowerUp") {
        string powerUp = other.gameObject.name;

        switch(powerUp){
            case "IncreasePlayerSize":
                ChangePlayerSize(true);
                return;
            case "DecreasePlayerSize":
                ChangePlayerSize(false);
                return;
            case "IncreasePlayerSpeed":
                ChangePlayerSpeed(true);
                return;
            case "DecreasePlayerSpeed":
                ChangePlayerSpeed(false);
                return;
            case "IncreaseBalls":
                gameScript.AddBall();
                return;
            case "IncreaseBallSpeed":
                //TODO
                return;
            case "DecreaseBallSpeed":
                //TODO
                return;    
            case "IncreaseLife":
                gameScript.IncreaseLife();
                return;
            default:
                Debug.Log("Unknown Powerup: " + other);
                return;
            }
        }
    }  
   
   private void ChangePlayerSpeed(bool increaseSpeed){
       float addedSpeed = increaseSpeed? -5: 5; // check if works/ realistic
       speed += addedSpeed;
   }

    private void ChangePlayerSize(bool makeBigger){
        if (makeBigger) {
            playerWidth += 0.2f;
        } 
        else {
            playerWidth -= 0.2f;
        }
        
        Vector3 objectScale = transform.localScale;
        playerWidth += 0.2f;
        transform.localScale = new Vector3(objectScale.x,  playerWidth, objectScale.z);
    }
}

