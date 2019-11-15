using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;

    public Transform target;
    public NavMeshAgent agent;

    public int health = 2;
    
    public Animator anim;
    public float TBA = 1.5f;
    public Collider HitCollider;

    public bool isPlayerDead = false;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        HitCollider = HitCollider.GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        //HitCollider.enabled = false;

        if (health <= 0)
        {
            //deyr
        }



        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {

            agent.SetDestination(target.position);
            //Debug.Log("yeet");

            anim.SetBool("Running", true);



            if (distance <= agent.stoppingDistance)
            {
                if(isPlayerDead == false)
                {
                    anim.SetBool("Running", false);
                    Attack();
                    FaceTarget();
                }

                if(isPlayerDead == true)
                {
                    anim.SetBool("Attack", false);
                    anim.SetBool("isPlayerDead", true);
                    
                }

            }
            if (distance > agent.stoppingDistance) { anim.SetBool("Attack", false); }
        }

    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    void Attack()
    {
        //Time Between Attacks
        //float TBA = 1.5f;

        //TBA -= Time.deltaTime;
        /*
        if (TBA <= 0)
        {
            anim.SetBool("Attack", true);
            TBA = 1.5f;

        }
        */
        anim.SetBool("Attack", true);

    }

    public void AttackEvent()
    {
        HitCollider.enabled = true;
        //Debug.Log("animation event");
    }

    public void StartEatingEvent()
        { anim.SetBool("StartEating", true); }



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerController2 PM = other.gameObject.GetComponent<PlayerController2>();
            PM.Health -= 1;
            if(PM.Health <=0)
            {
                isPlayerDead = true;
            }
        }
         
    }
    
}
