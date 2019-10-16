using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float moveSpeed;
    //public Rigidbody theRB;
    public float jumpForce;
    public CharacterController controller;

    private Vector3 moveDirection;
    public float gravityScale;

    void Start()
    {
        //theRB = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //theRB.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, theRB.velocity.y, Input.GetAxis("Vertical") * moveSpeed);

        /*if(Input.GetButtonDown("Jump"))
        {
            theRB.velocity = new Vector3(theRB.velocity.x, jumpForce, theRB.velocity.z);
        }*/

<<<<<<< HEAD
        moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);

        if (controller.isGrounded)
        {
            moveDirection.y = 0;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale*Time.deltaTime);
=======
        moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0f, Input.GetAxis("Vertical") * moveSpeed);

        if(Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpForce;
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);
>>>>>>> 80a142321875d4e1582bd5602ea75234d89cb164
        controller.Move(moveDirection*Time.deltaTime);
    }
}
