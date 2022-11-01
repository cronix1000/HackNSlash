using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    Transform player;

    public float speed = 5f;

    public Transform enemy;

    private NavMeshAgent pathfinder;

    private void Start()
    {
        enemy = GetComponent<Transform>();
        pathfinder = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        //if (player.position.x < enemy.position.x) {
        //    enemy.position += Vector3.left * speed * Time.deltaTime;
        //}
        //else
        //{
        //    enemy.position += Vector3.right * speed * Time.deltaTime;
        //}

        //if (player.position.z < enemy.position.z)
        //{
        //    enemy.position += Vector3.back * speed * Time.deltaTime;
        //}
        //else
        //{
        //    enemy.position += Vector3.forward * speed * Time.deltaTime;
        //}

        pathfinder.SetDestination(player.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            
        }
    }
}
