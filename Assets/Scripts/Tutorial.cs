using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    Subscription<PlayerMovedEvent> player_moved_subscription;
    Subscription<EnemyKilledEvent> enemy_killed_subscription;
    Subscription<UpgradeCollectedEvent> upgrade_collected_subscription;

    // Start is called before the first frame update
    void Start()
    {
        player_moved_subscription = EventBus.Subscribe<PlayerMovedEvent>(_OnPlayerMoved);
        enemy_killed_subscription = EventBus.Subscribe<EnemyKilledEvent>(_OnEnemyKilled);
        upgrade_collected_subscription = EventBus.Subscribe<UpgradeCollectedEvent>(_OnUpgradeCollected);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void _OnPlayerMoved(PlayerMovedEvent e)
    {
        SpawnManager.Instance.SpawnTutorialEnemy();
        EventBus.Unsubscribe(player_moved_subscription);
    }

    void _OnEnemyKilled(EnemyKilledEvent e)
    {
        SpawnManager.Instance.SpawnTutorialUpgrades();
        EventBus.Unsubscribe(enemy_killed_subscription);
    }

    void _OnUpgradeCollected(UpgradeCollectedEvent e)
    {
        EventBus.Publish<TutorialCompleteEvent>(new TutorialCompleteEvent());
        EventBus.Unsubscribe(upgrade_collected_subscription);
    }

        private void OnDestroy()
    {
        EventBus.Unsubscribe(player_moved_subscription);
        EventBus.Unsubscribe(enemy_killed_subscription);
    }
}

public class TutorialCompleteEvent
{
    public TutorialCompleteEvent()
    {

    }
}
