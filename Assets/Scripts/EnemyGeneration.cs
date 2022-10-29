using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    public GameObject enemy;
    int mobCount;
    public Transform player;
    Camera camera;
    List<GameObject> monsterCount = new List<GameObject>();
    int monsterIntCount = 0;
    int mobMax = 0;
    private void Start()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        CallDirections(0);
    }

    private void CallDirections(int level)
    {
        switch (level)
        {
            case 0:
                mobMax = 40;
                break;
            case 1:
                mobMax = 80;
                break;
            case 2:
                mobMax = 120;
                break;
            default:
                break;
        }
        while (monsterIntCount < mobMax)
        {
            SpawnGeneration(Direction.Up);
            SpawnGeneration(Direction.Down);
            SpawnGeneration(Direction.Left);
            SpawnGeneration(Direction.Right);
        }
    }

    void SpawnGeneration(Direction dir) {

       

            Debug.Log(mobMax);
            for (int i = 0; i < mobMax; i++)
            {
                float posY = 0;
                float posX = 0;
            
                switch (dir)
                {
                    case Direction.Up:
                    posY = player.transform.position.y + Random.Range(0, 10) + 8;
                    posX = Random.Range(player.transform.position.x - 8, player.transform.position.x + 8);

                        break;
                    case Direction.Down:
                    posY = player.transform.position.y - 8 + Random.Range(-10 , 0) - 8;
                    posX = Random.Range(player.transform.position.x - 8, player.transform.position.x + 8);
                        break;
                    case Direction.Left:
                        posX = player.transform.position.x - 8 + Random.Range(-10, 0) - 8 ;
                        posY = Random.Range(player.transform.position.y - 8, player.transform.position.y + 8);
                        break;
                    case Direction.Right:
                        posX = player.transform.position.x + 8 +  Random.Range(0, 10) + 8;
                        posY = Random.Range(player.transform.position.y - 8, player.transform.position.y + 8);
                        break;
                }


                GameObject monster = Instantiate(enemy, new Vector3(posX, 1, posY), Quaternion.identity) as GameObject;
                monsterCount.Add(monster);
                monsterIntCount += 1;
            
            
        }
    }
}

public enum Direction { 
    Up,
    Down,
    Left,
    Right
} 