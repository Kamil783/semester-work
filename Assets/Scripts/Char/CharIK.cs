using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharIK : MonoBehaviour
{
	[SerializeField]
	private CharStatus charStatus;
	[SerializeField]
	private Animator anim;
	[SerializeField]
	private Player_Motor motor;
	[SerializeField]
	private CharInventory invent;
	[SerializeField]
	private Transform targetLook;
	
	public Transform lHand;
	public Transform lHandTarget;
	public Transform rHand;
	
	public float rHWeight;
	public float lHWeight;
	
	public Quaternion lHRot;
	
	public Transform shoulder;
	public Transform aimPivot;
	
    void Start()
    {
		shoulder=anim.GetBoneTransform(HumanBodyBones.RightShoulder).transform;
		aimPivot= new GameObject().transform;
		aimPivot.name="aim pivot";
		aimPivot.transform.parent=transform;
		
		lHand=new GameObject().transform;
		lHand.name="left hand";
		lHand.transform.parent=aimPivot;
		
		rHand=new GameObject().transform;
		rHand.name="right hand";
		rHand.transform.parent=aimPivot;
		rHand.localPosition=invent.firstWeapon.rHandPos;
		rHand.localRotation=Quaternion.Euler(invent.firstWeapon.rHandRot.x,invent.firstWeapon.rHandRot.y,invent.firstWeapon.rHandRot.z);
		
		
    }
    void Update()
    {
        lHRot=lHandTarget.rotation;
		lHand.position=lHandTarget.position;
		if(charStatus.isAiming){
			rHWeight+=Time.deltaTime*2;
			lHWeight+=Time.deltaTime*2;
		}
		else{
			rHWeight-=Time.deltaTime*2;
			lHWeight-=Time.deltaTime*2;
		}
		rHWeight=Mathf.Clamp(rHWeight,0,1);
		lHWeight=Mathf.Clamp(rHWeight,0,1);
    }
	void OnAnimatorIK(){
		aimPivot.position=shoulder.position;
		if(charStatus.isAiming){
			aimPivot.LookAt(targetLook);
			anim.SetLookAtWeight(1f,0.4f,1f);
		}
		else{
			anim.SetLookAtWeight(.3f,.0f,.3f);
		}
		anim.SetLookAtPosition(targetLook.position);
		
		anim.SetIKPositionWeight(AvatarIKGoal.LeftHand,lHWeight);
		anim.SetIKRotationWeight(AvatarIKGoal.LeftHand,lHWeight);
		anim.SetIKPosition(AvatarIKGoal.LeftHand,lHand.position);
		anim.SetIKRotation(AvatarIKGoal.LeftHand,lHRot);
		
		anim.SetIKPositionWeight(AvatarIKGoal.RightHand,rHWeight);
		anim.SetIKRotationWeight(AvatarIKGoal.RightHand,rHWeight);
		anim.SetIKPosition(AvatarIKGoal.RightHand,rHand.position);
		anim.SetIKRotation(AvatarIKGoal.RightHand,rHand.rotation);
	}
}
