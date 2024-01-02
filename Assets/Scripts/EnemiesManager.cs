using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour {

    [SerializeField] GameObject enemy;
    [SerializeField] Vector2 spawnArea;
    [SerializeField] float spawnTimer = 1f;
    Transform player;
    BossBarController bc;
    [SerializeField] int enemyLimit = 100;
    float timer;

    private void Start()
    {
        player = GameManager.instance.playerTransform;
        bc = GameManager.instance.bossBar;
    }

    //Continiusly spawning enemies? and use events for bigger spawns
    private void Update()
    {
        if (transform.childCount >= enemyLimit) { return; }

        timer -= Time.deltaTime;
        if(timer < 0f)
        {
            SpawnEnemy(enemy);
            timer = spawnTimer;
        }
    }

    public void ChangeEnemy(GameObject e)
    {
        enemy = e;
    }

    public void SpawnEnemy(GameObject e)
    {
        Vector3 position = GenerateRandomPosition();

        position += player.transform.position;

        GameObject newEnemy = Instantiate(e);
        newEnemy.transform.position = position;
        newEnemy.GetComponent<Enemy>().SetTarget(player);
        newEnemy.GetComponent<Enemy>().hp += player.GetComponent<Character>().getLevel();
        newEnemy.transform.parent = transform;
    }

    private Vector3 GenerateRandomPosition()
    {
        Vector3 pos = new Vector3();

        float f = Random.value > 0.5f ? -1f : 1f;
        if(Random.value > 0.5f)
        {
            pos.x = Random.Range(-spawnArea.x, spawnArea.x);
            pos.y = spawnArea.y * f;
        } else
        {
            pos.y = Random.Range(-spawnArea.y, spawnArea.y);
            pos.x = spawnArea.x * f;
        }

        pos.z = 0;
        return pos;
    }

    public void SpawnBoss(GameObject e)
    {
        Vector3 position = GenerateRandomPosition();

        position += player.transform.position;

        GameObject newEnemy = Instantiate(e);
        newEnemy.transform.position = position;
        newEnemy.GetComponent<Enemy>().SetTarget(player);
        newEnemy.GetComponent<Enemy>().hp = 2500;
        newEnemy.GetComponent<SpriteRenderer>().color = Color.red;
        newEnemy.transform.parent = transform;
        newEnemy.transform.localScale = new Vector3(4, 4, 4);
        newEnemy.GetComponent<Enemy>().SetAsBoss(bc);
    }

    public void SpawnMiniBoss(GameObject e)
    {
        Vector3 position = GenerateRandomPosition();

        position += player.transform.position;

        GameObject newEnemy = Instantiate(e);
        newEnemy.transform.position = position;
        newEnemy.GetComponent<Enemy>().SetTarget(player);
        newEnemy.GetComponent<Enemy>().hp = 200;
        newEnemy.GetComponent<SpriteRenderer>().color = Color.red;
        newEnemy.transform.parent = transform;
    }
}
