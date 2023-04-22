using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowboySpawner : MonoBehaviour
{
    [SerializeField] GameObject cowboy;
    [SerializeField] int minTimeBetweenSpawn;
    [SerializeField] int maxTimeBetweenSpawn;
    GameObject currentCowboy;
    int timeBetweenSpawn;
    bool spawning;

    void Update()
    {
        if (!spawning && currentCowboy == null)
        {
            spawning = true;
            timeBetweenSpawn = Random.Range(minTimeBetweenSpawn, maxTimeBetweenSpawn);
            StartCoroutine(Spawn());
        }
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(timeBetweenSpawn);
        currentCowboy = Instantiate(cowboy, transform.position, Quaternion.identity);
        spawning = false;
    }
}
