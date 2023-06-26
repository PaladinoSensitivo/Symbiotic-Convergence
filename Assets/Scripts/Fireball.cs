using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed;
    public Rigidbody Rb;
    //public int damage = 10; //variable of amount of damage dealt
    public float lifeSpan;

    // Start is called before the first frame update
    void Start()
    {
        Rb.velocity = transform.forward * speed;
        Destroy(gameObject, lifeSpan);
    }
    /* void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "TakeDamage")
        {
            GetHit(1);
        }
    }

    //Function to hit the enemy
    public virtual void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemyHit = hitInfo.GetComponent<Enemy>();
        if (enemyHit != null)
        {
            enemyHit.TakeDamage(damage);
            Destroy(gameObject);
        }
    }*/
}
