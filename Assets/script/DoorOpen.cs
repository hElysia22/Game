using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    //之后添加一个要钥匙才能开门的代码
    private bool hasKey = false;

    public float openAngle = -90;
    public float rotateSpeed = 1f;
    public float detectRange;
    public Transform DetectPoint;

    private bool isOpen = false;
    private Transform Player;
    private Quaternion openRot;
    private Quaternion closeRot;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        closeRot = transform.rotation;
        openRot = closeRot * Quaternion.Euler(0, openAngle, 0);
    }

    // Update is called once per frame
    void Update()
    {
       
        float distance = Vector3.Distance(Player.position, DetectPoint.position);
        Debug.Log("距离：" + distance);
        if (distance < detectRange) 
        {
            isOpen = true;
            Debug.Log("开门");
        }
        else
        {
            isOpen = false;
        }
        if(isOpen)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, openRot, rotateSpeed * Time.deltaTime);
            hasKey = false;
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, closeRot, rotateSpeed * Time.deltaTime);
        }
    }

    public void GetKey()
    {
        hasKey = true;
        Debug.Log("获得钥匙");
    }
}
