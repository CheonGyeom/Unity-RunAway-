using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMove : MonoBehaviour
{
    Rigidbody2D rb;
    Transform target;

    float followspeed = 3f;

    static public int attack = 21;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, followspeed * Time.deltaTime);
    }
}
