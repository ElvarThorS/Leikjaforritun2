
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform Target;
    public float FollowSpeed;
    public Vector3 Offset;

    private void FixedUpdate()
    {
        Vector3 GoalPosition = Target.position + Offset;
        Vector3 SmoothedPosition = Vector3.Lerp(transform.position, GoalPosition, FollowSpeed);
        transform.position = SmoothedPosition;

        
    }
}
