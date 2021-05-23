using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackedDebug : MonoBehaviour,IAttackable
{
    CharacterStats stats;
    Combat combat;
    
    void Awake (){
        stats = GetComponent<CharacterStats>();
        combat = GetComponent<Combat>();
    }
    public void OnAttack(GameObject attacker, Attack attack) {
        
        stats.TakeDamage(attack.Damage);
        //if (attack.IsCritical) {
         //   Debug.Log("Crit Damage");
       // }
        //Debug.LogFormat("{0} attacked {1} for {2} damage.",attacker.name,name,attack.Damage);
        if (combat == null)
            return;
      
        combat.Hit(Random.Range(0, 3));
    }
}
