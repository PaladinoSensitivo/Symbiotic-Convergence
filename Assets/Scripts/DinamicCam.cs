using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinamicCam : MonoBehaviour
{
    public GameObject vCamB;

    private void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "CamTrigger":
                vCamB.SetActive(true);
                break;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "CamTrigger":
                vCamB.SetActive(false);
                break;
        }
        
    }
}
