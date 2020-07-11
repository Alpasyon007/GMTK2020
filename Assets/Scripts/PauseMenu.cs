using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public static bool IsPaused = false;
    [SerializeField] GameObject PauseMenuUI;
    [SerializeField] public string scene_name;
    Scene current_scene;
    GameObject player;
    private void Awake() {
        current_scene = SceneManager.GetSceneByName(scene_name);
        player = GameObject.Find("Player");
    }
    
    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (IsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume() {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    void Pause() {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void LoadMenu() {
        SceneManager.LoadScene("Main Menu");
        SceneManager.UnloadSceneAsync(current_scene);
    }

    public void  QuitGame() {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
