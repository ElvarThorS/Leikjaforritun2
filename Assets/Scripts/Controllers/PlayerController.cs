<<<<<<< HEAD
﻿using System.Collections;
=======
﻿using System;
using System.Collections;
>>>>>>> bb7521c4f21294206e67d3209d119b2d3d1fc728
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float WalkingSpeed = 3f;
    public float RunningSpeed = 6f;

<<<<<<< HEAD
    private Rigidbody PlayerRB;
    private Vector3 movement;
=======
    public Animator anim;
    public InventoryScript inventory;

    private Rigidbody PlayerRB;
    private Vector3 movement;
    private bool InCombat;
    private int AttackNr=0;
    private float ComboTimeLeft = 3f;
    

>>>>>>> bb7521c4f21294206e67d3209d119b2d3d1fc728

    private void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
<<<<<<< HEAD
=======
        InCombat = false;

>>>>>>> bb7521c4f21294206e67d3209d119b2d3d1fc728
    }

    private void FixedUpdate()
    {
<<<<<<< HEAD
        
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
        
        
=======

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (InCombat == true)
        {
            Combat();
        }


        if (InCombat == false)
        {
            anim.SetBool("InCombat", false);
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

        if (Input.GetKeyDown("space"))
        {
            if (InCombat == true) { InCombat = false; }

            else { InCombat = true; }

        }



>>>>>>> bb7521c4f21294206e67d3209d119b2d3d1fc728
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
<<<<<<< HEAD
=======

    private void Combat()
    {
        if(AttackNr >6){AttackNr=0;}
        anim.SetInteger("AttackNr", 0);
        CombatCounter();
        anim.SetBool("InCombat", true);
        if (Input.GetKeyDown("e"))
        {

            if(ComboTimeLeft > 0) { AttackNr++; }
            anim.SetInteger("AttackNr", AttackNr);
        }
        if(ComboTimeLeft < 0) { AttackNr = 0;}
    }

    private void CombatCounter()
    {
        
        ComboTimeLeft -= Time.deltaTime;
        if (Input.GetKeyDown("e")){ComboTimeLeft = 3f;}
    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        Debug.Log("collider hit");
        InventoryItem item = hit.gameObject.GetComponent<InventoryItem>();
        if (item != null)
        {
            inventory.AddItem(item);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision enter");
        InventoryItem item = collision.gameObject.GetComponent<InventoryItem>();
        if(item != null)
        {
            inventory.AddItem(item);
        }
    }

>>>>>>> bb7521c4f21294206e67d3209d119b2d3d1fc728
}
