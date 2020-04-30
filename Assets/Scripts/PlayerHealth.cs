using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{

    public Text playerHealthText;

    new void Update()
    {
        playerHealthText.text = "Health: " + health.ToString();
        if (health <= 0)
        {
            EventBus.Publish<PlayerKilledEvent>(new PlayerKilledEvent());
        }
        base.Update();
    }
}

public class PlayerKilledEvent
{
    public PlayerKilledEvent()
    {

    }
}
