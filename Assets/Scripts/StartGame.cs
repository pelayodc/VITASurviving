using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    [SerializeField] Toggle tgl;

    private void Awake()
    {
        Time.timeScale = 1f; // to fix time scale bug
    }

    public void StartGameAction()
    {
        if(tgl.isOn)
        {
            QualitySettings.vSyncCount = 2;
        } else
        {
            QualitySettings.vSyncCount = 1;
        }

        SceneManager.LoadScene("Essential", LoadSceneMode.Single);
        SceneManager.LoadScene("GameScene", LoadSceneMode.Additive);
    }
}
