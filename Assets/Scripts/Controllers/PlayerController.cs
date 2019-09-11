using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float WalkingSpeed = 3f;
    public float RunningSpeed = 6f;

    private Rigidbody PlayerRB;
    private Vector3 movement;

    private void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if ((Input.GetKey("w") == false) && (Input.GetKey("a") == false) && (Input.GetKey("s") == false) && (Input.GetKey("d") == false))
        {
            PlayerRB.constraints = RigidbodyConstraints.FreezePositionX;
            PlayerRB.constraints = RigidbodyConstraints.FreezePositionZ;
        }

        else
        {
            PlayerRB.constraints = RigidbodyConstraints.None;
            Move(moveHorizontal, moveVertical);
        }
        
        
    }

    private void Move(float moveHorizontal, float moveVertical)
    {
        movement.Set(moveHorizontal, 0f, moveVertical);
        if (Input.GetKey("left shift"))
        {
            movement = movement.normalized * RunningSpeed * Time.deltaTime;
        }
        else
        {
            movement = movement.normalized * WalkingSpeed * Time.deltaTime;
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        PlayerRB.MovePosition(transform.position + movement);
    }
}
