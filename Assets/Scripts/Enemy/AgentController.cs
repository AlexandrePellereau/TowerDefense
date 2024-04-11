using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Enemy))]
public class AgentController : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Enemy _enemy;
    
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _enemy = GetComponent<Enemy>();
        
        _agent.destination = Waypoints.points[^1].position;
        _agent.speed = GetComponent<Enemy>().speed;
    }
    
    //reach the end of the path
    private void Update()
    {
        _agent.speed = _enemy.speed;
        
        if (!(_agent.remainingDistance <= 0.4f)) return;
        
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
