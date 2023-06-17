using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    bool isQuestActive;
    bool isInvenActive;
    bool isDestroyed;
    [SerializeField]GameObject questLog, questLogTxT, inventoryTAB;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            questLog.SetActive(!isQuestActive);
            isQuestActive = !isQuestActive;
            if(questLogTxT == null){
                isDestroyed = true;
                Destroy(questLogTxT);
            }
            else {
                Destroy(questLogTxT);
            }
        }
        if(Input.GetKeyDown(KeyCode.I))
        {
            inventoryTAB.SetActive(isInvenActive);
            isInvenActive = !isInvenActive;
        }
    }

    public void SetQuestActive(){        
        questLog.SetActive(!isQuestActive);
        isQuestActive = !isQuestActive;
    }
    public void SetInvenActive(){
        inventoryTAB.SetActive(!isInvenActive);
        isInvenActive = !isInvenActive;
    }
}
