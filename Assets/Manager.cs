using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    float timer = 40;
    float lapTime = 40;
    float totalTime = 0;
    float score = 0;
    bool firstMarker = true;
    bool isGameOver = false;
    public GameObject button1;
    public GameObject button2;
    public Text scoreText;
    public Text timerText;
    public Text caloriesText;
    public Text gameOverScoreText;
    public GameObject gameOverCanvas; 
    public GameObject gameCanvas;

    // Use this for initialization
    void Start () {
        gameCanvas.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if(!isGameOver){
            totalTime += Time.deltaTime;
            timerText.text = "Time Left: " + (int)timer;
            if (timer <= 0)
            {
                gameOver();
            }
        }
       
	}

    public void gameOver(){
        Debug.Log("GAMEOVER");
        isGameOver = true;
        gameOverScoreText.text = "Score: "+score;

        float calories = (totalTime / 60) * 7.25f;
        calories = (float)(System.Math.Truncate((double)calories * 100.0) / 100.0);

        caloriesText.text = "Calories Burned: " + calories;
        gameOverCanvas.SetActive(true);
        gameCanvas.SetActive(false);
    }


    public void quit()
    {
        Application.Quit();
    }

    public void restart() {
        SceneManager.LoadScene("SampleScene");
    }

    public void lap1(){
        if (firstMarker && !isGameOver)
        {
            score += 10;
            scoreText.text = "Score: " + score;
            firstMarker = false;
            if (lapTime > 10)
            {
                lapTime -= 5;
                setTimer(lapTime);
            } else 
            setTimer(lapTime);
            Debug.Log("lap1: " + score);
            Debug.Log("LapTime: " + lapTime);
        }
    }

    public void lap2()
    {
        if (!firstMarker && !isGameOver)
        {
            score += 10;
            scoreText.text = "Score: " + score;
            firstMarker = true;
            if (lapTime > 10)
            {
                lapTime -= 5;
                setTimer(lapTime);
            } else 
            setTimer(lapTime);
            Debug.Log("lap2: " + score);
            Debug.Log("LapTime: " + lapTime);
        }

    }

    private void setTimer(float time){
        timer = time;
    }

}
