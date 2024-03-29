﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    private Animator anim;
    private CharacterStats stats;
    void Awake() {
        stats = GetComponent<CharacterStats>();
        anim = GetComponentInChildren<Animator>();//InChildren если анимации будут в оружии
    }
    public void Block() {
        anim.SetBool("block",true);
    }
    public void EndBlock()
    {
        anim.SetBool("block", false);
    }
    public void Light1() {
        anim.SetTrigger("light1");
    }
    public void Light2()
    {
        anim.SetTrigger("light2");
    }
    public void Light3()
    {
        anim.SetTrigger("light3");
    }
    public void Heavy1()
    {
        anim.SetTrigger("heavy1");
    }
    public void Heavy2()
    {
        anim.SetTrigger("heavy2");
    }
    
    //enemy
    public void EnemyAttack(int type) {
        if (type == 0)
        {
            anim.SetTrigger("light1");
        }
        if (type == 1)
        {

            anim.SetTrigger("light2");
        }
       
    }
    public void PlayIdle()
    {
        anim.Play("Idle");
    }
    public void KnockDown() { 
        anim.SetTrigger("knockDown");
    }

        public void StandUp() {
            anim.SetTrigger("standUp");
        }
    public void Hit(int type) {
        StartCoroutine("HitDelay");
        if (type == 0)
        {
            anim.SetTrigger("hit1");
        }
        if (type == 1)
        {

            anim.SetTrigger("hit2");
        }
        if (type == 2)
        {

            anim.SetTrigger("hit3");
        }

    }

    public IEnumerator HitDelay()
    {

        stats.canAttack = false;
        yield return new WaitForSeconds(2f);
        stats.canAttack = true;

    }

}
