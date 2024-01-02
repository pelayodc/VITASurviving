using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangelogManager : MonoBehaviour {

    [SerializeField] GameObject pnlChangelog;

    public void Show()
    {
        pnlChangelog.SetActive(true);
        pnlChangelog.GetComponentInChildren<Button>().Select();
    }

    public void Hide()
    {
        pnlChangelog.SetActive(false);
    }
}
