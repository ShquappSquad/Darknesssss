using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float playerScale = 0.85f;

    public float detectDistance = 10.0f;
    public float height = 0.0f;

    public Rigidbody2D rb;
    public Animator animator;
    public Rigidbody2D player;

    //Attack variables; shouldn't be needed
/*     public float attackDistance = 2.5f;
    private BoxCollider2D attackCollider;
    private bool chasing = false;
    private bool isSwinging = false;
    private const float attackDistYScalar = 0.3f;
    private const float attackHeight = 1.0f; */

    Vector2 movement;

    // Update is called once per frame which makes it bad for physics calculations
    void Update()
    {      
                Vector3 offset = player.position - rb.position;
                float magnitude = offset.magnitude;

                // actually try to move to be on same y as player
                offset = ConvertTo8Dir(offset);

                magnitude = offset.magnitude;

                transform.Translate(new Vector3((offset.x * moveSpeed), (offset.y * moveSpeed), 0) * Time.deltaTime);

                //Animation triggers
                //animator.SetFloat("Horizontal", offset.x);
                //animator.SetFloat("Speed", offset.sqrMagnitude);           
        
    }

/*     void BeginAttack(bool left)
    {
        isSwinging = true;
        // stop moving
        movement.x = 0.0f;
        movement.y = 0.0f;
#if WORKER_DEBUG
                        Debug.Log("attack time!");
#endif
        Vector2 inner = new Vector2(rb.position.x, rb.position.y);
        inner.y += height;
        Vector2 outer = new Vector2(inner.x + (left ? -attackDistance : attackDistance), inner.y + attackHeight);
    } */

    // FixedUpdate will be called a fixed number of times per second regardless of frame rate
    void FixedUpdate()
    {
        //Left/Right Movement 
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    // converts a vector to a standard 8-direction vector
    private static Vector3 ConvertTo8Dir(Vector3 vector)
    {
        Vector3 ret = new Vector3(0.0f, 0.0f, 0.0f);
        // lock x to +1, 0, or -1
        if (vector.x > 0.0f)
        {
            ret.x = 1.0f;
        }
        else if (vector.x < 0.0f)
        {
            ret.x = -1.0f;
        }

        // lock y to +1, 0, or -1
        if (vector.y > 0.0f)
        {
            ret.y = 1.0f;
        }
        else if (vector.y < 0.0f)
        {
            ret.y = -1.0f;
        }

        // normalize to magnitude 1
        return ret.normalized;
    }
}

