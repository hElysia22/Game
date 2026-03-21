using System.Collections;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    private bool hasKey = false; 

    public float openAngle = -90;
    public float rotateSpeed = 1f;
    public float detectRange;
    public Transform DetectPoint;

    private bool isOpen = false;
    private Transform Player;
    private Quaternion openRot;
    private Quaternion closeRot;

    private Coroutine rotateCoroutine;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        closeRot = transform.rotation;
        openRot = closeRot * Quaternion.Euler(0, openAngle, 0);
    }

    void Update()
    {
        float distance = Vector3.Distance(Player.position, DetectPoint.position);
        bool shouldOpen = distance < detectRange && hasKey;

        if (shouldOpen != isOpen)
        {
            isOpen = shouldOpen;
            if (rotateCoroutine != null)
                StopCoroutine(rotateCoroutine);

            rotateCoroutine = StartCoroutine(RotateDoor(isOpen));
        }
    }

    IEnumerator RotateDoor(bool open)
    {
        Quaternion targetRot = open ? openRot : closeRot;

        while (Quaternion.Angle(transform.rotation, targetRot) > 0.1f)
        {
            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                targetRot,
                rotateSpeed * Time.deltaTime
            );

            yield return null;
        }
        transform.rotation = targetRot;
    }

    public void GetKey()
    {
        hasKey = true;
        Debug.Log("获得钥匙");
    }
}