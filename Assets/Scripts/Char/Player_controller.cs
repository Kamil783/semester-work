using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Player_Motor))]
public class Player_controller : MonoBehaviour
{
	[SerializeField]
	private Player_Motor motor;
	[SerializeField]
	private CharAnim anim;
	//[SerializeField]
	//private CharInput input;

	void Update(){
		anim.AnimationUpdate();
		motor.MoveUpdate();
		//input.InputUpdate();
	}
}
