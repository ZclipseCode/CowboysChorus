using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    [SerializeField] AudioClip menu;
    [SerializeField] AudioClip horseRiding;
    [SerializeField] AudioClip standoff;
    [SerializeField] AudioClip win;
    [SerializeField] AudioClip lose;
    static Music instance;
    AudioSource audioSource;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name != "Menu")
        {
            GameObject aam = GameObject.FindGameObjectWithTag("AntiAudio");
            if (aam != null)
            {
                Destroy(gameObject);
            }
        }

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        NewScene(Stage.Menu);
    }

    public void NewScene(Stage stage)
    {
        if (stage == Stage.HorseRiding)
        {
            audioSource.clip = horseRiding;
            audioSource.Play();
        }
        else if (stage == Stage.Standoff)
        {
            audioSource.clip = standoff;
            audioSource.Play();
        }
        else if (stage == Stage.Win)
        {
            audioSource.clip = win;
            audioSource.Play();
        }
        else if (stage == Stage.Lose)
        {
            audioSource.clip = lose;
            audioSource.Play();
        }
        else
        {
            audioSource.clip = menu;
            audioSource.Play();
        }
    }
}

[Serializable] public enum Stage
{
    Menu,
    HorseRiding,
    Standoff,
    Win,
    Lose
}