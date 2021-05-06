using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    NavMeshAgent navAgent;
    float distance;
    Transform target;
    private Animator anim;

    void Start()
    {   
        anim= GetComponentInChildren<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("Player").transform;
    }


    void Update()
    {
        distance = Vector3.Distance(target.position,transform.position);
        if (distance > 10)
        {
            navAgent.enabled = false;
            anim.Play("Idle");
        }
        else {
            if (distance <= 1.4) {
                navAgent.enabled = false;
                anim.SetTrigger("light1");
            }
            else
            {
                navAgent.enabled = true;
                navAgent.SetDestination(target.position);
                anim.Play("Walk");
            }
        }
    }
}
