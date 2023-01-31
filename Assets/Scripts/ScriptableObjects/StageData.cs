using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventType
{
    endLevel,
    hordeSpawn,
    bossSpawn,
    changeEnemy
}

[Serializable]
public class StageEvent
{
    public EventType eventType;
    public float time;
    public GameObject enemyToSpawn;
    public int count;
}

[CreateAssetMenu]
public class StageData : ScriptableObject {

    public List<StageEvent> stageEvents;
}
