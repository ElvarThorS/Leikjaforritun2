using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;

    public Vector3 CameraOffset;

    public bool useOffsetValues;

    public float RotateSpeed;

    public Transform pivot;

    public float maxViewAngle;
    public float minViewAngle;

    public bool invertY;
    void Start ()
    {
        if(!useOffsetValues)
        {
            CameraOffset = target.position - transform.position;
        }

        pivot.transform.position = target.transform.position;
        //pivot.transform.parent = target.transform;
        pivot.transform.parent = null;
        
        //Makes the cursor disappear when in play mode
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {

        pivot.transform.position = target.transform.position;

        //Get the X position of the mouse & rotate the target
        float horizontal = Input.GetAxis("Mouse X") * RotateSpeed;
        pivot.Rotate(0, horizontal, 0);

        //Get the Y position of the mouse & rotate the pivot
        float vertical = Input.GetAxis("Mouse Y") * RotateSpeed;
        //pivot.Rotate(-vertical,0 ,0);
        if (invertY)
        {
            pivot.Rotate(vertical, 0, 0);
        } else
        {
            pivot.Rotate(-vertical, 0, 0);
        }

        //Limit the up/down camera rotation
        if (pivot.rotation.eulerAngles.x > maxViewAngle  && pivot.rotation.eulerAngles.x < 180f)
        {
            pivot.rotation = Quaternion.Euler(maxViewAngle, 0, 0);
        }

        if(pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 360f+minViewAngle)
        {
            pivot.rotation = Quaternion.Euler(360f+minViewAngle, 0, 0);
        }

        float desiredYAngle = pivot.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = target.position - (rotation * CameraOffset);

        if(transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y -.5f, transform.position.z);
        }

        transform.LookAt(target);
    }

    
}
