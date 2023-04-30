using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] int target;
    [SerializeField] string standoffSceneName;
    [SerializeField] TMP_Text remaining;
    [SerializeField] AudioClip playerShot;
    [SerializeField] float playerShotTime;
    int defeats;

    private void Start()
    {
        if (remaining != null)
        {
            remaining.text = $"{defeats}/{target}";
        }
    }

    public void Increment()
    {
        defeats++;

        remaining.text = $"{defeats}/{target}";

        if (defeats >= target)
        {
            GameObject music = GameObject.FindGameObjectWithTag("Audio");
            if (music.TryGetComponent<Music>(out Music m))
            {
                StartCoroutine(m.PlayClip(playerShot, playerShotTime, Standoff));
            }
        }
    }

    private void Standoff()
    {
        GameObject music = GameObject.FindGameObjectWithTag("Audio");
        if (music.TryGetComponent<Music>(out Music m))
        {
            m.NewScene(Stage.Standoff);
        }

        SceneManager.LoadScene(standoffSceneName);
    }
}
