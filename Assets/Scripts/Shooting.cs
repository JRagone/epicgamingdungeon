using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public Camera cam;
    public float fireSpeed;

    public float bulletForce = 20f;
    public int bulletNum = 1;

    Rigidbody2D rb2d;
    private float elapsed_time;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 cursorDir = Vector2.right * Input.GetAxis("RHorizontal") + Vector2.up * -Input.GetAxis("RVertical");
        if(cursorDir.sqrMagnitude > 0.0f)
        {
            Shoot(cursorDir);
        }
        elapsed_time += Time.deltaTime;
        
    }

    void Shoot(Vector2 fireDir)
    {
        if (elapsed_time > fireSpeed)
        {
            elapsed_time = 0;
            float angle = Mathf.Atan2(fireDir.y, fireDir.x) * Mathf.Rad2Deg - 90f;
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D bull_rb2d = bullet.GetComponent<Rigidbody2D>();
            Transform bull_trans = bullet.GetComponent<Transform>();
            bull_trans.eulerAngles = new Vector3(bull_trans.eulerAngles.x, bull_trans.eulerAngles.y, angle);
            bull_rb2d.AddForce(bull_trans.up.normalized * bulletForce, ForceMode2D.Impulse);
            if (bulletNum == 3)
            {
                GameObject bullet2 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                GameObject bullet3 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D bull_rb2d2 = bullet2.GetComponent<Rigidbody2D>();
                Rigidbody2D bull_rb2d3 = bullet3.GetComponent<Rigidbody2D>();
                Transform bull_trans2 = bullet2.GetComponent<Transform>();
                Transform bull_trans3 = bullet3.GetComponent<Transform>();
                bull_trans2.eulerAngles = new Vector3(bull_trans2.eulerAngles.x, bull_trans2.eulerAngles.y, angle + 20f);
                bull_trans3.eulerAngles = new Vector3(bull_trans3.eulerAngles.x, bull_trans3.eulerAngles.y, angle - 20f);
                bull_rb2d2.AddForce(bull_trans2.up.normalized * bulletForce, ForceMode2D.Impulse);
                bull_rb2d3.AddForce(bull_trans3.up.normalized * bulletForce, ForceMode2D.Impulse);
            }
        }
    }
}
