using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public InventoryItemData referenceItem;
    public InventorySystem invenSystem;    

    public void OnHandlePickupItem()
    {
        invenSystem.Add(referenceItem, this.gameObject);
        //Destroy(gameObject);
    }
}
