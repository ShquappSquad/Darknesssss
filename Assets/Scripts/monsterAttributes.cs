using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterHealth : MonoBehaviour
{
    private float currentHealth, maxHealth = 30f;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        Debug.Log(name + " has " + currentHealth + " health");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
