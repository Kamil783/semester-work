using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName="WeaponData",menuName="Combat/Weapon")]
public class Weapon : Item {

    [SerializeField]
    public int damage;
    [SerializeField]
    public int force;
	public Vector3 rHandPos;
	public Vector3 rHandRot;
	public GameObject weaponPrefab;
	public Vector3 weaponPos;
	public Vector3 weaponRot;
}
