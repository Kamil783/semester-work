using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    public Action<Item> onItemAdded;
    [SerializeField] List<Item> startItems = new List<Item>();
    public List<Item> items = new List<Item>();
    int slots = 8;

    void Awake()
    {

        foreach (Item item in startItems)
        {
            AddItem(item);
        }
    }

    public void AddItem(Item item)
    {
        if (items.Count >= slots)
            return;

        //Collider col=(item as MonoBehavior).GetComponent<Collider>();
        //if(col.enabled)
        //col.enabled=false;
        //item.OnPickUp();
       // Debug.Log("Inventory Item added");
        items.Add(item);
        onItemAdded?.Invoke(item);
    }
    public Weapon GetWeapon() {
        return items[1] as Weapon;
    
    }
}
