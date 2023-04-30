using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    [SerializeField] string loseSceneName;

    public override void TakeDamage(int damage)
    {
        health -= damage;

        // hit sfx

        if (health <= 0)
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
}
