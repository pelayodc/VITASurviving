using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour {

    [SerializeField] List<GameObject> drops;
    [SerializeField] [Range(0f, 1f)] float chance = 0.4f;

    bool isExit = false;

    private void OnApplicationQuit()
    {
        isExit = true;
    }

    public void CheckDrop()
    {
        if(isExit) { return; }

        if (Random.value < chance)
        {
            GameObject toDrop = drops[Random.Range(0, drops.Count)];
            Transform t = Instantiate(toDrop).transform;
            t.position = transform.position;
        }
    }
}
