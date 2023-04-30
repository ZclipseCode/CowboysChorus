using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowboyVisual : MonoBehaviour
{
    void Start()
    {
        VisualManager visualManager = GameObject.FindGameObjectWithTag("Player").GetComponent<VisualManager>();
        if (visualManager != null)
        {
            if (visualManager.GetActive())
            {
                EnableSprites(transform);
            }
            else
            {
                DisableSprites(transform);
            }
        }
    }

    private void EnableSprites(Transform parentTransform)
    {
        SpriteRenderer parentSprite = parentTransform.GetComponent<SpriteRenderer>();
        if (parentSprite != null)
        {
            parentSprite.enabled = true;
        }

        foreach (Transform childTransform in parentTransform)
        {
            EnableSprites(childTransform);

            SpriteRenderer childSprite = childTransform.GetComponent<SpriteRenderer>();
            if (childSprite != null)
            {
                childSprite.enabled = true;
            }
        }
    }

    private void DisableSprites(Transform parentTransform)
    {
        SpriteRenderer parentSprite = parentTransform.GetComponent<SpriteRenderer>();
        if (parentSprite != null)
        {
            parentSprite.enabled = false;
        }

        foreach (Transform childTransform in parentTransform)
        {
            DisableSprites(childTransform);

            SpriteRenderer childSprite = childTransform.GetComponent<SpriteRenderer>();
            if (childSprite != null)
            {
                childSprite.enabled = false;
            }
        }
    }
}
