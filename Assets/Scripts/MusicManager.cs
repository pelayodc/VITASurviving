using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    [SerializeField] AudioClip musicOnStart;
    AudioSource audioSource;

    [SerializeField] float timeToSwitch;
    AudioClip switchTo;
    float volume;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start () {
        Play(musicOnStart,true);
	}

	// Update is called once per frame
	public void Play(AudioClip music, bool interrupt=false) {
        if(interrupt)
        {
            audioSource.volume = 1f;
            audioSource.clip = music;
            audioSource.Play();
        } else
        {
            switchTo = music;
            StartCoroutine(SmoothSwitchMusic());
        }
	}

    IEnumerator SmoothSwitchMusic()
    {
        volume = 1f;
        while (volume > 0f)
        {
            volume -= Time.deltaTime / timeToSwitch;
            if (volume < 0f) { volume = 0f; }
            audioSource.volume = volume;
            yield return new WaitForEndOfFrame();
        }

        Play(switchTo, true);
    }

}
