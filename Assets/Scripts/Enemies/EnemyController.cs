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
    public AttackManager amanager;
    CharacterStats stats;
    bool canAttack = true;
    void Start()
    {
        amanager = this.transform.root.gameObject.GetComponent<AttackManager>();
        stats = GetComponent<CharacterStats>();
        anim = GetComponentInChildren<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("Player").transform;
       
    }


    void Update()
    {
        if (stats.HP == 0|| !stats.canAttack)
            return;
        distance = Vector3.Distance(target.position,transform.position);
        if (distance > 10)
        {
            navAgent.enabled = false;
            anim.Play("Idle");
        }
        else {
            if (distance <= 1.4) {
                navAgent.enabled = false;
                if (canAttack&&stats.canAttack)
                {
                    // transform.LookAt(target.transform);
                    RndAttack();
                    
                    amanager.AttackTarget(target.gameObject);
                    StartCoroutine("AttackDelay");
                }
                // transform.LookAt(target.transform);
                //anim.Play("Idle");
                //anim.SetTrigger("light1");

            }
            else
            {
                navAgent.enabled = true;
                navAgent.SetDestination(target.position);
                anim.Play("Walk");
            }
        }
    }
    public IEnumerator AttackDelay()
    {
        
        canAttack = false;
        yield return new WaitForSeconds(2f);
        canAttack = true;
        
    }
    public void RndAttack() {
       int i= Random.Range(0, 2);
       
        if (i==0)
            anim.SetTrigger("light1");
        else
            anim.SetTrigger("light2");
    }
}
