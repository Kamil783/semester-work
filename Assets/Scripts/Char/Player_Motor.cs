
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Player_Motor : MonoBehaviour
{
	public Transform CamTrans;
	public CharStatus charStat;
	
	public float xMov=0;
	public float zMov=0;
	public Vector3 movHor=Vector3.zero;
	public Vector3 movVer=Vector3.zero;
	[SerializeField]
	private float speed = 2f;
	
	private float gravityForce=0f;
	private Rigidbody rb;
	public Vector3 velocity=Vector3.zero;
	private Vector3 PlayerDirection=Vector3.zero;//направление игрока
	void Start(){
		rb=GetComponent<Rigidbody>();
	}
	public void Move(){
		xMov = Input.GetAxisRaw("Horizontal");
		zMov = Input.GetAxisRaw("Vertical");
		movHor = CamTrans.right*xMov;
		movVer = CamTrans.forward*zMov;
		velocity = (movHor+movVer).normalized*speed;
		//if(charStat.isAiming)
			//velocity=velocity/2;
		GameGravity();
		velocity.y=gravityForce;
	}
	public void MoveUpdate(){
		Move();
		PerformMove();
		RotationChar();
	}
	
	void PerformMove(){
		rb.MovePosition(rb.position+velocity*Time.deltaTime);
	}
	public void RotationChar(){
		/*if(charStat.isAiming){//eсли целится
			PlayerDirection=CamTrans.forward;
		}
		else{
			PlayerDirection=velocity;
		}*/
		PlayerDirection = velocity;//потом убрать
		PlayerDirection.y=0;
		if(PlayerDirection==Vector3.zero){
			return;
		}
		transform.rotation=Quaternion.LookRotation(PlayerDirection);//не плавно
	}
	public bool IsGround(){
		Vector3 origin=transform.position;
		origin.y+=0.6f;
		Vector3 dir=-Vector3.up;
		float dis=0.7f;
		RaycastHit hit;
		if(Physics.Raycast(origin,dir,out hit,dis)){
			//transform.position= hit.point;
			return true;
		}
		return false;
	}
	private void GameGravity(){
		if(IsGround()){
			gravityForce=0f;
		}
		else{
			gravityForce-=10f*Time.deltaTime;
		}
	}
	
}
