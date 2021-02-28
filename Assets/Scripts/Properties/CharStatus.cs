using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName="Char/status")] 
public class CharStatus : ScriptableObject
{
	public bool isAiming;
	public bool isAimingMove;
	public bool isSprint;
	public bool isSit;
	public bool isGround;
}
