using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    float maxHealth;
    float health;

    public EnemyHealth(float maxHealth)
    {
        this.maxHealth = maxHealth;
        health = maxHealth;
    }
    public void LoseHealth(float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            health = 0f;
        }
    }
    public void RecoverHealth(float amount)
    {
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
    public float GetHealth()
    {
        return health;
    }
}
