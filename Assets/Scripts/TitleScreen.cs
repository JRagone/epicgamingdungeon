using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public AudioClip sound;

    void Start()
    {
        AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("StartButton"))
        {
            SceneManager.LoadScene("Game");
        }
    }
}
