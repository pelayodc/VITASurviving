using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTime : MonoBehaviour {

    public float time;
    TimerUI timerUI;

    private void Awake()
    {
        timerUI = FindObjectOfType<TimerUI>();
    }

    void Update () {
        time += Time.deltaTime;
        timerUI.UpdateTimer(time);
	}
}
