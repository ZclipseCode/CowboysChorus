using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowboyMove : MonoBehaviour
{
    [SerializeField] int speedMin;
    [SerializeField] int speedMax;
    Transform player;
    Vector2 startPos;
    Vector2 endPos;
    int speed;
    float timer;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        startPos = transform.position;
        endPos = new Vector2(transform.position.x, player.position.y);
        speed = Random.Range(speedMin, speedMax);
    }

    void Update()
    {
        timer += Time.deltaTime;
        transform.position = Vector2.Lerp(startPos, endPos, timer / speed);
    }
}
