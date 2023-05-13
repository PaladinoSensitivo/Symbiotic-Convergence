using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    public ParticleSystem fxHit;
    private bool isCut;

    void GetHit(int amount)
    {
        if(isCut == false) 
        {
            isCut = true;
            transform.localScale = new Vector3 (3f, 3f, 3f);
            fxHit.Emit(10);            
        }        
    }
}
