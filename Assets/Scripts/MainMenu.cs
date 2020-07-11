﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    private void Start() {
        Time.timeScale = 0f; ;
    }

    public void PlayGame() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

    public void QuitGame() {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
