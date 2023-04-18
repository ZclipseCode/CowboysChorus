using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    bool left;
    bool right;

    public void OnLeft(InputAction.CallbackContext context)
    {
        left = context.action.triggered;
    }

    public void OnRight(InputAction.CallbackContext context)
    {
        right = context.action.triggered;
    }

    public bool GetLeft() => left;
    public bool GetRight() => right;
}
