using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunUpgrade : Upgrade
{
    private void Start()
    {
        upgradeName = "shotgun";
    }

    new void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collObj = collision.gameObject;
        if (collObj.CompareTag("Player"))
        {
            Shooting playerShooting = collObj.GetComponent<Shooting>();
            playerShooting.bulletNum = 3;
            playerShooting.fireSpeed += 0.5f;
            Destroy(gameObject);
            base.OnCollisionEnter2D(collision);
        }
    }
}