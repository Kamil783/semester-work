using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField]
    int hp;
    [SerializeField]
    public int damage;
    [SerializeField]
    public int resistance;
    [SerializeField]
    public bool isBlocking = false;
    [SerializeField]
    public bool canAttack = true;

    RagdollController ragdoll;
    void Awake() {
        ragdoll = GetComponent<RagdollController>();

    }

    //   [SerializeField]
    // AttackManager manager;
    //  void Awake()
    //   {
    //   manager =gameObject.GetComponent<AttackManager>();
    //  if(manager==null)
    //      Debug.Log("KEKW");

    //  }
    public int HP
    {
        get { return hp; }
    }
    public int GetDamage() {
        return damage;
    }
    public int GetResistance() {
        return resistance;
    }
    public void TakeDamage(int damage) {
        hp -= damage;
        if (hp <= 0){
            hp = 0;
            Death();
        }
    }
    public void Death() {
        if(ragdoll!=null)
            ragdoll.TurnOnRagdoll();
        Destroy(gameObject,10);
    }
}
