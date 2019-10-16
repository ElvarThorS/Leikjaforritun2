using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;

    public Vector3 CameraOffset;

    public bool useOffsetValues;

    public float RotateSpeed;

    void Start ()
    {
        if(!useOffsetValues)
        {
            CameraOffset = target.position - transform.position;
        }
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Mouse X") * RotateSpeed;
        target.Rotate(0, horizontal, 0);

        float vertical = Input.GetAxis("Mouse Y") * RotateSpeed;
        target.Rotate(-vertical,0 ,0);

        float desiredYAngle = target.eulerAngles.y;
        float desiredXAngle = target.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = target.position - (rotation * CameraOffset);

        transform.LookAt(target);
    }

    
}
