using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] PlayerScore playerScore;
    [SerializeField] GameObject player;

    [SerializeField] Canvas gameOverPanel;
    [SerializeField] TextMeshProUGUI gameOverResult; // win/ game over
    [SerializeField] TextMeshProUGUI gameOverScore;
    [SerializeField] TextMeshProUGUI gameOverHint;



    [SerializeField] Canvas levelPanel;


    [SerializeField] TextMeshProUGUI gameHUDTrickRequired;
    [SerializeField] TextMeshProUGUI gameHUDTrick;
    [SerializeField] TextMeshProUGUI gameHUDSnowFlake;

    [SerializeField] AudioClip theme;
    [SerializeField] AudioClip gameOverSound;
    [SerializeField] AudioClip gameWinSound;

    [SerializeField] float delayTime = 1f;




    AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.volume = 0.5f;
        audioSource.PlayOneShot(theme);
        
        gameHUDTrickRequired.text = 10.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        LoadGameOver();
    }

    void LoadGameOver()
    {
        if (player == null) return;
        gameOverScore.text = player.GetComponent<PlayerScore>().GetScore().ToString();
        gameHUDTrickRequired.text = (Mathf.Clamp(10 - player.GetComponent<PlayerController>().trickCount, 0, 10)).ToString();
        gameHUDTrick.text = player.GetComponent<PlayerController>().trickCount.ToString();
        gameHUDSnowFlake.text = player.GetComponent<PlayerScore>().snowFlake.ToString();

        var isPassed = false;
        gameOverHint.text = string.Empty;

        var scene = SceneManager.GetActiveScene().name;

        if (player.GetComponent<CrashDetector>().hasCrashed)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(gameOverSound);
            Invoke("DisplayMenuPanel", delayTime);
        }

        if(player.transform.position.y <= 0)
        {
            GameOver();
        }

        switch (scene){
            case "Level1":
                {
                    isPassed = player.GetComponent<PlayerController>().trickCount >= 10;
                    break;
                }
            case "Level2":
                {
                    isPassed = player.GetComponent<PlayerController>().trickCount >= 10;
                    break;
                }
            case "Level3":
                {
                    isPassed = player.GetComponent<PlayerController>().trickCount >= 10;
                    break;
                }
        }
        if (!isPassed) gameOverHint.text = "Do some more trick !!!";

        if (playerScore.GetScore() >= 3000 && gameOverPanel.enabled && isPassed)
        {
            GameWin();
        }

        if (gameOverPanel.enabled && playerScore.GetScore() < 3000 && !isPassed)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(gameOverSound);
        gameOverResult.text = "Game Over !!!";
        gameOverResult.color = Color.red;
        Destroy(player);
    }

    private void GameWin()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(gameWinSound);
        gameOverResult.text = "You won !!!";
        gameOverResult.color = Color.yellow;
        Destroy(player);
    }

    private void DisplayMenuPanel()
    {
        gameOverPanel.enabled = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenu()
    {
        //loadMainMenu scene
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenGameLevel()
    {
        gameOverPanel.enabled = true;
        levelPanel.enabled = true;
    }

    public void BackToMainMenu()
    {
        levelPanel.enabled = false ;
        gameOverPanel.enabled = true;
    }

    public void LoadEasy() => SceneManager.LoadScene("Level1");
    public void LoadMedium() => SceneManager.LoadScene("Level2");
    public void LoadHard() => SceneManager.LoadScene("Level3");
}
