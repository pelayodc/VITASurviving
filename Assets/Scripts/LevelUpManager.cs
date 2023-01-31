using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpManager : MonoBehaviour {

    [SerializeField] GameObject panel;
    PauseMenu pause;

    [SerializeField] List<UpgradeButton> upgradeButtons;

    private void Awake()
    {
        pause = GetComponent<PauseMenu>();
    }

    private void Start()
    {
        HideButtons();
    }

    public void Open(List<UpgradeData> upgradeDatas)
    {
        Clean();
        pause.PauseGame();
        panel.SetActive(true);

        for (int i=0; i<upgradeDatas.Count;i++)
        {
            upgradeButtons[i].gameObject.SetActive(true);
            upgradeButtons[i].Set(upgradeDatas[i]);
        }

        GetComponent<AudioSource>().Play();
    }

    public void Clean()
    {
        for(int i=0; i<upgradeButtons.Count; i++) {
            upgradeButtons[i].Clean();
        }
    }

    public void Upgrade(int pressedButtonID)
    {
        GameManager.instance.playerTransform.GetComponent<Character>().Upgrade(pressedButtonID);
        Close();
    }

    public void Close()
    {
        HideButtons();

        pause.ResumeGame();
        panel.SetActive(false);
    }

    private void HideButtons()
    {
        for (int i = 0; i < upgradeButtons.Count; i++)
        {
            upgradeButtons[i].gameObject.SetActive(false);
        }
    }

}
