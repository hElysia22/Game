using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class enemyBase : MonoBehaviour
{
    public int maxHealth;
    private int _currentHealth;
    public float healthRatio => (float)_currentHealth/maxHealth;
    // Start is called before the first frame update

    public void TakeDamage(int damage)
    {
        _currentHealth = Mathf.Max(_currentHealth - damage, 0);
        OnTakeDamage(damage);
        Debug.Log("剩余血量" + _currentHealth);
        OnHealthChanged?.Invoke();
        if (_currentHealth <= 0)
        {
            Die();
        }
    }
    protected abstract void Die();
    internal event Action OnHealthChanged;

    //受到伤害后的反应
    protected virtual void OnTakeDamage(int damage)
    {
        Debug.Log("受到伤害");
    }

    protected virtual void Awake()
    {
        _currentHealth = maxHealth;
        Debug.Log("当前血量" + _currentHealth);
    }

}
