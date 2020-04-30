using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{

    public Enemy enemy;

    void Start()
    {
        health = enemy.health;
    }

    new void Update()
    {
        if (health <= 0)
        {
            EventBus.Publish<EnemyKilledEvent>(new EnemyKilledEvent());
        }
        base.Update();
    }
}

public class EnemyKilledEvent
{
    public EnemyKilledEvent()
    {

    }
}
