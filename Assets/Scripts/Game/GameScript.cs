using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public int lives;
    public int score;
    public GameObject livesSprite;

    public void Start() {
      DrawLives();
    }

    public void IncreaseScore(int score) {
        score += score;
        DrawScore();
    }

    public void DecreaseLives() {
        lives =-1;
        DrawLives();
    }

    public void IncreaseLives() {
        lives =+1;
        DrawLives();
    }

    private void DrawLives() {
        Vector3 position = livesSprite.transform.position;
        for(int i = 0; i < lives; i++) {
            GameObject life = (GameObject)Instantiate(livesSprite);
            life.transform.position = new Vector3(position.x, position.y, position.z);
            position.x += 0.32f;
        }
    }

    private void DrawScore(){
        //TODO draw score on text in screen
    }
}
