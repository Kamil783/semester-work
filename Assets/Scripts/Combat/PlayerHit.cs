using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour,IAttackable
{
    CharacterStats stats;
    PlayerAttack pa;

    void Awake()
    {
        stats = GetComponent<CharacterStats>();
        pa = GetComponent<PlayerAttack>();
    }
    public void OnAttack(GameObject attacker, Attack attack)
    {

        stats.TakeDamage(attack.Damage);
        
        //Debug.LogFormat("{0} attacked {1} for {2} damage.", attacker.name, name, attack.Damage);
        if (pa == null)
            return;

        pa.TakeHit();
    }
}
