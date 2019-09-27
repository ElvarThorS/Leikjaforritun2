﻿using System.Collections;
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
    public int AttackNr=0;
    public float ComboTimeLeft = 3f;
    


    private void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
        InCombat = false;

    }

    private void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (InCombat == true)
        {
            Combat();
        }


        if (InCombat == false)
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

        if (Input.GetKeyDown("space"))
        {
            if (InCombat == true) { InCombat = false; }

            else { InCombat = true; }

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
        if(AttackNr >6){AttackNr=0;}
        anim.SetInteger("AttackNr", 0);
        CombatCounter();
        anim.SetBool("Combat-Idle", true);
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

    
}
