using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetedMovement : TargetedMovement
{

    public Enemy enemy;

    new void Start()
    {
        base.Start();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        speed = enemy.speed;
    }
}
