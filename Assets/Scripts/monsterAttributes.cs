using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterHealth : MonoBehaviour
{
    private float health, maxHealth = 30f;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            // Destroy();
        }
    }
}
