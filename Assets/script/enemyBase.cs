using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class enemyBase : MonoBehaviour
{
    public int maxHealth;
    private int _currentHealth;
    protected Animator animator;
    public float healthRatio => (float)_currentHealth/maxHealth;
    protected int velX = Animator.StringToHash("v_h");
    protected int velZ = Animator.StringToHash("v_v");
    // Start is called before the first frame update

    protected virtual void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && animator.GetCurrentAnimatorStateInfo(0).IsName("Hit_F_1"))
        {
            animator.SetBool("Onhit", false);
        }
    }
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
        OnHit();
    }

    protected virtual void OnHit()
    {
        animator.SetBool("Onhit", true);
    }

    protected virtual void OnMove(float v_h, float v_v)
    {
        animator.SetFloat(velX, v_h);
        animator.SetFloat(velZ, v_v);
    }

    protected virtual void Awake()
    {
        _currentHealth = maxHealth;
        animator = GetComponentInChildren<Animator>();
        Debug.Log("当前血量" + _currentHealth);
    }

}
