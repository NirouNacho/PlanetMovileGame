﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public void GoToGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void Restart()
    {
        //Builds the current scene that we are in
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
