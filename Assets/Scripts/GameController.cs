using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public Text victoryText;
    public Text restartText;
    public Enemy frogObject;

    Subscription<GameOverEvent> game_over_subscription;
    Subscription<PlayerKilledEvent> player_killed_subscription;

    private float originalFrogSpeed;

    // Start is called before the first frame update
    void Start()
    {
        victoryText.enabled = false;
        restartText.enabled = false;
        game_over_subscription = EventBus.Subscribe<GameOverEvent>(_OnGameOver);
        player_killed_subscription = EventBus.Subscribe<PlayerKilledEvent>(_OnPlayerKilled);
        originalFrogSpeed = frogObject.speed;
    }

    void Awake()
    {
        DontDestroyOnLoad(victoryText);
        DontDestroyOnLoad(restartText);
    }

    void Update()
    {
        Debug.Log(originalFrogSpeed);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (restartText.enabled && Input.GetButtonDown("StartButton"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void _OnGameOver(GameOverEvent e)
    {
        victoryText.enabled = true;
        restartText.enabled = true;
        frogObject.speed = originalFrogSpeed;
    }

    void _OnPlayerKilled(PlayerKilledEvent e)
    {
        restartText.enabled = true;
        frogObject.speed = originalFrogSpeed;
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe(game_over_subscription);
        EventBus.Unsubscribe(player_killed_subscription);
    }
}
