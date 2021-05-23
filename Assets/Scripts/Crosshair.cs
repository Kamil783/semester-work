using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Crosshair : MonoBehaviour
{
	public float aimSpread;
	public float moveSpread;
	public float maxSpread;
	private float currentSpread;
	public float spreadSpeed;
	private float curSpread;
	private float t;
	public Parts[] parts;
	public Player_Motor motor;
	public CharStatus status;
    void Update()
    {	if(motor.xMov!=0||motor.zMov!=0){
		currentSpread=maxSpread*(1+motor.velocity.magnitude/moveSpread);
	}
	else{
		currentSpread=maxSpread;
	}
	if(status.isAiming){
		currentSpread/=aimSpread;
	}
        CrosshairUpdate();
    }
	
	public void CrosshairUpdate(){
		t=0.005f*spreadSpeed;
		curSpread=Mathf.Lerp(curSpread,currentSpread,t);
		for(int i=0;i<parts.Length;i++){
			Parts p=parts[i];
			p.trans.anchoredPosition=p.pos*curSpread;
		}
	}
	[System.Serializable]
	public class Parts{
		public RectTransform trans;
		public Vector2 pos;
	}
}
