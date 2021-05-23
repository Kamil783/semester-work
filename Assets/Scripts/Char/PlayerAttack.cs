using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComboState { 
    NONE,
    LIGHT1,
    LIGHT2,
    LIGHT3,
    HEAVY1,
    HEAVY2
}

public class PlayerAttack : MonoBehaviour
{
    bool canAttack=true;
    float AttackDelay = 0.3f;



    bool hit = false;
    bool timerToRes;
    float ResDelay = 0.9f;
    float curTimer;

    ComboState curComboState;
    CharacterStats stats;
    private Combat combat;
    void Awake() {
        stats = GetComponent<CharacterStats>();
        combat = GetComponent<Combat>();
    }
    void Start() {
        curTimer = ResDelay;
        curComboState = ComboState.NONE;
    }
    void Update()
    {
        ComboAttacks();
        ResetComboState();
        if (Input.GetKey(KeyCode.F)) {
            stats.isBlocking = true;
            combat.Block();
        }
        else
        {
            stats.isBlocking = false;
            combat.EndBlock();
        }
    }
    void ComboAttacks() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            if (curComboState == ComboState.LIGHT3 || curComboState == ComboState.HEAVY1 || curComboState == ComboState.HEAVY2||!canAttack)
                return;
            curComboState++;
            timerToRes = true;
            canAttack = false;
            curTimer = ResDelay;
            
            if (curComboState == ComboState.LIGHT1) {
                combat.Light1();
            }
            if (curComboState == ComboState.LIGHT2)
            {
                combat.Light2();
            }
            if (curComboState == ComboState.LIGHT3)
            {
                combat.Light3();
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (!canAttack||curComboState == ComboState.LIGHT3 ||  curComboState == ComboState.HEAVY2)
                return;

            if (!timerToRes) {
                canAttack = false;
                timerToRes = true;
                curTimer = ResDelay;
            }
            if (curComboState == ComboState.LIGHT2 || curComboState == ComboState.NONE)
            {
                curComboState = ComboState.HEAVY1;
            }
            else
            {
                curComboState++;
            }


            if (curComboState == ComboState.HEAVY1)
            {
                combat.Heavy1();
            }
            if (curComboState == ComboState.HEAVY2)
            {
                combat.Heavy2();
            }
        }


    }
    void ResetComboState() {
        if (timerToRes) {
            curTimer -= Time.deltaTime;
            if (curTimer <= 0f)
            {
                curComboState = ComboState.NONE;
                timerToRes = false;
                //curTimer = ResDelay;

            }
            if (!hit)
                if (curTimer < (ResDelay - AttackDelay))
                {
                    canAttack = true;
                }
                else if(curTimer<0) {
                    canAttack = true;
                }
        }
    }
    public  void TakeHit() {
        combat.Hit(Random.Range(0, 2));
        canAttack = false;
        timerToRes = true;
        curTimer = ResDelay;

    }
}
