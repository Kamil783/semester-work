using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    [SerializeField]
    public List<AttackDefinition> attacks;
    public AttackDefinition curAttack;
    public bool isAttacking;
    public Transform righHand;
    public Transform leftHand;
    public Transform righLeg;
    public Transform leftLeg;
    [SerializeField]
    CharacterStats stats;
    void Awake()
    {
        stats = GetComponent<CharacterStats>();


    }
    public void AttackTarget(GameObject target) {
        var attack = curAttack.CreateAttack(stats,target.GetComponent<CharacterStats>());
        var attackables = target.GetComponentsInChildren(typeof(IAttackable));
        foreach (IAttackable attackable in attackables) {
            attackable.OnAttack(gameObject,attack);
        }
    }


    void weaponPickUp()
    {


        /*
         MeleeWeapon w = characterState.characterControl.animationProgress.HoldingWeapon;

                    w.transform.parent = characterState.characterControl.RightHand_Attack.transform;
                    w.transform.localPosition = w.CustomPosition;
                    w.transform.localRotation = Quaternion.Euler(w.CustomRotation);
         
         */
    }
}
