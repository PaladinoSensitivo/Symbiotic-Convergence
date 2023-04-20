using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    ItemObject itemObj;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            itemObj = FindObjectOfType<ItemObject>();
            itemObj.OnHandlePickupItem();
        }
    }
}
