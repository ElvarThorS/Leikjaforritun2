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
    public GameObject enemy;
    public Animator anim;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        //anim = GetComponent<Animator>();
    }

    void Update()
    {

        if (health <= 0)
        {
            Destroy(enemy);
        }


        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius)
        {
            anim.SetBool("Running", true);
            agent.SetDestination(target.position);
            Debug.Log("yeet");
            
           
            if (distance <= agent.stoppingDistance)
            {
                anim.SetBool("Running", false);
                anim.SetBool("Attack", true);
                //Attack the target
                FaceTarget();
            }
        }
        anim.SetBool("Attack", false);
    }
    void FaceTarget ()
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

}
