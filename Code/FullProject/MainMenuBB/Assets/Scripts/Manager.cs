using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    public int lives = 3;
	public int score = 0;
    public int bricks = 22;
	public int ballCount = 1;
    public float delay = 2f;
    public float delay2 = 1f;
	public int streak = 0;

    public Text livesLeft;
	public Text newScore;
    public GameObject brickPrefab;
    public GameObject gameOver;
    public GameObject winner;
	public Text streakCounter;
    public GameObject menuButton;
    public GameObject platform;
    public static Manager level = null;

    private GameObject newPlatform;

	// Use this for initialization
	void Start () {
        if(level == null){
            level = this;
        }
        else if(level != this){
            Destroy(gameObject);
        }

        Setup();
	}

    public void Setup(){
        newPlatform = Instantiate(platform, transform.position, Quaternion.identity) as GameObject;
        Instantiate(brickPrefab, transform.position, Quaternion.identity);
    }
    
    void isGameOver(){
        if(bricks < 1){
            winner.SetActive(true);
            Time.timeScale = 0.25f;
            Invoke("changeScale", delay2);
            Invoke("displayButton", delay2);
			Destroy(newPlatform);
            //menuButton.SetActive(true);
        }
        if(lives < 1){
            gameOver.SetActive(true);
            Time.timeScale = 0.25f;
            Invoke("changeScale", delay2);
            Invoke("displayButton", delay2);
			Destroy(newPlatform);
            //menuButton.SetActive(true);
        }
    }
	
	
	void isStreak(){
		if(streak == 10){
			extraLife();
		}
	}
	
	void doubleBall(){
		if(streak == 5){
			Destroy(newPlatform);
			setupPlatform();
			ballCount += 1;
		}
	}
	
	public void extraLife(){
		lives++;
		livesLeft.text = "L i v e s : " + lives;
	}
	
	public void fireBall(){
		if(streak == 15){
			//BallMovement.fireBallForce();
			BallMovement.isFire = true;
			//GameObject.fireBallForce();
		}
	}
	
    public void lostLife(){
		ballCount--;
		if(bricks != 0 && ballCount == 0){
        lives--;
		streak = 0;
		streakCounter.text = "S t r e a k : " + streak;
        livesLeft.text = "L i v e s : " + lives;
		}
		
		if(ballCount == 0){
			Destroy(newPlatform);
			if(lives != 0 && bricks != 0){
				Invoke("setupPlatform", delay);
				ballCount = 1;
			}
		}
        isGameOver();
    }

    void setupPlatform() {
        newPlatform = Instantiate(platform, transform.position, Quaternion.identity) as GameObject;
    }

    public void destroyBrick(){
        bricks--;
		streak++;
		streakCounter.text = "S t r e a k : " + streak;
		score = score + 10;
		newScore.text = "S c o r e : " + score;
		if(bricks < 1){
			score = score + (lives * 50);
			newScore.text = "S c o r e : " + score;
		}
        isGameOver();
		isStreak();
		doubleBall();
    }
	
	
    void changeScale()
    {
        Time.timeScale = 1f;
    }

    void displayButton()
    {
        menuButton.SetActive(true);
    }
}
