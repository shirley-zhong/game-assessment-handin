using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenuScreen;
    public static bool gameisPaused = false;    // pause menu is off by default
    public Transform Enemy;

    void Start()
    {
        Resume();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))   // if escape is pressed
        {
            if (gameisPaused)   // and game is paused 
            {
                Resume();   // resume
            }  
            else
            {
                Pause();    // otherwise pause game
            }
        }
    }

    void Resume()   // when not paused
    {
        pauseMenuScreen.SetActive(false);   // hide pause screen
        Time.timeScale = 1f;                
        gameisPaused = false;
    }

    void Pause()    // when paused
    {
        pauseMenuScreen.SetActive(true);    // show pause screen
        Time.timeScale = 0f;                // freeze time
        gameisPaused = true;




    }
}
