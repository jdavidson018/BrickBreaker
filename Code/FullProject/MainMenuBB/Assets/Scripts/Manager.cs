using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    public int lives = 3;
    public int bricks = 22;
    public float delay = 2f;
    public float delay2 = 1f;

    public Text livesLeft;
    public GameObject brickPrefab;
    public GameObject gameOver;
    public GameObject winner;
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
            //menuButton.SetActive(true);
        }
        if(lives < 1){
            gameOver.SetActive(true);
            Time.timeScale = 0.25f;
            Invoke("changeScale", delay2);
            Invoke("displayButton", delay2);
            //menuButton.SetActive(true);
        }
    }
	
    public void lostLife(){
        lives--;
        livesLeft.text = "Lives : " + lives;
        Destroy(newPlatform);
        Invoke("setupPlatform", delay);
        isGameOver();
    }

    void setupPlatform() {
        newPlatform = Instantiate(platform, transform.position, Quaternion.identity) as GameObject;
    }

    public void destroyBrick(){
        bricks--;
        isGameOver();
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
