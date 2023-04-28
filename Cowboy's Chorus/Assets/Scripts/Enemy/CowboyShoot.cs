using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowboyShoot : MonoBehaviour
{
    [SerializeField] LayerMask player;
    [SerializeField] AudioClip gunShot;
    [SerializeField] float timeBeforeShoot;
    [SerializeField] float rayDistance;
    [SerializeField] int damage;
    AudioSource audioSource;
    bool playerTargeted;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!playerTargeted)
        {
            RaycastHit2D leftHit = Physics2D.Raycast(transform.position, -transform.right, rayDistance, player);
            RaycastHit2D rightHit = Physics2D.Raycast(transform.position, transform.right, rayDistance, player);
            if (leftHit.collider != null)
            {
                playerTargeted = true;
                StartCoroutine(Shoot(leftHit));
            }
            if (rightHit.collider != null)
            {
                playerTargeted = true;
                StartCoroutine(Shoot(rightHit));
            }
        }
    }

    IEnumerator Shoot(RaycastHit2D hit)
    {
        yield return new WaitForSeconds(timeBeforeShoot);

        audioSource.PlayOneShot(gunShot);

        PlayerHealth health = hit.collider.GetComponent<PlayerHealth>();
        health.TakeDamage(damage);

        playerTargeted = false;
    }
}
