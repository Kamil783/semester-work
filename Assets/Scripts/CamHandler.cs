using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamHandler : MonoBehaviour
{
   public Transform camTrans;//камера
   public Transform pivot;//точка над плечом
   public Transform Character;//игрок
   public Transform mTrans;//точка в ногах игрока
   
   public CharStatus status;
   public CamConfig camConfig;
   public bool leftPivot;
   public float delta;
   
   public float mouseX;
   public float mouseY;
   public float lookAngle;
   public float titlAngle;
   
   public Transform targetLook;
   
   void Update(){
	   Tick();
   }
   
   void Tick(){
	   HandlePosition();
	   HandleRotation();
	   //mTrans.position=Character.position;
	   TargetLook();
   }
   void HandlePosition(){
	   float targetX=camConfig.normalX;
	   float targetY=camConfig.normalY;
	   float targetZ=camConfig.normalZ;
	   if(status.isAiming){
		   targetX=camConfig.aimX;
		   targetZ=camConfig.aimZ;
	   }
	   if(leftPivot){
		   targetX=-targetX;
	   }
	   Vector3 newPivotPos=pivot.localPosition;
	   newPivotPos.x=targetX;
	   newPivotPos.y=targetY;
		pivot.localPosition = newPivotPos;
		Vector3 newCamPos=camTrans.localPosition;
	   newCamPos.z=targetZ;
	   camTrans.localPosition=newCamPos;
   }
   void HandleRotation(){
	   mouseX=Input.GetAxis("Mouse X");
	   mouseY=Input.GetAxis("Mouse Y");
	   
	   lookAngle+=mouseX*camConfig.xRotSpeed;
	   titlAngle-=mouseY*camConfig.yRotSpeed;
	   
	   titlAngle=Mathf.Clamp(titlAngle,camConfig.minAngle,camConfig.maxAngle);//чтобы сверху и снизу были ограничения
	   
		mTrans.rotation=Quaternion.Euler(0,lookAngle,0);
	   pivot.localRotation=Quaternion.Euler(titlAngle,0,0);
   }
   void TargetLook(){
	   Ray ray=new Ray(camTrans.position,camTrans.forward*1000);//1000-дальность луча
	   RaycastHit hit;
	   if(Physics.Raycast(ray,out hit)){
		   targetLook.position=Vector3.Lerp(targetLook.position,hit.point,Time.deltaTime*40);// 40-скорость изменения
	   }
	   else{
		   targetLook.position=Vector3.Lerp(targetLook.position,targetLook.transform.forward*1000,Time.deltaTime*40);
	   }
   }   
}
