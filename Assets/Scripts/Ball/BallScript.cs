using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 startPosition;

    private GameScript GameScript;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        rb.AddForce(new Vector2(0 , 20)* speed );
    }

    private void OnCollisionEnter2D(Collision2D other) {    
        if ( other.gameObject.tag == "Point")
        {
           // GameScript.AddScore(100);
            Destroy(other.gameObject);
            DropPowerUp();
        }
        if( other.gameObject.tag == "Respawn")
        {
            //GameScript.lives =- 1;
            transform.position = startPosition;
        }
    }

    //drops power up to make player bigger
    private void DropPowerUp() {
        Debug.Log("got here");
        GameObject cube = (GameObject)Instantiate(Resources.Load("Prefabs/Powerups/IncreaseSizePowerUp"));
        cube.AddComponent<Collider2D>();
        cube.transform.position = new Vector3(3, 3, 0);
    }
}

