using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] float gunCooldown;
    PlayerController pc;

    void Start()
    {
        pc = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (pc.GetLeft())
            Debug.Log("left");

        if (pc.GetRight())
            Debug.Log("right");
    }

    void ShootLeft()
    {

    }
}
