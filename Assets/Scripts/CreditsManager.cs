using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsManager : MonoBehaviour {

    [SerializeField] GameObject pnlCredits;

	public void Show()
    {
        pnlCredits.SetActive(true);
        pnlCredits.GetComponentInChildren<Button>().Select();
    }

    public void Hide()
    {
        pnlCredits.SetActive(false);
    }
}
