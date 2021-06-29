using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharInput : MonoBehaviour
{
    [SerializeField]
	private CharStatus charStatus;
	[SerializeField]
	private Weapon weapon;
	public Animator anim;
	public bool canAiming;
	public float forwardDistance; 
	public Transform targetLook;
	public bool DebugAiming;//потом убрать
	public int SelectedWeapon;
	
	void Start(){
		//targetLook=weapon.target;
	}
	
    public void InputUpdate()
    {
		
		AimingRaycast();
		InputAiming();
    }
	public void InputAiming(){
		


		if(Input.GetMouseButton(1)&&canAiming){
			charStatus.isAiming=true;
			charStatus.isAimingMove=true;
		}
		if(Input.GetMouseButton(1)&&!canAiming){
			charStatus.isAiming=false;
			charStatus.isAimingMove=true;
		}
		if(!Input.GetMouseButton(1)){
			charStatus.isAiming=false;
			charStatus.isAimingMove=false;
		}
		if(Input.GetMouseButton(0)){//&&canAiming&&Input.GetMouseButton(1)){
		//	weapon.Shoot();//атака
		}
		if(DebugAiming){
			charStatus.isAiming=true;
			charStatus.isAimingMove=true;
		}
	}
	
	public void AimingRaycast(){
	forwardDistance=Vector3.Distance(transform.position+transform.up*1.4f,targetLook.position);//1.4 -высота персонажа
	if(forwardDistance>1.5f){
		canAiming=true;
	}
	else{
		canAiming=false;
	}
	}
	
	public void InputSwapWeapon(){
		if(!anim.GetBool("isAiming")){
			if(Input.GetKeyDown(KeyCode.Alpha1)&&SelectedWeapon!=1){
				SelectedWeapon=1;
				anim.SetTrigger("WeaponSwap");
			}
			if(Input.GetKeyDown(KeyCode.Alpha2)&&SelectedWeapon!=2){
				SelectedWeapon=2;
				anim.SetTrigger("WeaponSwap");
			}
			if(Input.GetKeyDown(KeyCode.Alpha3)&&SelectedWeapon!=3){
				SelectedWeapon=3;
				anim.SetTrigger("WeaponSwap");
			}
		}
	}
	
	public void SelectWeapon(){
		
	}
}
