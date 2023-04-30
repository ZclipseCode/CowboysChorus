using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStandoff : BasicControls
{
    [SerializeField] float timeBeforeShot;
    [SerializeField] float timeToShoot;
    [SerializeField] float playerShotTime;
    [SerializeField] float cowboyShotTime;
    [SerializeField] string menuSceneName;
    [SerializeField] AudioClip tumbleweed;
    [SerializeField] AudioClip draw;
    [SerializeField] AudioClip playerShot;
    [SerializeField] AudioClip cowboyShot;
    AudioSource audioSource;
    bool shootReady;
    bool shot;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        StartCoroutine(Standoff());
    }

    void Update()
    {
        if ((onLeft || onRight) && !shot)
        {
            if (shootReady)
            {
                StartCoroutine(Win());
            }
            else
            {
                StartCoroutine(Lose());
            }

            shot = true;
        }
    }

    IEnumerator Standoff()
    {
        yield return new WaitForSeconds(timeBeforeShot / 2);

        audioSource.PlayOneShot(tumbleweed);

        yield return new WaitForSeconds(timeBeforeShot / 2);

        StartCoroutine(ShootReady());
    }

    IEnumerator Win()
    {
        audioSource.PlayOneShot(playerShot);

        yield return new WaitForSeconds(playerShotTime);

        GameObject music = GameObject.FindGameObjectWithTag("Audio");
        if (music.TryGetComponent<Music>(out Music m))
        {
            m.NewScene(Stage.Win);
        }

        SceneManager.LoadScene(menuSceneName);
    }

    IEnumerator Lose()
    {
        audioSource.PlayOneShot(cowboyShot);

        yield return new WaitForSeconds(cowboyShotTime);

        GameObject music = GameObject.FindGameObjectWithTag("Audio");
        if (music.TryGetComponent<Music>(out Music m))
        {
            m.NewScene(Stage.Lose);
        }

        SceneManager.LoadScene(menuSceneName);
    }

    IEnumerator ShootReady()
    {
        shootReady = true;

        GameObject music = GameObject.FindGameObjectWithTag("Audio");
        if (music.TryGetComponent<Music>(out Music m))
        {
            m.StopTrack();
        }

        audioSource.PlayOneShot(draw);

        yield return new WaitForSeconds(timeToShoot);

        StartCoroutine(Lose());
    }
}
