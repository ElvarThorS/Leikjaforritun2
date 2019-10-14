
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform Target;
    public float FollowSpeed;
    public Vector3 Offset;

    public bool CameraSwitch;

    private void start()
    {
        CameraSwitch = false;
    }

    private void FixedUpdate()
    {
        if(CameraSwitch == false)
        { 
            Vector3 GoalPosition = Target.position + Offset;
            Vector3 SmoothedPosition = Vector3.Lerp(transform.position, GoalPosition, FollowSpeed);
            transform.position = SmoothedPosition;
            
        }

        else
        {
            transform.LookAt(Target);
            transform.Translate(Vector3.right * Time.deltaTime);
        
        }
        

        
    }
}
