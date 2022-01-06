using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public float timeRemaining;
    public GameObject end_form;
    private bool timerIsRunning = false;
    public Text timeText;
    //public GameObject sell_area;
  
    private void Start() {
        // Starts the timer automatically
        timerIsRunning = true;
    }

    void Update() {
        if (timerIsRunning) {
            if (timeRemaining > 0) {
                DisplayTime(timeRemaining);
                timeRemaining -= Time.deltaTime;
            }
            else {
                timeRemaining = 0;
                timerIsRunning = false;
                Time.timeScale = 0f;
            }
        }
        else {
          //sell_area.SetActive (false);
          end_form.SetActive (true);
          this.gameObject.SetActive (false);
          GameObject.Find ("time_text").SetActive (false);
        }
    }

    void DisplayTime(float timeToDisplay) {
        //timeToDisplay += 1;

        //float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        //float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        //timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        timeText.text = string.Format("{0:00}", timeToDisplay);
    }
}