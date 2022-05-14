using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public GameObject enemyPrefab;
    public Transform[] enemyPosition;
    public float spawnTime;

    float timer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnTime)
        {
            timer = 0;
            int positionRandom = Random.Range(0, enemyPosition.Length);
            Instantiate(enemyPrefab, enemyPosition[positionRandom].position, enemyPosition[positionRandom].rotation);
        }
    }
}
