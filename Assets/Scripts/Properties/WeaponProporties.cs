using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName="Weapon/properties")]
public class WeaponProporties : ScriptableObject
{
    public Vector3 rHandPos;
	public Vector3 rHandRot;
	public GameObject weaponPrefab;
	public Vector3 weaponPos;
	public Vector3 weaponRot;
}
