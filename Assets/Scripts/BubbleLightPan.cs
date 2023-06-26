using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BubbleLightPan : MonoBehaviour
{
    public Transform player;
    public float damageAmount;

    public UnityEngine.Rendering.Universal.Light2D lantern;

    public float attackRange;

    void Start()
    {
        // attackRange = GetComponent<UnityEngine.Rendering.Universal.Light2D>().Radius.Inner;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y - 0.75f, 0);
        Attack();

    }

    void Attack()
    {
        Physics2D.OverlapCircleAll(player.position, attackRange);
    }
}
