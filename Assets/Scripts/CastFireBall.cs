using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastFireBall : MonoBehaviour
{
    [SerializeField] GameObject fireBallPf;
    [SerializeField] Transform firePoint;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
        }
    }
        
    void Shoot()
    {
        Instantiate(fireBallPf, firePoint.position, Quaternion.identity);
    }
}
