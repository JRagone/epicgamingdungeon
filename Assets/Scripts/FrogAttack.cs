using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogAttack : EnemyAttack
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().Damage(enemyDmg);
        }    
    }
}
