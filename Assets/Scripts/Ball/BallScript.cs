using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveAmount;
    private bool startBall = false;
    
    // Start is called before the first frame update
    void Start()
    {
        startBall = true;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(startBall){
            if(Input.GetKeyDown(KeyCode.Space)){
                moveAmount = new Vector2(0 , 20);
                rb.AddForce(moveAmount* speed );
                startBall = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {    
        Debug.Log("Got here");
    }
}

