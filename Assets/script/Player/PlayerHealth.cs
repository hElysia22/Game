using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 200;
    private int _currentHealth;
    // Start is called before the first frame update
    private void Awake()
    {
        _currentHealth = maxHealth;
    }

    public float healthRatio => (float)_currentHealth / maxHealth;
    // Start is called before the first frame update

    internal event Action OnHealthChanged;
    public void TakeDamage(int damage)
    {
        _currentHealth = Mathf.Max(_currentHealth - damage, 0);
        OnTakeDamage(damage);
        OnHealthChanged?.Invoke();
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Íæ¼ÒËÀÍö");
        Destroy(gameObject);
        SceneManager.LoadScene("");
    }

    private void OnTakeDamage(int damage)
    {
        
    }

}
