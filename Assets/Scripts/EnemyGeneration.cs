using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    public GameObject enemy;
    int mobCount;
    Transform player;
    Camera camera;

    private void Start()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        SpawnGeneration(0);
    }

    void SpawnGeneration(int level) { 
        List<GameObject> monsterCount = new List<GameObject>();
        int mobMax = 0;
        switch (level)
        {
            case 0:
                mobMax = 10;
                break;
            case 1:
                mobMax = 20;
                break;
            case 2:
                mobMax = 30;
                break;
            default:
                break;
        }
        while (monsterCount.Count < mobMax) {
            for (int i = 0; i < mobMax; i++)
            {
                GameObject monster = Instantiate(enemy, new Vector3(camera.orthographicSize + 5, camera.orthographicSize + 5, 0f), Quaternion.identity) as GameObject;
                monsterCount.Add(monster);
            }
        }
    }
}
