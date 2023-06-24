using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayer : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float detectDistance = 10.0f;    // I have no idea how far this is but...
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;
    private bool direction = true; // True => Moving to the Left || False => Moving to the Right
    private bool moving = false;
    private float turnThreshold = 0.05f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position);
            moving = isPlayerInRange(direction);
        }
        else
        {
            Debug.Log("Target not found!");
        }
    }

    private bool isPlayerInRange(Vector3 direction)
    {
        if (direction.magnitude < detectDistance)
        {
            moveDirection = direction.normalized;
            return true;
        }
        return false;
    }

    private void FixedUpdate()
    {
        if (target && moving)
        {
            followPlayer();
            turnMonster();
        }
    }

    private void followPlayer()
    {
        rb.velocity = new Vector2(moveDirection.x, 0) * moveSpeed;
    }

    private void turnMonster()
    {
        if (moveDirection.x < turnThreshold && !direction)
        {
            rb.transform.Rotate(0, 180, 0);
            direction = true;
        }
        if (moveDirection.x > turnThreshold && direction)
        {
            rb.transform.Rotate(0, 180, 0);
            direction = false;
        }
        // Debug.Log("Monster Moving");
    }
}
