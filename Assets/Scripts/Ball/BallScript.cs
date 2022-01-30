using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float speed = 3;
    private Rigidbody2D rb;
    private Vector2 moveAmount;
    private bool startBall = false;
    
    // Start is called before the first frame update
    void Start()
    {
        startBall = true;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(startBall){
            Vector2 moveInput = new Vector2(0, 0);
            moveAmount = moveInput.normalized * speed;
            if(Input.GetKeyDown(KeyCode.Space)){
                moveAmount = new Vector2(Random.value, Random.value).normalized* speed;
                startBall = false;
            }
        }
    }

    // void OnCollisionEnter2D(Collision other)
    // {
    //     Debug.Log(other + "hit item");
    //     moveAmount = new Vector2( -moveAmount.x ,  -moveAmount.y);
    // }

private void OnCollisionEnter2D(Collision2D other) {
     Debug.Log(other + "hit item");
     moveAmount = new Vector2( -moveAmount.x ,  -moveAmount.y);
}

    private void FixedUpdate() {
        Vector2 position = rb.position + moveAmount * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }
}
