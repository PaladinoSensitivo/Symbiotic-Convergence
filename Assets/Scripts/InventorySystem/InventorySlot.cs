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
    GameObject m_stackObj;
    
    [SerializeField]
    TextMeshProUGUI m_stackLabel;
    
    public void Set(InventoryItem item)
    {
        m_icon.sprite = item.data.icon;
        m_label.text = item.data.displayName;
        if(item.stackSize <= 1)
        {
            m_stackObj.SetActive(false);
            return;
        }

        m_stackLabel.text = item.stackSize.ToString();
    }
}
