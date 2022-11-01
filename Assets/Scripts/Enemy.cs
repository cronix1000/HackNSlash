using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform player;

    public float speed = 5f;

    public Transform enemy; 

    private void Start()
    {
        enemy = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Debug.Log(enemy.position.x);
    }

    private void Update()
    {
        if (player.position.x < enemy.position.x) {
            enemy.position += Vector3.left * speed * Time.deltaTime;
        }
        else
        {
            enemy.position += Vector3.right * speed * Time.deltaTime;
        }

        if (player.position.z < enemy.position.z)
        {
            enemy.position += Vector3.back * speed * Time.deltaTime;
        }
        else
        {
            enemy.position += Vector3.forward * speed * Time.deltaTime;
        }
    }
}
