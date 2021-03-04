using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerer : MonoBehaviour
{
    public GameObject pauseScreen;
    bool isPaused = false;

    void Start()
    {
        pauseScreen.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused == true)
            {
                pauseScreen.SetActive(true);
                isPaused = false;
                Time.timeScale = 0;
            }
            else
            {
                pauseScreen.SetActive(false);
                isPaused = true;
                Time.timeScale = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }
}