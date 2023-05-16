using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    [SerializeField]
    Image m_icon;
    
    [SerializeField]
    TextMeshProUGUI m_label;
    
    [SerializeField]
    TextMeshProUGUI m_stackLabel;
    
    public void Set(InventoryItem item)
    {
        m_icon.sprite = item.data.icon;
        m_label.text = item.data.displayName;
        m_stackLabel.text = item.stackSize.ToString();
    }
    public void UpdateStack(int stackSize){
        m_stackLabel.text = stackSize.ToString();
    }
}