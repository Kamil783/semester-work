using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchDetect : MonoBehaviour
{
    [SerializeField]
    private RagdollController ragdoll;
    public List<Collider> collidingParts = new List<Collider>();
    void OnTriggerEnter(Collider col) {
        if (ragdoll.ragdollParts.Contains(col)&&!col.gameObject.CompareTag("Weapon")) 
        {
            return;
        }

        //  Player_controller control = col.transform.root.GetComponent<Player_controller>();
        //    if (control == null||col.gameObect==control.gameObject)
        //    {
        //      return;
        //}
        AttackManager manager = col.transform.root.gameObject.GetComponentInChildren<AttackManager>();
        if (manager == null)
        {
         //   Debug.Log("части"+col);
           // Debug.Log("корень"+col.transform.root);
            return;
        }
        if (!collidingParts.Contains(col)) {
           
            manager.AttackTarget(this.gameObject);
            collidingParts.Add(col);
        }

    }
    void OnTriggerExit(Collider col) {
        if (collidingParts.Contains(col)) {
            collidingParts.Remove(col);
        }
    }
}
