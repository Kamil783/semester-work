using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    [SerializeField]
    public string name = "item";
    [SerializeField]
    public Sprite icon;
    [SerializeField]
    public GameObject prefab;
    public virtual void OnPickUp() {
        //gameObject.SetActive(false);
    }
    public virtual void OnDrop(Transform transform) {
        Vector3 origin = transform.position;
        Vector3 dir = -Vector3.up;
        float dis = 1.5f;
        RaycastHit hit;
        if (Physics.Raycast(origin, dir, out hit, dis))
        {
            //gameObject.SetActive(true);
           // gameObject.transform.position = hit.point;
        }
    }
}

