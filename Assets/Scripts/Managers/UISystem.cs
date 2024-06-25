using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UISystem : MonoBehaviour
{
    [SerializeField] private Canvas MenuGame;
    private void OnEnable()
    {
        EventManager.onReloadLevel.AddListener(ReloadLevel);
    }

    private void OnDisable()
    {
        EventManager.onReloadLevel.RemoveListener(ReloadLevel);
    }
    public void ButtonOptions()
    {
        if (MenuGame.enabled == false) 
        {
            MenuGame.enabled = true;
            Time.timeScale = 0f;
        }
    }
    //Function Game UI & Menu
    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ResumeGame()
    {
        MenuGame.enabled = false;
        Time.timeScale = 1f;
    }

    public void QuitToMenu()
    {
        PlayerPrefs.DeleteAll();
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        PlayerPrefs.DeleteAll();
        Time.timeScale = 1f;
        Application.Quit();
    }
}
