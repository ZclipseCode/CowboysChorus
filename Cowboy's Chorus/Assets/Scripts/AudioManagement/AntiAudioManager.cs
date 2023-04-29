using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiAudioManager : MonoBehaviour
{
    static AntiAudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(instance.gameObject);
            DontDestroyOnLoad(gameObject);
        }
    }

    //void Start()
    //{
    //    GameObject audioManager = GameObject.FindGameObjectWithTag("Audio");
    //    if (audioManager != null)
    //    {
    //        Destroy(audioManager);
    //    }
    //}
}
