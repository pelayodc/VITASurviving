using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    [SerializeField] GameObject pnlPause;
    [SerializeField] GameObject pnlVictory;
    [SerializeField] Button backBTN;

    void Update () {
        if (Input.GetButtonDown("Pause"))
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
        backBTN.Select();
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
