using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{

    public Collider RightArmCollider;
    public Collider LeftArmCollider;
    public Collider RightLegCollider;
    public Collider LeftLegCollider;

    
   

    private void Start()
    {
        RightArmCollider = RightArmCollider.GetComponent<CapsuleCollider>();
        RightArmCollider.enabled = false;

        LeftArmCollider = LeftArmCollider.GetComponent<CapsuleCollider>();
        LeftArmCollider.enabled = false;

        RightLegCollider = RightLegCollider.GetComponent<CapsuleCollider>();
        RightLegCollider.enabled = false;

        LeftLegCollider = LeftLegCollider.GetComponent<CapsuleCollider>();
        LeftLegCollider.enabled = false;

      
        
    }


    private void Update()
    {
        RightArmCollider.enabled = false;
        LeftArmCollider.enabled = false;
        RightLegCollider.enabled = false;
        LeftLegCollider.enabled = false;
    }

    public void RightArmPunch(int s)
    {
        // Debug.Log("Right punch" + Time.time);
        RightArmCollider.enabled = true;
    }

    public void LeftArmPunch(int s)
    {
        //Debug.Log("Left punch" + Time.time);
        LeftArmCollider.enabled = true;
    }

    public void RightLegKick(int s)
    {
        //Debug.Log("Right Kick" + Time.time);
        RightLegCollider.enabled = true;
    }

    public void LeftLegKick(int s)
    {
        //Debug.Log("Left Kick" + Time.time);
        LeftLegCollider.enabled = true;
    }
    
    //Fallið sem er kallað á þegar attack hjá spilaranum hittir eitthvað
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hithhhh");
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit enemy");

            EnemyController EC = other.gameObject.GetComponent<EnemyController>();
            EC.health -= 1;

                //other.gameObject.SetActive(false);
        }

        
    }
}
