using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : BasicControls
{
    [SerializeField] GameObject audioManager;
    [SerializeField] GameObject antiAudioManager;
    bool leftPressed;
    bool antiOn;

    bool ready;

    private void Start()
    {
        StartCoroutine(PlayDelay());
    }

    void Update()
    {
        if (onLeft && !leftPressed)
        {
            if (antiOn)
            {
                Instantiate(audioManager);
                GameObject aam = GameObject.FindGameObjectWithTag("AntiAudio");
                if (aam != null)
                {
                    Destroy(aam);
                }
                antiOn = false;
            }
            else
            {
                Instantiate(antiAudioManager);
                GameObject am = GameObject.FindGameObjectWithTag("Audio");
                if (am != null)
                {
                    Destroy(am);
                }
                antiOn = true;
            }

            leftPressed = true;
        }

        if (!onLeft)
        {
            leftPressed = false;
        }

        if (onRight && ready)
        {
            LoadStartGame();
        }
    }

    void LoadStartGame()
    {
        GameObject music = GameObject.FindGameObjectWithTag("Audio");
        if (music != null)
        {
            if (music.TryGetComponent<Music>(out Music m))
            {
                m.NewScene(Stage.HorseRiding);
            }
        }  

        SceneManager.LoadScene("HorseRiding");
    }

    IEnumerator PlayDelay()
    {
        yield return new WaitForSeconds(1.5f);

        ready = true;
    }
}
