using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTile : MonoBehaviour {

    [SerializeField] Vector2Int tilePosition;
    [SerializeField] List<SpawnableObject> spawnObjects;
    
	void Start () {
        GetComponentInParent<WorldScrolling>().Add(this.gameObject, tilePosition);
	}

    public void Spawn()
    {
        for(int i=0; i<spawnObjects.Count;i++)
        {
            spawnObjects[i].Spawn();
        }
    }
	
}
