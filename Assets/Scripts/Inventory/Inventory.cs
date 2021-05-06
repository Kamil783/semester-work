using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    public Action<Item> onItemAdded;
    [SerializeField] List<Item> startItems = new List<Item>();
    public List<Item> items = new List<Item>();

    void Awake()
    {

        foreach (Item item in startItems)
        {
            AddItem(item);
        }
    }

    public void AddItem(Item item)
    {
       // Debug.Log("Inventory Item added");
        items.Add(item);
        onItemAdded?.Invoke(item);
    }
}
