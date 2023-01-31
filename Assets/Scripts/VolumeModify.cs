using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeModify : MonoBehaviour {

    [SerializeField] AudioSource audioSource;
    Slider sld;

    private void Awake()
    {
        sld = GetComponent<Slider>();
    }

    public void changeVolume()
    {
        audioSource.volume = sld.value;
    }
}
