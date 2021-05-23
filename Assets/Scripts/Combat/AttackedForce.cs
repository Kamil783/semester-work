using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackedForce : MonoBehaviour,IAttackable
{
    [SerializeField]
    public float forceToAdd=5f;
    Rigidbody rBody;
    void Awake() {
        rBody = GetComponent<Rigidbody>();
    }
    public void OnAttack(GameObject attacker, Attack attack)
    {
        Debug.Log("Толкнул");
        Vector3 forceDir = transform.position - attacker.transform.position;
        forceDir.y += 0.5f;
        forceDir.Normalize();
        rBody.AddForce(forceDir*forceToAdd);
    }
}
