using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    bool isDestroyed = false;
    [SerializeField] GameObject questLog, questLogTxt, inventoryTAB;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && isActive == false)
        {
            if(isDestroyed == false){
                questLogTxt.SetActive(false);
                isDestroyed = true;
            }
            SetTabActive(questLog);
        }
        else if (Input.GetKeyDown(KeyCode.J) && isActive == true || Input.GetKeyDown(KeyCode.Escape) && isActive == true) 
        {
            SetTabActive(inventoryTAB);
        }
    }
    public void SetTabActive(GameObject tab){
        tab.SetActive(!tab.activeInHierarchy);
    }
}
