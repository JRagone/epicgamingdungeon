using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROFUpgrade : Upgrade
{
    new void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collObj = collision.gameObject;
        if (collObj.CompareTag("Player"))
        {
            Shooting playerShooting = collObj.GetComponent<Shooting>();
            playerShooting.fireSpeed -= 0.15f;
            Destroy(gameObject);
            base.OnCollisionEnter2D(collision);
        }
    }
}
