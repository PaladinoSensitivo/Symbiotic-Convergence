using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastFireBall : MonoBehaviour
{
    [SerializeField] GameObject fireBallPf;
    [SerializeField] Transform firePoint;


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
        
    void Shoot()
    {
        Instantiate(fireBallPf, firePoint.position, firePoint.rotation);
    }
}
