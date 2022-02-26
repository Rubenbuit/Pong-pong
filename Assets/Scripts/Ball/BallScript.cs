using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 startPosition;

    public GameObject[] PositivePowerUps;

    public GameObject[] NegativePowerUps;

    private GameScript GameLogic;
   
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        rb.AddForce(new Vector2(0 , 20)* speed );
        GameLogic = GameObject.Find("Player").GetComponent<GameScript>();
    }

    private void OnCollisionEnter2D(Collision2D other) {    
        if ( other.gameObject.tag == "Point") {
            GameLogic.IncreaseScore(200);
            int shouldDropPowerUp = Random.Range(0, 11 ); 
            if( shouldDropPowerUp <= 5) 
                DropPowerUp();
            Destroy(other.gameObject);
        }
        if( other.gameObject.tag == "Respawn") {
            GameLogic.DecreaseLife();
            transform.position = startPosition;
        }
    }

    //gives player 66% change of positive power up
    //TODO change to 10%
    private void DropPowerUp() {
        int shouldDropPositvePowerUp = Random.Range(0, 3 ); 
        if (shouldDropPositvePowerUp <= 1) {
            GeneratePositivePowerUp();
        }
        else {
            GenerateNegativePowerUp();
        }
    }

    private void GeneratePositivePowerUp() {
        int choosePowerUp = Random.Range(0, PositivePowerUps.Length ); 
        GameObject powerUp = (GameObject)Instantiate(PositivePowerUps[choosePowerUp]);
        powerUp.AddComponent<Rigidbody2D>();
        powerUp.transform.position = new Vector3(3, 3, 0);
    }

    private void GenerateNegativePowerUp() {
        int choosePowerUp = Random.Range(0, NegativePowerUps.Length ); 
        GameObject powerUp = (GameObject)Instantiate(NegativePowerUps[choosePowerUp]);
        powerUp.AddComponent<Rigidbody2D>();
        powerUp.transform.position = new Vector3(3, 3, 0);
    }
}
