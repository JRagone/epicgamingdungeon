using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("MoveHorizontal");
        float moveVertical = Input.GetAxis("MoveVertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        if (movement.sqrMagnitude > 0.0f)
        {
            EventBus.Publish<PlayerMovedEvent>(new PlayerMovedEvent());
        }

        rb.velocity = (movement * speed);
    }
}

public class PlayerMovedEvent
{
    public PlayerMovedEvent ()
    {

    }
}