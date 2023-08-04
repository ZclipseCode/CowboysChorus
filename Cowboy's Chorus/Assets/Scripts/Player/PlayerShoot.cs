using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : BasicControls
{
    [SerializeField] LayerMask enemy;
    [SerializeField] AudioClip gunShot;
    [SerializeField] AudioClip score;
    [SerializeField] AudioClip reload;
    [SerializeField] AudioClip miss;
    [SerializeField] float gunCooldown;
    [SerializeField] float rayDistance;
    [SerializeField] float sfxDelay;
    [SerializeField] int damage;
    AudioSource audioSource;
    bool shootingLeft;
    bool shootingRight;

    [SerializeField] AudioSource leftMiss;
    [SerializeField] AudioSource rightMiss;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (onLeft && !shootingLeft)
        {
            shootingLeft = true;
            StartCoroutine(ShootLeft());
        }

        if (onRight && !shootingRight)
        {
            shootingRight = true;
            StartCoroutine(ShootRight());
        }

        Debug.DrawRay(transform.position, -transform.right * rayDistance, Color.green, 1);
        Debug.DrawRay(transform.position, transform.right * rayDistance, Color.green, 1);
    }

    IEnumerator ShootLeft()
    {
        audioSource.PlayOneShot(gunShot);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.right, rayDistance, enemy);
        if (hit.collider != null)
        {
            StartCoroutine(Score());

            CowboyHealth health = hit.collider.GetComponent<CowboyHealth>();
            health.TakeDamage(damage);
        }
        else
        {
            StartCoroutine(Miss(-1));
        }

        StartCoroutine(Reload());

        yield return new WaitForSeconds(gunCooldown);
        shootingLeft = false;
    }

    IEnumerator ShootRight()
    {
        audioSource.PlayOneShot(gunShot);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, rayDistance, enemy);
        if (hit.collider != null)
        {
            StartCoroutine(Score());

            CowboyHealth health = hit.collider.GetComponent<CowboyHealth>();
            health.TakeDamage(damage);
        }
        else
        {
            StartCoroutine(Miss(1));
        }

        StartCoroutine(Reload());

        yield return new WaitForSeconds(gunCooldown);
        shootingRight = false;
    }

    IEnumerator Score()
    {
        yield return new WaitForSeconds(sfxDelay);

        audioSource.PlayOneShot(score);
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(sfxDelay);

        audioSource.PlayOneShot(reload);
    }

    IEnumerator Miss(int dir)
    {
        yield return new WaitForSeconds(0.2f);

        if (dir < 0)
        {
            leftMiss.PlayOneShot(miss);
        }
        else
        {
            rightMiss.PlayOneShot(miss);
        }
    }
}
