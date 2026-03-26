using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : MonoBehaviour
{
    public Transform target;
    public float distance = 5f;
    private float currentX; 
    private float currentY;
    private RaycastHit hitInfo;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        currentX = transform.rotation.x;
        currentY = transform.rotation.y;
    }
    private void Update()
    {
        float h = Input.GetAxis("Mouse X") * 2f;
        float v = Input.GetAxis("Mouse Y") * 2f;
        currentX += h;
        currentY -= v;
        currentY = Mathf.Clamp(currentY, -30, 60);
        transform.rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = transform.rotation * new Vector3(0, 0, distance) + target.position;

        target.rotation = Quaternion.Euler(0, currentX, 0);
        Vector3 dir = transform.position - target.position;
        if(Physics.Raycast(target.position, dir, out hitInfo, distance))
        {
            Debug.Log("" +hitInfo.transform.name);
            transform.position = hitInfo.point;
        }
        Debug.DrawLine(target.position, transform.position, Color.red);
    }
}
