using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int WPIndex = 0;
    private Enemy enemy;
    void Start()
    {
        enemy = GetComponent<Enemy>();
        target = WayPointSystem.wayPointNodes[0];
    }
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.1f)
        {
            GetNextWayPoint();
        }
        enemy.speed = enemy.startSpeed;
        
    }

    private void GetNextWayPoint()
    {
        if (WPIndex >= WayPointSystem.wayPointNodes.Length-1)
        {
            PathEnded();
            return;
        }
        WPIndex++;
        target = WayPointSystem.wayPointNodes[WPIndex];
    }

    void PathEnded()
    {
        GameSystem.Lives--;
        Destroy(gameObject);
    }
}
