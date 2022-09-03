using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    #region Button Pause
    public GameObject pauseMenu;
    public GameObject buttonPause;

    public void PauseMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void PauseButton()
    {
        buttonPause.SetActive(false);
    }

    public void PauseContinue()
    {
        Time.timeScale = 1f;
        buttonPause.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void PauseQuit()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    #endregion

    #region Button Death

    public void DeathRestart()
    {
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1f;
    }

    public void DeathMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    #endregion

    #region Button MainMenu

    public void MenuPlay()
    {
        SceneManager.LoadScene("Level 1");
    }

    public GameObject OptionMenu;
    public void MenuOption()
    {
        OptionMenu.SetActive(true);
    }

    public void MenuOptionClose()
    {
        OptionMenu.SetActive(false);
    }

    public void MenuQuit()
    {
        Application.Quit();
    }

    #endregion




}