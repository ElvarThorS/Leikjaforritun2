using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{

    public Collider RightArmCollider;

    private void Start()
    {
        RightArmCollider = RightArmCollider.GetComponent<CapsuleCollider>();
        RightArmCollider.enabled = false;
    }


    private void Update()
    {
       // RightArmCollider.enabled = false;
    }

    public void RightArmPunch(int s)
    {
        Debug.Log("Right punch" + Time.time);
        RightArmCollider.enabled = true;
    }

    public void LeftArmPunch(int s)
    {
        Debug.Log("Shit sem gerðist: " + s + " gerðist:" + Time.time);
    }

    public void RightLegKick(int s)
    {
        Debug.Log("Shit sem gerðist: " + s + " gerðist:" + Time.time);
    }

    public void LeftLegKick(int s)
    {
        Debug.Log("Shit sem gerðist: " + s + " gerðist:" + Time.time);
    }

    private void OnTriggerEnter(Collider other)
    {
        other.enabled = false;
    }
}
