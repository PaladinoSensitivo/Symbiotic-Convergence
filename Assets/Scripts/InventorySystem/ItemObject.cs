using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public InventoryItemData referenceItem;
    public GameObject iconObj;
    public InventorySystem invenSystem;    

    public void OnHandlePickupItem()
    {
        invenSystem = GameObject.Find("Inventory System").GetComponent<InventorySystem>();
        invenSystem.Add(referenceItem, this.gameObject);
        //Destroy(gameObject);
    }
}
