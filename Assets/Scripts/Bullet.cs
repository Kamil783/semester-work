using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed;
	public GameObject decal;
	public GameObject metalHitEffect,stoneHitEffect,woodHitEffect,sandHitEffect;
	public GameObject [] meatHitEffect;
	private Vector3 lastPos;
    void Start()
    {
        lastPos=transform.position;
		Destroy(gameObject,5);
    }
    void Update()
    {
        transform.Translate(Vector3.forward*speed*Time.deltaTime);
		
		RaycastHit hit;
		if(Physics.Linecast(lastPos,transform.position,out hit)){
			Debug.DrawLine(lastPos,transform.position,Color.blue);
			Destroy(gameObject);
			if(hit.collider.sharedMaterial!=null){
			string material=hit.collider.sharedMaterial.name;//имя с чем столкнулись
			switch(material){
				case "Metal":
				SpawnDecal(hit,metalHitEffect);
				break;
				case "Sand":
				SpawnDecal(hit,sandHitEffect);
				break;
				case "Stone":
				SpawnDecal(hit,stoneHitEffect);
				break;
				case "Meat":
				SpawnDecal(hit,meatHitEffect[Random.Range(0,meatHitEffect.Length)]);
				break;
				case "Wood":
				SpawnDecal(hit,woodHitEffect);
				break;
				//default:
				//Debug.Log(material);
			}
			}
		}
		
		lastPos=transform.position;
		
    }
	void SpawnDecal(RaycastHit hit,GameObject prefab){
		GameObject sDecal=GameObject.Instantiate(prefab,hit.point,Quaternion.LookRotation(hit.normal));
		sDecal.transform.SetParent(hit.collider.transform);
		Destroy(sDecal.gameObject,10);
	}
}
