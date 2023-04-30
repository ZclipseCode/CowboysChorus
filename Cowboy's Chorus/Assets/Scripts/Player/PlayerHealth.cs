using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    [SerializeField] string loseSceneName;
    [SerializeField] AudioClip cowboyShot;
    [SerializeField] float cowboyShotLength;

    public override void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            GameObject music = GameObject.FindGameObjectWithTag("Audio");
            if (music.TryGetComponent<Music>(out Music m))
            {
                m.StartCoroutine(m.PlayClip(cowboyShot, cowboyShotLength, LoseScene));
                m.NewScene(Stage.Lose);
            }
        }
    }

    private void LoseScene()
    {
        GameObject music = GameObject.FindGameObjectWithTag("Audio");
        if (music.TryGetComponent<Music>(out Music m))
        {
            m.NewScene(Stage.Lose);
        }

        SceneManager.LoadScene(loseSceneName);

        Destroy(gameObject);
    }
}
