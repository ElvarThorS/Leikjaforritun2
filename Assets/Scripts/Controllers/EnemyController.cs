using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;

    public Transform target;
    public NavMeshAgent agent;

    public int health = 100;

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

        if (health <= 0)
        {
            anim.SetBool("Die", true);
            HitCollider.enabled = false;
            anim.SetBool("Attack", false);
            Collider col = GetComponent<CapsuleCollider>();
            col.enabled = false;
        }


        if (health > 0)
        {
            float distance = Vector3.Distance(target.position, transform.position);
            anim.SetBool("Running", false);

            if (distance <= lookRadius)
            {

                agent.SetDestination(target.position);
                //Debug.Log("yeet");

                anim.SetBool("Running", true);



                if (distance <= agent.stoppingDistance)
                {
                    if (isPlayerDead == false)
                    {
                        anim.SetBool("Running", false);
                        Attack();
                        FaceTarget();
                    }

                    if (isPlayerDead == true)
                    {
                        anim.SetBool("Attack", false);
                        anim.SetBool("isPlayerDead", true);

                    }

                }
                if (distance > agent.stoppingDistance) { anim.SetBool("Attack", false); }
            }
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
        anim.SetBool("Attack", true);
    }

    public void AttackEvent()
    {
        HitCollider.enabled = true;
        //Debug.Log("animation event");
    }

    public void StartEatingEvent()
    { anim.SetBool("StartEating", true); }

    public void EnemyDeadEvent()
    { anim.speed = 0; }

    private void TakeDamage(int damage)
    { health -= damage; }



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Event Enemy");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Enemy hits player");
            HealthSystem HS = other.gameObject.GetComponent<HealthSystem>();
            HS.TakeDamage(30);
            HS.UpdateHealthbar();
            if (HS.hitpoint <= 0)
            {
                isPlayerDead = true;
            }
        }
        if (other.gameObject.tag == "Fist" || other.gameObject.tag == "Leg")
        {
            TakeDamage(50);
        }
    }
}