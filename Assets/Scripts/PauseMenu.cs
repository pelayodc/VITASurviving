using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    [SerializeField] GameObject pnlPause;
    [SerializeField] GameObject pnlVictory;

    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(pnlPause.activeInHierarchy)
            {
                CloseMenu();
                ResumeGame();
            } else
            {
                OpenMenu();
                PauseGame();
            }
        }
	}

    public void pause()
    {
        OpenMenu();
        PauseGame();
    }

    public void resume()
    {
        CloseMenu();
        ResumeGame();
    }

    public void CloseMenu()
    {
        pnlPause.SetActive(false);
    }

    public void OpenMenu()
    {
        pnlPause.SetActive(true);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    public void ShowEndLevel()
    {
        PauseGame();
        pnlVictory.SetActive(true);
    }
}
