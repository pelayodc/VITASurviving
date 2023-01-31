using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangelogManager : MonoBehaviour {

    [SerializeField] GameObject pnlChangelog;

    public void Show()
    {
        pnlChangelog.SetActive(true);
    }

    public void Hide()
    {
        pnlChangelog.SetActive(false);
    }
}
