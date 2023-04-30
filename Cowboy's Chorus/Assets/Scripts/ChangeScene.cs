using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] Stage stage;

    public void LoadScene(string scene)
    {
        GameObject music = GameObject.FindGameObjectWithTag("Audio");
        if (music.TryGetComponent<Music>(out Music m))
        {
            m.NewScene(Stage.Lose);
        }

        SceneManager.LoadScene(scene);
    }
}