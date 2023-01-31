using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsManager : MonoBehaviour {

    [SerializeField] GameObject pnlCredits;

	public void Show()
    {
        pnlCredits.SetActive(true);
    }

    public void Hide()
    {
        pnlCredits.SetActive(false);
    }
}
