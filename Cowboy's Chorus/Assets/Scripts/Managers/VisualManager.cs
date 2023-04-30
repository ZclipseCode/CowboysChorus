using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VisualManager : BasicControls
{
    GameObject[] goArr;
    List<GameObject> goList;
    static bool active;
    bool toggled;
    static bool first = true;

    void Start()
    {
        CollectGameObjects();

        if (first)
        {
            if (goList.Where(go => go.GetComponent<SpriteRenderer>() != null && go.GetComponent<SpriteRenderer>().enabled)
            .Count() > 0)
            {
                active = true;
            }
            else
            {
                active = false;
            }

            first = false;
        }

        if (active)
        {
            EnableSR();
        }
        else
        {
            DisableSR();
        }
    }

    private void Update()
    {
        if (onInteract && !toggled)
        {
            SRChange();
            toggled = true;
        }

        if (!onInteract)
        {
            toggled = false;
        }
    }

    void CollectGameObjects()
    {
        goArr = GameObject.FindObjectsOfType<GameObject>();

        goList = new List<GameObject>(goArr.Length);

        foreach (GameObject go in goArr)
        {
            goList.Add(go);
        }
    }

    void EnableSR()
    {
        goList.Where(go => go.GetComponent<SpriteRenderer>() != null)
                .ToList()
                .ForEach(go => go.GetComponent<SpriteRenderer>().enabled = true);

        active = true;
    }

    void DisableSR()
    {
        goList.Where(go => go.GetComponent<SpriteRenderer>() != null)
                .ToList()
                .ForEach(go => go.GetComponent<SpriteRenderer>().enabled = false);

        active = false;
    }

    public void SRChange()
    {
        if (active)
        {
            DisableSR();
        }
        else
        {
            EnableSR();
        }
    }

    public bool GetActive()
    {
        return active;
    }
}
