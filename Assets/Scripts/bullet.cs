using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    public float bulletforce = 10;
    public float bulletDamage = 5;

    Enemy ColisionGoomba;
   
   void Awake()
   {
    _rigidBody = GetComponent<Rigidbody2D>();
   }
   
    void Start()
    {
       _rigidBody.AddForce(transform.right * bulletforce, ForceMode2D.Impulse); 
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 8)
        {
            Enemy goomba = collider.gameObject.GetComponent<Enemy>();
            goomba.Die();
            BulletDeath();
        }

        if(collider.gameObject.layer == 3)
        {
            BulletDeath();
        }
    }

    void BulletDeath()
    {
        Destroy(gameObject);
    }
}

