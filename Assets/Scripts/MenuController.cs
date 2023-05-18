using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    bool isActive = false;
    [SerializeField]GameObject questLog;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && isActive == false)
        {
            questLog.SetActive(true);
            isActive = true;
        }
        else if (Input.GetKeyDown(KeyCode.J) && isActive == true || Input.GetKeyDown(KeyCode.Escape) && isActive == true) 
        {
            questLog.SetActive(false);
            isActive = false;
        }
    }
}
