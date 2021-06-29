using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    [SerializeField]
    public List<AttackDefinition> handAttacks;
    AttackDefinition lightAttack;
    AttackDefinition heavyAttack;
    public AttackDefinition curAttack;
    public bool isAttacking;
    public Transform rightHand;
    public Transform leftHand;
    public Transform rightLeg;
    public Transform leftLeg;
    [SerializeField]
    public Weapon curWeapon;
    [SerializeField]
    public GameObject curWeaponPrefab;
    [SerializeField]
    CharacterStats stats;
    [SerializeField]
    CharAnim charAnim;
    [SerializeField]
    RuntimeAnimatorController defaultAnimator;
    
    void Awake()
    {
        stats = GetComponent<CharacterStats>();
        charAnim = GetComponent<CharAnim>();
        HandAttacks();
    }
    public void AttackTarget(GameObject target) {//для изменения атаки сменить curAttack
        
        if (target == null)
            return;
        if (IsFacingTarget(this.transform,target.transform)&& target.GetComponent<CharacterStats>().isBlocking) {
            Debug.Log("блок");
           return;
        }
        
        var attack = curAttack.CreateAttack(stats,target.GetComponent<CharacterStats>());
        var attackables = target.GetComponentsInChildren(typeof(IAttackable));
        
        foreach (IAttackable attackable in attackables) {
            attackable.OnAttack(gameObject,attack);
        }
       
    }
    public bool IsFacingTarget( Transform transform, Transform target, float angle=0.5f) {
        
        var vectorToTarget = target.position - transform.position;
        vectorToTarget.Normalize();
        float dot = Vector3.Dot(transform.forward, vectorToTarget);
        return dot >= angle;
        
    }
    public void LightAttack() {
        curAttack = lightAttack;
    }
    public void HeavyAttack()
    {
        curAttack = heavyAttack;
    }
    public void HandAttacks() {
        lightAttack = handAttacks[0];
        heavyAttack = handAttacks[1];
    }
    public void GetWeapon() {
        var inventory = GetComponent<Inventory>();
        SwapWeapon(inventory.GetWeapon());
    }

    public void SwapWeapon(Weapon weapon) {
        if (weapon == null) {
            HandAttacks();
            return;
        }
        if (curWeaponPrefab == null)
        {
            lightAttack = weapon.lightAttack;
            heavyAttack = weapon.heavyAttack;
            charAnim.anim.runtimeAnimatorController = weapon.animator;
            weaponPickUp(weapon);
        }
        else {
            HandAttacks();
            Destroy(curWeaponPrefab);
            charAnim.anim.runtimeAnimatorController = defaultAnimator;
        }
    }
    void weaponPickUp(Weapon wep)
    {
        Destroy(curWeaponPrefab);
        GameObject w = Instantiate(wep.prefab);
        curWeaponPrefab = w;
        w.transform.parent = rightHand;
        w.transform.localPosition = wep.rHandPos;
        w.transform.rotation = wep.rHandRot;
        
        
        /*
         MeleeWeapon w = characterState.characterControl.animationProgress.HoldingWeapon;

                    w.transform.parent = characterState.characterControl.RightHand_Attack.transform;
                    w.transform.localPosition = w.CustomPosition;
                    w.transform.localRotation = Quaternion.Euler(w.CustomRotation);
         
         */

    }
    #region colliders
    public  IEnumerator LHand() {
       
        var col=leftHand.GetComponent<Collider>();
        Debug.Log("Сработало");
        col.enabled = true;
        yield return new WaitForSeconds(0.3f);
        col.enabled = false;

    }
    
    public IEnumerator RHand()
    {
        var col = rightHand.GetComponent<Collider>();
        col.enabled = true;
        yield return new WaitForSeconds(0.3f);
        col.enabled = false;
    }
    public IEnumerator LLeg()
    {
        var col = leftLeg.GetComponent<Collider>();
        col.enabled = true;
        yield return new WaitForSeconds(0.3f);
        col.enabled = false;
    }
    public IEnumerator RLeg()
    {
        var col = rightLeg.GetComponent<Collider>();
        col.enabled = true;
        yield return new WaitForSeconds(0.8f);
        col.enabled = false;
    }
     


    #endregion
}
