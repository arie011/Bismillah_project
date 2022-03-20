using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool IsGamePaused;

    [SerializeField] GameObject pauseMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame(); 
            }
        }
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        IsGamePaused = false;
    }
    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsGamePaused = true;
    }
    public void LoadMenu()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        // SceneManager.LoadScene("mainmenu");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log ("Quit");
    }
}
