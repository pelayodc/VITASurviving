using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGameOver : MonoBehaviour {

    public GameObject gameOverPanel;
    [SerializeField] GameObject weaponParent;

	public void GameOver()
    {
        GetComponent<PlayerMove>().enabled = false;
        gameOverPanel.SetActive(true);
        weaponParent.SetActive(false);
        Time.timeScale = 0f; //Temporal solution
    }
}
