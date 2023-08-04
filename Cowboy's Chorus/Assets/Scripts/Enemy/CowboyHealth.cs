using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Metadata;

public class CowboyHealth : Health
{
    SpriteRenderer parentSr;
    SpriteRenderer[] childrenSr;

    private void Start()
    {
        parentSr = GetComponent<SpriteRenderer>();
        childrenSr = GetComponentsInChildren<SpriteRenderer>();
    }

    public override void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            GameObject gameManager = GameObject.FindGameObjectWithTag("Game");
            if (gameManager.TryGetComponent<GameManager>(out GameManager gm))
            {
                gm.Increment();
            }

            StartCoroutine(Dead());
        }
    }

    private void Update()
    {
        if (health <= 0)
        {
            parentSr.enabled = false;

            foreach (SpriteRenderer child in childrenSr)
            {
                child.enabled = false;
            }
        }
    }

    IEnumerator Dead()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = null;

        CowboyShoot cowboyShoot = GetComponent<CowboyShoot>();
        cowboyShoot.enabled = false;

        yield return new WaitForSeconds(0.8f);

        Destroy(gameObject);
    }

    public int GetHealth()
    {
        return health;
    }
}
