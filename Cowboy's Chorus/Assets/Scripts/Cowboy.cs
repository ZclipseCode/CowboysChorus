using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowboy : MonoBehaviour
{
    [SerializeField] float horseSpeedMin;
    [SerializeField] float horseSpeedMax;
    [SerializeField] float bulletSpeed;
    Transform player;
    Vector3 startPos;
    float horseSpeed;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(startPos, player.position, horseSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {

        }
    }
}
