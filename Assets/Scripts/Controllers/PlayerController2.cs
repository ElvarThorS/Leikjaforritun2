using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;
    //public Rigidbody theRB;
    public float jumpForce;
    public CharacterController controller;

    private Vector3 moveDirection;
    public float gravityScale;
    public Animator Anim;
    public Transform pivot;
    public float rotateSpeed;

    public GameObject playerModel;

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

        //moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);
        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore;

        //If player is on the ground he has no gravity pulling on him and he can jump
        if (controller.isGrounded)
        {
            
            moveDirection.y = 0f;
            
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
                
            }
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            moveSpeed = sprintSpeed;
            Anim.SetBool("isSprinting", true);
        }
        if (Input.GetKey(KeyCode.LeftShift) == false || Input.GetKey(KeyCode.W) == false)
        {
            moveSpeed = walkSpeed;
            Anim.SetBool("isSprinting", false);
        }
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);

        //Move the player in different directions based on camera look direction
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }

        //Animation fyrir hreyfingar
        
        Anim.SetBool("WalkingRight", false);
        Anim.SetBool("WalkingLeft", false);
        Anim.SetBool("WalkingBackwards", false);
        Anim.SetBool("WalkingForward", false);


        if (Input.GetKey("w"))
        {
            Anim.SetBool("WalkingForward", true);
        }
        if (Input.GetKey("s"))
        {
            Anim.SetBool("WalkingBackwards", true);
        }
        if (Input.GetKey("a"))
        {
            Anim.SetBool("WalkingLeft", true);
        }
        if (Input.GetKey("d"))
        {
            Anim.SetBool("WalkingRight", true);
        } 

        Anim.SetBool("isGrounded", controller.isGrounded);


    }
}
