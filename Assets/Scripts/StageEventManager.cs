using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEventManager : MonoBehaviour {

    [SerializeField] StageData stageData;
    [SerializeField] EnemiesManager enemiesManager;

    StageTime stageTime;
    int eventIndexer;

    private int count;
    private GameObject enemy;

    private void Awake()
    {
        stageTime = GetComponent<StageTime>();
    }

    private void Update()
    {
        if(eventIndexer >= stageData.stageEvents.Count) { return; }

        if(stageTime.time > stageData.stageEvents[eventIndexer].time)
        {
            switch(stageData.stageEvents[eventIndexer].eventType) {
                case EventType.endLevel:
                    FindObjectOfType<PauseMenu>().ShowEndLevel();
                    eventIndexer += 1;
                    break;
                case EventType.bossSpawn:
                    enemiesManager.SpawnMiniBoss(stageData.stageEvents[eventIndexer].enemyToSpawn);
                    eventIndexer += 1;
                    break;
                case EventType.changeEnemy:
                    enemiesManager.ChangeEnemy(stageData.stageEvents[eventIndexer].enemyToSpawn);
                    eventIndexer += 1;
                    break;
                case EventType.hordeSpawn:
                    count = stageData.stageEvents[eventIndexer].count;
                    enemy = stageData.stageEvents[eventIndexer].enemyToSpawn;
                    StartCoroutine(ToSpawn());
                    eventIndexer += 1;
                    break;
                case EventType.bossEvent:
                    Debug.Log(eventIndexer);
                    if (!stageData.stageEvents[eventIndexer].done)
                    {
                        stageData.stageEvents[eventIndexer].done = true;
                        enemiesManager.SpawnBoss(stageData.stageEvents[eventIndexer].enemyToSpawn);
                        eventIndexer += 1;
                    }
                    break;
            }

        }
    }

    IEnumerator ToSpawn()
    {
        for(int i=0; i<count;i++)
        {
            enemiesManager.SpawnEnemy(enemy);
            yield return new WaitForEndOfFrame();
        }
    }

}
