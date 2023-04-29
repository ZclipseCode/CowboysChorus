using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : BasicControls
{
    void Update()
    {
        if (onLeft)
        {

        }

        if (onRight)
        {
            LoadStartGame();
        }
    }

    void LoadStartGame()
    {
        Music music = GameObject.FindGameObjectWithTag("Audio").GetComponent<Music>();
        music.NewScene(Stage.HorseRiding);

        SceneManager.LoadScene("HorseRiding");
    }
}
