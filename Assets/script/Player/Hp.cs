using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Hp
{
    public float maxHealth;
    public float currentHealth;

    public Hp(float max)
    {
        maxHealth = max;
        currentHealth = max;
    }

    public float HealthRot()
    {
        return currentHealth / maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth < 0)
        {
            currentHealth = 0;
        }
    }
}
