using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetedMovement : MonoBehaviour
{

    public Transform target;
    public float speed;

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    protected void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector2 target_pos = new Vector2(target.position.x, target.position.y);
            Vector2 self_pos = new Vector2(transform.position.x, transform.position.y);
            Vector2 direction = (target_pos - self_pos).normalized;
            rb2d.velocity = (direction * speed);
        }
    }
}
