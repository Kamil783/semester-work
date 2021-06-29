using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BossController : MonoBehaviour
{
    NavMeshAgent navAgent;
    float distance;
    Transform target;
    private Animator anim;
    CharacterStats stats;
    public AttackManager amanager;
    bool canAttack = true;
    bool inCharge = false;
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
        if (stats.HP == 0||inCharge)
            return;
        distance = Vector3.Distance(target.position, transform.position);
        if (distance > 18)
        {
            navAgent.enabled = false;
            inCharge = true;
            StartCoroutine("TpReady");
        }
        else
        {
            if (distance <= 2.5)
            {
                navAgent.enabled = false;
                if (canAttack && stats.canAttack)
                {
                    Debug.Log("Attack");   
                    anim.SetTrigger("light1");
                    StartCoroutine("AttackDelay");
                }
                

            }
            else
            {
                if (distance <= 8)
                {
                    navAgent.enabled = true;
                    navAgent.SetDestination(target.position);
                    anim.Play("Walk");
                }
                else {
                    navAgent.enabled = false;
                    inCharge = true;
                    StartCoroutine("TpReady");
                   
                }
            }
        }
    }
    public IEnumerator AttackDelay()
    {
        canAttack = false;

        yield return new WaitForSeconds(1.5f);
        inCharge = false;
        canAttack = true;
    }
    public IEnumerator TpReady()
    {

        anim.Play("Rage");
        yield return new WaitForSeconds(1f);
        
        StartCoroutine("AttackDelay");
       
      
        Vector3 endpoint = target.position;
        
        TeleportBehind(endpoint);

    }
    void TeleportBehind(Vector3 point)
    {
        
        this.transform.position = point + point.normalized*2;

        transform.LookAt(target.transform);

        anim.SetTrigger("light2");
    }
    public void AttackPlayer() {
        amanager.AttackTarget(target.gameObject);
    }
}
