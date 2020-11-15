using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ~~~~ Script for scene-switching ~~~~

public class SwitchScene : MonoBehaviour
{

    public void mainScreen()
    {
        SceneManager.LoadScene(0);
    }


    public void startScreen()
    {
        SceneManager.LoadScene(1);
    }


    public void playGame()
    {
        SceneManager.LoadScene(2);
    }


    public void aboutScreen()
    {
        SceneManager.LoadScene(3);
    }


    public void optionsScene()
    {
        SceneManager.LoadScene(4);
    }


    public void quitGame()
    {
        Debug.Log("Quit");
        Application.Quit();     //quits the game window
    }






}
