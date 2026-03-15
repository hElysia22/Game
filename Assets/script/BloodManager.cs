using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodBase : MonoBehaviour
{
    Image image;
    [SerializeField] float currentBlood = 1f;
    [SerializeField] float targetBlood = 1f;
    [SerializeField] float addSpeed;
    [SerializeField] float reduceSpeed;
    [SerializeField] Image imageChange;
    [SerializeField] Color changeColor = Color.yellow;
    private enemyBase enemy;

    private void Awake()
    {
        Image[] allImages = transform.parent.GetComponentsInChildren<Image>();
        enemy = GetComponentInParent<enemyBase>();
        imageChange = allImages[1];
        image = allImages[2];
    }
    // Start is called before the first frame update
    void Start()
    {
        image.fillAmount = currentBlood;
        imageChange.color = changeColor;
        image.color = Color.red;
    }

    private void OnEnable()
    {
        enemy.OnHealthChanged += changeBlood;
    }

    private void OnDisable()
    {
        enemy.OnHealthChanged -= changeBlood;
    }

    void changeBlood()
    {
        Debug.Log("触发扣血");
        targetBlood = enemy.healthRatio;
        image.fillAmount = targetBlood;
    }



    // Update is called once per frame
    void Update()
    {
        //缓慢减血
        if (currentBlood > targetBlood)
        {
            currentBlood -= reduceSpeed * Time.deltaTime;
        }
        // 缓慢加血
        else
        {
            currentBlood += addSpeed * Time.deltaTime;
        }
        imageChange.fillAmount = currentBlood;
    }


}
