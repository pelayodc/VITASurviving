using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    [Header("UI")]
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private Button playBTN;
    [SerializeField] private Button lngBTN;

    [Header("Languages")]
    [SerializeField] private SystemLanguage[] languages;
    private int currentLanguage = 0;

	void Start ()
    {
        CloseAllPanels();
        FindCurrentLanguageIndex();
        playBTN.Select();
    }

    void FindCurrentLanguageIndex()
    {
        for(int i = 0; i < languages.Length; i++)
        {
            if(languages[i] == MultiLanguageManager.GetCurrentLanguage())
            {
                currentLanguage = i;
                return;
            }
        }
    }

    public void CloseAllPanels()
    {
        optionsPanel.SetActive(false);
    }

    public void OpenMainMenu()
    {
        optionsPanel.SetActive(false);
        playBTN.Select();
    }

    public void OpenOptions()
    {
        optionsPanel.SetActive(true);
        lngBTN.Select();
    }

    public void ChangeLanguage()
    {
        if(languages.Length == 0) { Debug.LogWarning("You have to set some languages in MenuManager before switching them."); return; }
        currentLanguage = (currentLanguage + 1) % languages.Length;
        MultiLanguageManager.SetLanguage(languages[currentLanguage]);
    }
}
