using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Attack.asset", menuName = "Combat/BaseAttack")]
public class AttackDefinition : ScriptableObject
{
    public float cooldown;
    public float range;
    public float minDamage;
    public float maxDamage;
    public float critMultiplier;
    public float critChance;
    public Attack CreateAttack(CharacterStats attackerStats, CharacterStats defenderStats)
    {
        float coreDamage = attackerStats.GetDamage();
        coreDamage += Random.Range(minDamage,maxDamage);
        bool isCritical = Random.value < critChance;
        if (isCritical)
            coreDamage *= critMultiplier;
        if (defenderStats != null)
            coreDamage -= defenderStats.GetResistance();
        return new Attack((int)coreDamage,isCritical);
    }

}
