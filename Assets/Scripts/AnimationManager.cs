using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{

    public Collider RightArmCollider;
    public Collider LeftArmCollider;
    public Collider RightLegCollider;
    public Collider LeftLegCollider;

    public EnemyManager EM;
    public bool Hit = false;

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

        Hit = false;
        
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
        Debug.Log("Right punch" + Time.time);
        RightArmCollider.enabled = true;
    }

    public void LeftArmPunch(int s)
    {
        Debug.Log("Left punch" + Time.time);
        LeftArmCollider.enabled = true;
    }

    public void RightLegKick(int s)
    {
        Debug.Log("Right Kick" + Time.time);
        RightLegCollider.enabled = true;
    }

    public void LeftLegKick(int s)
    {
        Debug.Log("Left Kick" + Time.time);
        LeftLegCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        MeshRenderer meshRend = other.GetComponent<MeshRenderer>();
        if(meshRend.material.color == Color.red) { meshRend.material.color = Color.white; }
        else { meshRend.material.color = Color.red; }
        Debug.Log("Hit" + Time.time);

        Hit = true;

        //other.gameObject.SetActive(false);
    }
}
