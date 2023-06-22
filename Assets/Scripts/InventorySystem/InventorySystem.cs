using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventorySystem : MonoBehaviour
{
    [SerializeField]
    GameObject slotPrefab;
    [SerializeField]
    Transform slotParent, slotUIParent;
    Dictionary<InventoryItemData, InventoryItem> m_itemDictionary;
    Dictionary<InventoryItemData, InventorySlot> m_bagDictionary;
    public List<InventoryItem> inventory {get; private set;}
    // Start is called before the first frame update
    private void Awake()
    {
        inventory = new List<InventoryItem>();
        m_itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
        m_bagDictionary = new Dictionary<InventoryItemData, InventorySlot>();
    }

    public InventoryItem GetItem(InventoryItemData referenceData)
    {
        if(m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            return value;
        }
        return null;
    }
    public InventorySlot GetSlot(InventoryItemData referenceData){
        if(m_bagDictionary.TryGetValue(referenceData, out InventorySlot value)){
            return value;
        }
        return null;
    }

    public void Add(InventoryItemData referenceData, GameObject referenceObj)
    {
        Debug.Log("Adicionando item: " + referenceData);

        InventoryItem value = GetItem(referenceData);

        if(m_bagDictionary.Count < 35){
            if(value != null)
            {            
                value.AddToStack();
                Debug.Log("Atualizei no Inventario: " + referenceData + " stack: " + value.stackSize);
                InventorySlot slot = GetSlot(referenceData);
                slot.UpdateStack(value.stackSize);
            }
            else
            {
                InventoryItem newItem = new InventoryItem(referenceData);
                inventory.Add(newItem);
                m_itemDictionary.Add(referenceData, newItem);
                GameObject objSlot = Instantiate(slotPrefab, slotParent, false);
                GameObject objSlotUI = Instantiate(slotPrefab, slotParent, false);
                InventorySlot slot = objSlot.GetComponent<InventorySlot>();
                InventorySlot slotUI = objSlot.GetComponent<InventorySlot>();
                m_bagDictionary.Add(referenceData, slot);
                slot.Set(newItem);
                slotUI = slot;
            }
        }

        Destroy(referenceObj);
    }

    public void Remove(InventoryItemData referenceData)
    {
        InventoryItem value = GetItem(referenceData);

        if(value != null)
        {
            value.RemoveFromStack();
            Debug.Log("Removi do Inventario" + referenceData);

            if(value.stackSize == 0)
            {
                inventory.Remove(value);
                m_itemDictionary.Remove(referenceData);
            }
        }
        else
        {
            InventoryItem newItem = new InventoryItem(referenceData);
            inventory.Add(newItem);
            m_itemDictionary.Add(referenceData, newItem);            
        }
    }
}

[Serializable]
public class InventoryItem
{
    public InventoryItemData data {get; private set;}
    public int stackSize {get; private set;}
    public InventorySlot slot;

    public InventoryItem(InventoryItemData source)
    {
        data = source;
        AddToStack();
    }

    public void AddToStack()
    {
        stackSize++;
    }

    public void RemoveFromStack()
    {
        stackSize--;
    }
}