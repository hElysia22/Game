using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 200;
    private int _currentHealth;
    private Animator _animator;
    // Start is called before the first frame update
    private void Awake()
    {
        _currentHealth = maxHealth;
        _animator = GetComponent<Animator>();
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
        //ÓÎÏ·½áÊø
        SceneManager.LoadScene("StartScene");
    }

    private void OnTakeDamage(int damage)
    {
        _animator.SetBool("Onhit", true);
    }

}
