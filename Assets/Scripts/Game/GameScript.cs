using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public int lives = 3;
    public int maxLives = 5;
    public int score = 0;
    public GameObject[] livesSprite;
    
    // Start is called before the first frame update
    public void Start() {
        int tempLives = lives;
        for(int i = 0 ; i < livesSprite.Length ; i ++) {
            if(tempLives > 0) {
                livesSprite[i].SetActive(true);
                tempLives --;
            } else {
                livesSprite[i].SetActive(false);
            }
        }
    }

        void Update()
    {
    }

    public void AddScore(int score)
    {
        score += score;
    }

    private void DrawLives(){

    }
    
}
