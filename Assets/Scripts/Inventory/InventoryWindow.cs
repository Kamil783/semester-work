using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class InventoryWindow : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] RectTransform itemsPanel;
    List<GameObject> drawnIcons = new List<GameObject>();
    void Start() {
        inventory.onItemAdded += OnItemAdded;
        Redraw();

    }
    void OnItemAdded(Item obj) => Redraw();
    void Redraw() {
       // Debug.Log("Inventory Redraw called");
        foreach (Item item in inventory.items) {
           // Debug.Log("Redraw called for item");
            var icon = new GameObject("Icon");
            icon.AddComponent<Image>().sprite = item.icon;
            icon.transform.SetParent(itemsPanel);
            drawnIcons.Add(icon);
        }
    }
    void ClearDrawn() {
    foreach (var icon in drawnIcons) {
        Destroy(icon);
    }
    drawnIcons.Clear();
    }
}
