using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchDetect : MonoBehaviour
{
    [SerializeField]
    //private RagdollController ragdoll;
    public AttackManager amanager;
    public List<Collider> collidingParts = new List<Collider>();
    void Awake() { 
        amanager= this.transform.root.gameObject.GetComponent<AttackManager>();
    }
    void OnTriggerEnter(Collider col) {
        
        if (!col.gameObject.CompareTag("Enemy"))//&&ragdoll.ragdollParts.Contains(col)) 
        {
            return;
        }
       

        //  Player_controller control = col.transform.root.GetComponent<Player_controller>();
        //    if (control == null||col.gameObect==control.gameObject)
        //    {
        //      return;
        //}
        GameObject target = col.transform.root.gameObject;
        // manager =target.GetComponent<AttackManager>();
       // if (manager == null)
       // {
         //   Debug.Log("части"+col);
           // Debug.Log("корень"+col.transform.root);
           // return;
       // }

        if (!collidingParts.Contains(col)) {
           
            amanager.AttackTarget(target);
            collidingParts.Add(col);
        }

    }
    void OnTriggerExit(Collider col) {
        if (collidingParts.Contains(col)) {
            collidingParts.Remove(col);
        }
    }
}
