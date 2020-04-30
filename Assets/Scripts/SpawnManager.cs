using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameObject playerUpgradePrefab;
    public GameObject gunUpgradePrefab;
    public GameObject shotgunUpgradePrefab;
    public GameObject rofUpgradePrefab;
    public GameObject tutorialEnemyPrefab;
    public Enemy frogObject;
    public static SpawnManager Instance
    {
        get { return _instance; }
    }

    private static SpawnManager _instance;
    private float enemyCount;
    Subscription<EnemyKilledEvent> enemy_killed_subscription;
    Subscription<UpgradeCollectedEvent> upgrade_collected_subscription;
    Subscription<TutorialCompleteEvent> tutorial_complete_subscription;
    private bool readyForWave;
    private bool upgradeSpawned;
    private int waveNum;
    private List<GameObject> spawnedUpgrades;
    private List<GameObject> validPrefabs;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        enemy_killed_subscription = EventBus.Subscribe<EnemyKilledEvent>(_OnEnemyKilled);
        upgrade_collected_subscription = EventBus.Subscribe<UpgradeCollectedEvent>(_OnUpgradeCollected);
        tutorial_complete_subscription = EventBus.Subscribe<TutorialCompleteEvent>(_OnTutorialComplete);
        waveNum = 0;
        enemyCount = 0;
        readyForWave = false;
        upgradeSpawned = true;
        validPrefabs = new List<GameObject> { playerUpgradePrefab, gunUpgradePrefab,
                                              shotgunUpgradePrefab, rofUpgradePrefab };
        spawnedUpgrades = new List<GameObject> { };
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCount <= 0)
        {
            if (readyForWave)
            {
                ++waveNum;
                SpawnEnemies();
                readyForWave = false;
            }
            else if (!upgradeSpawned)
            {
                SpawnUpgrades();
                upgradeSpawned = true;
            }
        }
    }

    private void SpawnEnemies()
    {
        if (waveNum == 1)
        {
            Instantiate(enemyPrefab, enemyPrefab.transform.position, enemyPrefab.transform.rotation);
            ++enemyCount;
        }
        else if (waveNum == 2)
        {
            frogObject.speed += 1f;
            Vector2 enemy1_loc = new Vector2(enemyPrefab.transform.position.x - 2, enemyPrefab.transform.position.y);
            Vector2 enemy2_loc = new Vector2(enemyPrefab.transform.position.x + 2, enemyPrefab.transform.position.y);
            Instantiate(enemyPrefab, enemy1_loc, enemyPrefab.transform.rotation);
            Instantiate(enemyPrefab, enemy2_loc, enemyPrefab.transform.rotation);
            enemyCount += 2;
        }
        else if (waveNum == 3)
        {
            frogObject.speed += 1;
            Vector2 enemy1_loc = new Vector2(enemyPrefab.transform.position.x - 3, enemyPrefab.transform.position.y);
            Vector2 enemy2_loc = enemyPrefab.transform.position;
            Vector2 enemy3_loc = new Vector2(enemyPrefab.transform.position.x + 3, enemyPrefab.transform.position.y);
            Instantiate(enemyPrefab, enemy1_loc, enemyPrefab.transform.rotation);
            Instantiate(enemyPrefab, enemy2_loc, enemyPrefab.transform.rotation);
            Instantiate(enemyPrefab, enemy3_loc, enemyPrefab.transform.rotation);
            enemyCount += 3;
        }
        else if (waveNum == 4)
        {
            frogObject.speed += 1f;
            Vector2 enemy1_loc = new Vector2(enemyPrefab.transform.position.x - 6, enemyPrefab.transform.position.y);
            Vector2 enemy2_loc = new Vector2(enemyPrefab.transform.position.x - 3, enemyPrefab.transform.position.y);
            Vector2 enemy3_loc = new Vector2(enemyPrefab.transform.position.x + 3, enemyPrefab.transform.position.y);
            Vector2 enemy4_loc = new Vector2(enemyPrefab.transform.position.x + 6, enemyPrefab.transform.position.y);
            Instantiate(enemyPrefab, enemy1_loc, enemyPrefab.transform.rotation);
            Instantiate(enemyPrefab, enemy2_loc, enemyPrefab.transform.rotation);
            Instantiate(enemyPrefab, enemy3_loc, enemyPrefab.transform.rotation);
            Instantiate(enemyPrefab, enemy4_loc, enemyPrefab.transform.rotation);
            enemyCount += 4;
        }
        else if (waveNum == 5)
        {
            frogObject.speed += 1;
            Vector2 enemy1_loc = new Vector2(enemyPrefab.transform.position.x - 6, enemyPrefab.transform.position.y);
            Vector2 enemy2_loc = new Vector2(enemyPrefab.transform.position.x - 3, enemyPrefab.transform.position.y);
            Vector2 enemy3_loc = enemyPrefab.transform.position;
            Vector2 enemy4_loc = new Vector2(enemyPrefab.transform.position.x + 3, enemyPrefab.transform.position.y);
            Vector2 enemy5_loc = new Vector2(enemyPrefab.transform.position.x + 6, enemyPrefab.transform.position.y);
            Instantiate(enemyPrefab, enemy1_loc, enemyPrefab.transform.rotation);
            Instantiate(enemyPrefab, enemy2_loc, enemyPrefab.transform.rotation);
            Instantiate(enemyPrefab, enemy3_loc, enemyPrefab.transform.rotation);
            Instantiate(enemyPrefab, enemy4_loc, enemyPrefab.transform.rotation);
            Instantiate(enemyPrefab, enemy5_loc, enemyPrefab.transform.rotation);
            enemyCount += 5;
        }
    }

    private void SpawnUpgrades()
    {
        int index1 = Random.Range(0, validPrefabs.Count);
        GameObject spawnedUpgrade = Instantiate(validPrefabs[index1], playerUpgradePrefab.transform.position, playerUpgradePrefab.transform.rotation);
        spawnedUpgrades.Add(spawnedUpgrade);
        int index2 = Random.Range(0, validPrefabs.Count);
        while (index1 == index2)
        {
            index2 = Random.Range(0, validPrefabs.Count);
        }
        spawnedUpgrade = Instantiate(validPrefabs[index2], gunUpgradePrefab.transform.position, gunUpgradePrefab.transform.rotation);
        spawnedUpgrades.Add(spawnedUpgrade);
    }

    public void SpawnTutorialEnemy()
    {
        Instantiate(tutorialEnemyPrefab, tutorialEnemyPrefab.transform.position, tutorialEnemyPrefab.transform.rotation);
    }

    public void SpawnTutorialUpgrades()
    {
        int index = 0;
        GameObject spawnedUpgrade = Instantiate(validPrefabs[index], playerUpgradePrefab.transform.position, playerUpgradePrefab.transform.rotation);
        spawnedUpgrades.Add(spawnedUpgrade);
        index = 1;
        spawnedUpgrade = Instantiate(validPrefabs[index], gunUpgradePrefab.transform.position, gunUpgradePrefab.transform.rotation);
        spawnedUpgrades.Add(spawnedUpgrade);
    }

    void _OnEnemyKilled(EnemyKilledEvent e)
    {
        --enemyCount;
        if (enemyCount <= 0 && waveNum == 5)
        {
            EventBus.Publish<GameOverEvent>(new GameOverEvent());
            Destroy(this);
        }
    }

    void _OnUpgradeCollected(UpgradeCollectedEvent e)
    {
        readyForWave = true;
        upgradeSpawned = false;
        foreach (GameObject upgrade in spawnedUpgrades)
        {
            if (upgrade != null)
            {
                Destroy(upgrade);
            }
        }
        if (e.name == "shotgun")
        {
            validPrefabs.RemoveAt(2);
        }
    }

    void _OnTutorialComplete(TutorialCompleteEvent e)
    {
        enemyCount = 0;
        readyForWave = true;
        upgradeSpawned = false;
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe(enemy_killed_subscription);
        EventBus.Unsubscribe(upgrade_collected_subscription);
    }
}

public class GameOverEvent
{
    public GameOverEvent()
    {

    }
}
