using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    public Image image;
    public Image imageChange;
    [SerializeField] float currentBlood = 1f;
    [SerializeField] float targetBlood = 1f;
    [SerializeField] float addSpeed;
    [SerializeField] float reduceSpeed;

    [SerializeField] Color changeColor = Color.yellow;
    private Animator _animator;
    public GameObject LosePanel;
    private Hp hp;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        hp = new Hp(100);
        image.fillAmount = currentBlood;
        imageChange.color = changeColor;
        image.color = Color.red;
    }

    public void TakeDamage(float damage)
    {
        hp.TakeDamage(damage);
        targetBlood = hp.HealthRot();
        OnTakeDamage();
    }

    private void OnTakeDamage()
    {
        _animator.SetBool("Onhit", true);
    }

    void Update()
    {
        //»ºÂý¼õÑª
        if (currentBlood > targetBlood)
        {
            currentBlood -= reduceSpeed * Time.deltaTime;
        }
        // »ºÂý¼ÓÑª
        else
        {
            currentBlood += addSpeed * Time.deltaTime;
        }
        image.fillAmount = targetBlood;
        imageChange.fillAmount = currentBlood;
        if (hp.currentHealth <= 0)
        {
            Die();
        }
    }


    private void Die()
    {
        Debug.Log("Íæ¼ÒËÀÍö");

        GameObject temp = new GameObject("SceneLoader");
        SceneLoader loader = temp.AddComponent<SceneLoader>();
        loader.LoadSceneDelayed();
        Destroy(gameObject);
        //ÓÎÏ·½áÊø
        if (LosePanel != null)
        {
            LosePanel.SetActive(true);
        }
    }
}
