using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    bool isDestroyed = false;
    [SerializeField] GameObject questLog, questLogTxt, inventoryTAB;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if(isDestroyed == false){
                questLogTxt.SetActive(false);
                isDestroyed = true;
            }
            SetTabActive(questLog);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            SetTabActive(inventoryTAB);
        }
    }
    public void SetTabActive(GameObject tab){
        tab.SetActive(!tab.activeInHierarchy);
    }
}
