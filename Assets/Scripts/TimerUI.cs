using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerUI : MonoBehaviour {

    TMPro.TextMeshProUGUI timer;

    private void Awake()
    {
        timer = GetComponent<TMPro.TextMeshProUGUI>();
    }

    public void UpdateTimer(float time)
    {
        int minutes = (int)(time / 60f);
        int seconds = (int)(time % 60f);

        timer.text = minutes.ToString() + ":" + seconds.ToString("00");
    }
}
