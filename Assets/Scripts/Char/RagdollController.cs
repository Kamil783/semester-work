using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    public List<Collider> ragdollParts = new List<Collider>();
    public Animator animator;
    void Awake() {
        animator = this.gameObject.GetComponentInChildren<Animator>();
        SetRagdollParts();
    
    }
    //private IEnumerator Start() {
        //yield return new WaitForSeconds(2f);
      //  TurnOnRagdoll();
    //}
    void SetRagdollParts() {
        Collider[] colliders = this.gameObject.GetComponentsInChildren<Collider>();
        foreach (Collider c in colliders) {
            if (c.gameObject != this.gameObject)
            {
                c.isTrigger = true;
                c.enabled = false;
                ragdollParts.Add(c);
            }
        }
    }
    public void TurnOnRagdoll()
    {
       // Debug.Log("Рагдол");
        animator.enabled = false;
        animator.avatar = null;
        this.gameObject.GetComponent<CapsuleCollider>().enabled=false;
        foreach (Collider c in ragdollParts)
        {
            c.enabled = true;
            c.isTrigger = false;
        }
    }

}
