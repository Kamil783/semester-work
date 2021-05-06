using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRange : MonoBehaviour
{
	public WeaponProporties weaponProp;
	public Transform shotPoint;
	public Transform target;
	
	public GameObject cam;
	public GameObject decal;
	public GameObject bullet;
	
	public GameObject shell;
	public Transform shellPos;
	
	public ParticleSystem flash;
	AudioSource audioS;
	public AudioClip shootC;
	void Start(){
		audioS=GetComponent<AudioSource>();
	}
	
    void Update()
    {
		shotPoint.LookAt(target);
        Vector3 origin=shotPoint.position;
		Vector3 dir=target.position;
		
		//decal.SetActive(false);
		
		//RaycastHit hit;
		Debug.DrawLine(origin,dir,Color.black);
		Debug.DrawLine(cam.transform.position,dir,Color.red);
		/*if(Physics.Linecast(origin,dir,out hit)){
			decal.SetActive(true);
			decal.transform.position=hit.point+hit.normal*0.01f;
			decal.transform.rotation=Quaternion.LookRotation(-hit.normal);
		}*/
    }
	public void Shoot(){
		Instantiate(bullet,shotPoint.position,shotPoint.rotation);
		audioS.PlayOneShot(shootC);
		flash.Play();
		AddShell();
	}
	void AddShell(){
		GameObject newShell=Instantiate(shell);
		newShell.transform.position=shellPos.position;
		newShell.transform.rotation=shellPos.rotation;
		newShell.transform.parent=null;
		newShell.GetComponent<Rigidbody>().AddForce(-newShell.transform.forward*Random.Range(80,120));
		Destroy(newShell,20);
	}
}
