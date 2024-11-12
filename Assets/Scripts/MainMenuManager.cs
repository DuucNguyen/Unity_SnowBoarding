using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Canvas instruction;
    [SerializeField] Canvas mainMenu;
    [SerializeField] Canvas levelPanel;
    [SerializeField] Canvas aboutUsPanel;
    [SerializeField] Canvas quitPanel;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenInstruction()
    {
        instruction.enabled = true;
        levelPanel.enabled = false;
        mainMenu.enabled = false;
        aboutUsPanel.enabled = false;
        quitPanel.enabled = false;
    }

    public void BackToMainMenu()
    {
        mainMenu.enabled = true;
        levelPanel.enabled = false;
        instruction.enabled = false;
        aboutUsPanel.enabled = false;
        quitPanel.enabled = false;

    }

    public void OpenLevel()
    {
        levelPanel.enabled = true;
        instruction.enabled = false;
        mainMenu.enabled = false;
        aboutUsPanel.enabled = false;
        quitPanel.enabled = false;
    }

    public void OpenAboutUs()
    {
        aboutUsPanel.enabled = true;
        levelPanel.enabled = false;
        instruction.enabled = false;
        mainMenu.enabled = false;
        quitPanel.enabled = false;
    }

    public void OpenQuitPanel()
    {
        quitPanel.enabled = true;
        mainMenu.enabled = true;
        instruction.enabled = false;
        aboutUsPanel.enabled = false;
        levelPanel.enabled = false;
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }


    public void LoadEasy() => SceneManager.LoadScene("Level1");
    public void LoadMedium() => SceneManager.LoadScene("Level2");
    public void LoadHard() => SceneManager.LoadScene("Level3");

}
