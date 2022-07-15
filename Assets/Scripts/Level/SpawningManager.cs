using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningManager : MonoBehaviour
{
    [Header("Managers")]
    public GameDirector gameDirector;

    [Header("Spawning Prefabs")]
    public GameObject enemy;
    public GameObject shield;

    private float spawnTimer = 1.0f;
    private float timer = 0.0f;

    private GameObject player;
    private float offset = 30.0f;

    private float[] lanePositions;

    public List<GameObject> enemyPool;
    public List<GameObject> shieldPool;

    private int enemyIndex = 0;
    private int shieldIndex = 0;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lanePositions = gameDirector.LanePositions;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= spawnTimer)
        {
            SpawnObject();
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    private void SpawnObject()
    {
        GameObject objectToSpawn;
        int objectChoice = Random.Range(1, 10);

        if (objectChoice <= 8)
        {
            objectToSpawn = enemyPool[enemyIndex];
            enemyIndex++;

            if (enemyIndex >= enemyPool.Count - 1)
            {
                enemyIndex = 0;
            }
        }
        else
        {
            objectToSpawn = shieldPool[shieldIndex];
            shieldIndex++;

            if (shieldIndex >= shieldPool.Count - 1)
            {
                shieldIndex = 0;
            }
        }

        int lane = Random.Range(0, lanePositions.Length);
        objectToSpawn.transform.position = new Vector3(lanePositions[lane], 0.0f, player.transform.position.z + offset);

        //WaitAndRemoveObject(2.0f, objectToSpawn);
        

    }

    private IEnumerator WaitAndRemoveObject(float waitTime, GameObject obj)
    {
        yield return new WaitForSeconds(waitTime);
        obj.transform.position = new Vector3(-40.0f, 0.0f, 0.0f);      
    }

    public void ResetObjects()
    {
        foreach (GameObject enemy in enemyPool)
        {
            enemy.transform.position = new Vector3(enemy.transform.position.x, 0.0f, enemy.transform.position.z - gameDirector.CHECK_DIST);
        }

        foreach (GameObject shield in enemyPool)
        {
            shield.transform.position = new Vector3(shield.transform.position.x, 0.0f, shield.transform.position.z - gameDirector.CHECK_DIST);
        }
    }

    public void RestartObjects()
    {
        foreach (GameObject enemy in enemyPool)
        {
            enemy.transform.position = new Vector3(100.0f, 0.0f, enemy.transform.position.z - gameDirector.CHECK_DIST);
        }

        foreach (GameObject shield in enemyPool)
        {
            shield.transform.position = new Vector3(100.0f, 0.0f, shield.transform.position.z - gameDirector.CHECK_DIST);
        }
    }

}
