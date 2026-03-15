using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_collider : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player") 
        {
            Debug.Log("进入碰撞区域");
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Debug.Log("正在碰撞");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("碰撞结束");
        }
    }

}
