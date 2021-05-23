using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName="WeaponData",menuName="Combat/Weapon")]
public class Weapon : Item {

    [SerializeField]
    public int damage;
    [SerializeField]
    public int force;
    public RuntimeAnimatorController animator;
	public Vector3 rHandPos;
    public Quaternion rHandRot;
	public Vector3 weaponPos;
	public Vector3 weaponRot;
    public AttackDefinition lightAttack;
    public AttackDefinition heavyAttack;
}
