using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletUpgrade : Upgrade
{

    public GameObject newBulletPrefab;
    public float bulletForceIncrease;

    new void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collObj = collision.gameObject;
        if (collObj.CompareTag("Player"))
        {
            Shooting playerShooting = collObj.GetComponent<Shooting>();
            playerShooting.bulletPrefab = newBulletPrefab;
            playerShooting.bulletForce += bulletForceIncrease;
            Destroy(gameObject);
            base.OnCollisionEnter2D(collision);
        }
    }
}
