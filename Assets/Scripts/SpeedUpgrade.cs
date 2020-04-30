using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpgrade : Upgrade
{
    public float speedIncrease;

    new void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collObj = collision.gameObject;
        if (collObj.CompareTag("Player"))
        {
            Movement playerMov = collObj.GetComponent<Movement>();
            playerMov.speed += speedIncrease;
            Destroy(gameObject);
            base.OnCollisionEnter2D(collision);
        }
    }
}
