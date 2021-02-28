using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharAnim : MonoBehaviour
{
    [SerializeField]
	private CharStatus charStatus;
	[SerializeField]
	private Animator anim;
	[SerializeField]
	private Player_Motor motor;
	private float speed;
    public void AnimationUpdate()
    {
		//anim.SetBool("sprint",charStatus.isSprint);
		anim.SetBool("IsAiming",charStatus.isAiming);
		anim.SetBool("IsAimingMove",charStatus.isAimingMove);
        if(charStatus.isAiming){
			AnimRifle();
		}
		else{
			AnimDefoult();
		}
    }
	void AnimDefoult(){
		speed=(float)(Math.Sqrt(Math.Pow(motor.zMov,2)+Math.Pow(motor.xMov,2)));//скорость
		anim.SetFloat("vertical",speed,0.15f,Time.deltaTime);
	}
	void AnimRifle(){
		float h=motor.xMov;
		float v=motor.zMov;
		anim.SetFloat("vertical",v,0.15f,Time.deltaTime);
		anim.SetFloat("horizontal",h,0.15f,Time.deltaTime);
		
	}
}
