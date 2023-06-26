using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public GameObject itemPrefabDrop;
    public InventoryItemData lootData;
    Rigidbody rbItem;
    bool isFalling = false;
    //public Transform playerPos;
    // Start is called before the first frame update
    void Start()
    {
        //InstantiateLoot(playerPos.position);
    }

    public void InstantiateLoot(Vector3 spawnPosition)
    {
        GameObject lootGameObject = Instantiate(itemPrefabDrop, spawnPosition, Quaternion.identity);
        lootGameObject.GetComponent<ItemObject>().referenceItem = lootData;
        lootGameObject.GetComponent<ItemObject>().iconObj.GetComponent<SpriteRenderer>().sprite = lootData.icon;
        
        rbItem = lootGameObject.GetComponent<Rigidbody>();
        rbItem.AddForce(transform.up * 7.0f, ForceMode.Impulse);
        Invoke("Cooldown", 0.5f);

        /*float dropForce = 300f;
        Vector2 dropDirection = new Vector2(Random.Rage(-1f, 1f), Random.Range(-1f, 1f));
        lootGameObject.GetComponent<RigidBody>().AddForce(dropDirection * dropForce);*/
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == 12 && isFalling == true){
            rbItem.useGravity = false;
            rbItem.velocity = Vector3.zero;
        }
    }

    void Cooldown(){
        Debug.Log("esperei o tempo. Ta caindo? " + isFalling);
        isFalling = true;
    }
}
