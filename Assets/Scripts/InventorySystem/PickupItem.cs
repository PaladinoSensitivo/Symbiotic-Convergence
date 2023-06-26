using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    //public Collider playerCol;
    void OnTriggerEnter(Collider other) {
        if(other.GetComponent<ItemObject>() != null)
        {
            other.GetComponent<ItemObject>().OnHandlePickupItem();
        }
    }
}
