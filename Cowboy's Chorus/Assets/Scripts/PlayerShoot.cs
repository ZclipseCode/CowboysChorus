using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform leftBulletPoint;
    [SerializeField] Transform rightBulletPoint;
    [SerializeField] float bulletSpeed;
    [SerializeField] float gunCooldown;
    bool onLeft;
    bool onRight;
    bool shootingLeft;
    bool shootingRight;

    void Update()
    {
        if (onLeft && !shootingLeft)
            StartCoroutine(ShootLeft());

        if (onRight && !shootingRight)
            StartCoroutine(ShootRight());
    }

    IEnumerator ShootLeft()
    {
        shootingLeft = true;
        GameObject b = Instantiate(bullet, leftBulletPoint.position, Quaternion.identity);
        b.GetComponent<Rigidbody2D>().velocity = Vector2.left * bulletSpeed;
        yield return new WaitForSeconds(gunCooldown);
        shootingLeft = false;
    }

    IEnumerator ShootRight()
    {
        shootingRight = true;
        GameObject b = Instantiate(bullet, rightBulletPoint.position, Quaternion.identity);
        b.GetComponent<Rigidbody2D>().velocity = -Vector2.left * bulletSpeed;
        yield return new WaitForSeconds(gunCooldown);
        shootingRight = false;
    }

    public void OnLeft(InputAction.CallbackContext context)
    {
        onLeft = context.action.triggered;
    }

    public void OnRight(InputAction.CallbackContext context)
    {
        onRight = context.action.triggered;
    }
}
