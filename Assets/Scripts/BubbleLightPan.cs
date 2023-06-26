using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BubbleLightPan : MonoBehaviour
{
    public Transform player;
    public float damageAmount;

    // public UnityEngine.Rendering.Universal.Light2D lantern;

    public float attackRange;
    public LayerMask enemyLayers;

    void Start()
    {
        // attackRange = GetComponent<UnityEngine.Rendering.Universal.Light2D>().radius.inner;
        attackRange = 2.5f;
        damageAmount = 0.02f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y - 0.75f, 0);
        Attack();

    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(player.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            // Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<monsterHealth>().takeDamage(damageAmount);
        }
    }
}
