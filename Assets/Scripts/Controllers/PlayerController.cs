using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float WalkingSpeed = 3f;
    public float RunningSpeed = 6f;
    
    public Animator anim;

    private Rigidbody PlayerRB;
    private Vector3 movement;
    public bool InCombat; 


    private void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
        InCombat = false;
    }

    private void FixedUpdate()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if(InCombat==true)
        {
            Combat();
        }

    
        if(InCombat==false)
            {
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
        
        if(Input.GetKeyDown("space"))
        {
            if(InCombat==true){InCombat=false;}
            
            else{InCombat=true;}
            
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

    private void Combat()
    {
        anim.SetBool("Kick",false);
        anim.SetBool("Combat-Idle",true);
        if(Input.GetKeyDown("e")){anim.SetBool("Kick",true);}

    }
}
