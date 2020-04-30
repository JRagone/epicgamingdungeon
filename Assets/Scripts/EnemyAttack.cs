using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public Enemy enemy;

    protected float enemyDmg;

    // Start is called before the first frame update
    void Start()
    {
        enemyDmg = enemy.damage;
    }
}
