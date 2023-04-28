using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    public override void TakeDamage(int damage)
    {
        health -= damage;

        // hit sfx

        if (health <= 0)
            Destroy(gameObject);
    }
}
