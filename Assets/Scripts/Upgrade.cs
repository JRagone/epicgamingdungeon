using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public string upgradeName = "";

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        EventBus.Publish<UpgradeCollectedEvent>(new UpgradeCollectedEvent(upgradeName));
    }
}

public class UpgradeCollectedEvent
{

    public string name;

    public UpgradeCollectedEvent(string name_in = "")
    {
        name = name_in;
    }
}
