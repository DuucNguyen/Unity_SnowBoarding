using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    private bool isPaused = false;

    [SerializeField] Canvas pauseGamePanel;

    void Update()
    {
        // Toggle pause when pressing the Escape key
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    TogglePause();
        //}
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        // Set the time scale to 0 to pause, and 1 to resume
        Time.timeScale = isPaused ? 0 : 1;

        pauseGamePanel.enabled = isPaused;

    }

    public void Pause()
    {
        TogglePause();
    }

    public void Resume()
    {
        TogglePause();

        // Deactivate your pause menu UI here
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
