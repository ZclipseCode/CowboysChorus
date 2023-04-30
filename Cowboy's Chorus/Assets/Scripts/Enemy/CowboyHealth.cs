using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowboyHealth : Health
{
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

            Destroy(gameObject);
        }
    }
}
