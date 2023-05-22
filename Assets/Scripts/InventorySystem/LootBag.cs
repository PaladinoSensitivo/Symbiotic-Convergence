using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public GameObject itemPrefabDrop;
    public InventoryItemData lootData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void InstantiateLoot(Vector3 spawnPosition)
    {
        GameObject lootGameObject = Instantiate(itemPrefabDrop, spawnPosition, Quaternion.identity);
        lootGameObject.GetComponent<ItemObject>().referenceItem = lootData;
        lootGameObject.GetComponent<ItemObject>().iconObj.GetComponent<SpriteRenderer>().sprite = lootData.icon;

        /*float dropForce = 300f;
        Vector2 dropDirection = new Vector2(Random.Rage(-1f, 1f), Random.Range(-1f, 1f));
        lootGameObject.GetComponent<RigidBody>().AddForce(dropDirection * dropForce);*/
    }
}
