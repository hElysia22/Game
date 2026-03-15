using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBlood : MonoBehaviour
{
    Image image;
    [SerializeField] float currentBlood = 1f;
    [SerializeField] float targetBlood = 1f;
    [SerializeField] float addSpeed;
    [SerializeField] float reduceSpeed;
    [SerializeField] Image imageChange;
    [SerializeField] Color changeColor = Color.yellow;
    [Header("Íæ¼Ò")]
    public PlayerHealth player;

    private void Awake()
    {
        Image[] allImages = transform.parent.GetComponentsInChildren<Image>();
        imageChange = allImages[1];
        image = allImages[2];
        if(player == null)
        {
            Debug.Log("Î´ÕÒµ½Íæ¼Ò");
        }
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
        player.OnHealthChanged += changeBlood;
    }

    private void OnDisable()
    {
        player.OnHealthChanged -= changeBlood;
    }

    void changeBlood()
    {
        Debug.Log("Íæ¼Ò´¥·¢¿ÛÑª");
        targetBlood = player.healthRatio;
        image.fillAmount = targetBlood;
    }



    // Update is called once per frame
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
    }
}
