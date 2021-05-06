using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField]
    int hp;
    [SerializeField]
    public int damage;
    [SerializeField]
    public int resistance;
 //   [SerializeField]
   // AttackManager manager;
  //  void Awake()
 //   {
     //   manager =gameObject.GetComponent<AttackManager>();
      //  if(manager==null)
      //      Debug.Log("KEKW");

  //  }
    public int HP
    {
        get { return hp; }
    }
    public int GetDamage() {
        return damage;
    }
    public int GetResistance() {
        return resistance;
    }

}
