using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMessage : MonoBehaviour {

    [SerializeField] float timeLength = 1f;
    float ttl = 1f;

    private void OnEnable()
    {
        ttl = timeLength;
    }

    void Update () {
        ttl -= Time.deltaTime;
        if(ttl < 0f)
        {
            gameObject.SetActive(false);
        }
	}
}
