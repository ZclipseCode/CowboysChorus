using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] LayerMask enemy;
    [SerializeField] float gunCooldown;
    [SerializeField] float rayDistance;
    bool onLeft;
    bool onRight;
    bool shootingLeft;
    bool shootingRight;

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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.right, rayDistance, enemy);
        if (hit.collider != null)
        {
            Destroy(hit.collider.gameObject);
        }

        yield return new WaitForSeconds(gunCooldown);
        shootingLeft = false;
    }

    IEnumerator ShootRight()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, rayDistance, enemy);
        if (hit.collider != null)
        {
            Destroy(hit.collider.gameObject);
        }

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
