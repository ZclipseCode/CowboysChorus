using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowboyHealth : Health
{
    public override void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
            Destroy(gameObject);
    }
}
