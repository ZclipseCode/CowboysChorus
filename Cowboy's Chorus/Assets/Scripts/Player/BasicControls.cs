using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BasicControls : MonoBehaviour
{
    protected bool onLeft;
    protected bool onRight;
    protected bool onInteract;

    public void OnLeft(InputAction.CallbackContext context)
    {
        onLeft = context.action.triggered;
    }

    public void OnRight(InputAction.CallbackContext context)
    {
        onRight = context.action.triggered;
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        onInteract = context.action.triggered;
    }
}
