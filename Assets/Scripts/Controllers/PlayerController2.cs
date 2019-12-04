using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController2 : MonoBehaviour
{
    public float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;
    public float jumpForce;
    public CharacterController controller;

    int noOfClicks = 0;
    float lastClickedTime = 0;
    float maxComboDelay = 1;

    private Vector3 moveDirection;
    public float gravityScale;
    public Animator Anim;
    public Transform pivot;
    public float rotateSpeed;
    private bool isGrounded;
    public bool isDead = false;

    public GameObject playerModel;

    void Start()
    {
        //theRB = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }
    public float timer = 5;
    void Update()
    {
        /*
        if(Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
        */
        if(isDead == true)
        {
            Anim.SetBool("isDead", true);
            
            
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        

        if (isDead == false)
        {

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

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

                OnClick();

            }

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                Anim.SetBool("Attacking", false);
            }

            if (Time.time - lastClickedTime > maxComboDelay || noOfClicks >= 8)
            {
                noOfClicks = 0;
                Anim.SetBool("Attacking", false);
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

        void OnClick()
        {
            //Record time of last button click
            lastClickedTime = Time.time;
            noOfClicks++;
            Anim.SetBool("Attacking", true);
            if (noOfClicks >= 1 && noOfClicks <= 7)
            {
                Anim.SetInteger("AttackNr", noOfClicks);

            }
            //limit/clamp no of clicks between 0 and 3 because you have combo for 3 clicks
            noOfClicks = Mathf.Clamp(noOfClicks, 0, 8);
        }

        void onCollisionEnter(Collision other)
        {
            if(other.gameObject.tag == "Gate")
            {
                Debug.Log("Kyyyyle");
            }
        }

        

    }

    private void DeadEvent()
    {
        
        Anim.speed = 0;
    }

    
}
