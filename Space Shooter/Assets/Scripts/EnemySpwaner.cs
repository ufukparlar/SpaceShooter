using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwaner : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] spawnEnemy;
    public GameObject enemy;
    public int duration;
    public GameObject player;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 3, duration);
    }



    void SpawnEnemy()
    {
        if(player == null)
        
            return;
        
        int index = Random.Range(0, spawnEnemy.Length);
        Instantiate(enemy, spawnEnemy[index].position, spawnEnemy[index].rotation);
    }
}
