using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip backgroundMusic;
    public static SoundManager Instance
    {
        get { return _instance; }
    }

    private static SoundManager _instance;
    private float elapsed_time;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            elapsed_time = 0.0f;
            PlayBackgroundMusic();
            DontDestroyOnLoad(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (elapsed_time >= 7.2f)
        {
            elapsed_time = 0.0f;
            PlayBackgroundMusic();
        }
        elapsed_time += Time.deltaTime;
    }

    private void PlayBackgroundMusic()
    {
        AudioSource.PlayClipAtPoint(backgroundMusic, Camera.main.transform.position, 0.5f);
    }
}
