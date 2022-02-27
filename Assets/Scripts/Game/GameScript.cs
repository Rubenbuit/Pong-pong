using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public int lives;
    public int score;
    public GameObject LivesSprite;
    public int ballsInGame;
    private List<GameObject> LivesObjects = new List<GameObject>();
    public void Start() {
        DrawLives();
    }

    public void IncreaseScore(int score) {
        score += score;
        DrawScore();
    }

    public void AddBall() {
      //  GameObject cube = (GameObject)Instantiate(Resources.Load("Prefabs/Ball"));
        // GameObject powerUp = (GameObject)Instantiate(Ball);
        
        //add new ball in scene
    }
    
    public void DecreaseLife() {
        lives -= 1;
        ClearLives();
        CheckAlive();
        DrawLives();
        
    }

    public void IncreaseLife() {
        lives += 1;
        DrawLives();
    }

    private void CheckAlive() {
        if(lives == 0 ){
            Destroy(LivesSprite.gameObject);
            Debug.Log("you died");
        }
    }

    private void ClearLives() {
      for(int i = 0; i < LivesObjects.Count; i++) {
           Destroy(LivesObjects[i].gameObject); 
        }   
    }

    private void DrawLives() {
        Vector3 position = LivesSprite.transform.position;
        for(int i = 1; i < lives; i++) {
            GameObject life = (GameObject)Instantiate(LivesSprite);
            LivesObjects.Add(life);
            position.x += 0.32f;
            life.transform.position = new Vector3(position.x, position.y, position.z);
        }
    }

    private void DrawScore(){
        //TODO draw score on text in screen
    }
}
