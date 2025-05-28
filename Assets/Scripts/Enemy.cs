using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    float horizontal = 1;
    Animator _animator;
    BoxCollider2D boxCollider;
    Rigidbody2D rBody;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rBody.velocity = new Vector2(horizontal * speed, rBody.velocity.y);
    }

    public void Die()
    {
        _animator.SetBool("IsDead", true);
        boxCollider.enabled = false;
        Destroy(this.gameObject, 0.5f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {            
            PlayerController mario = collision.gameObject.GetComponent<PlayerController>();
            mario.Die();
        }

        if(collision.gameObject.tag == "enemies")
        {
            if(horizontal == 1)
            {
                horizontal = -1;
            }
            else
            {
                horizontal = 1;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "enemies")
        {
            if(horizontal == 1)
            {
                horizontal = -1;
            }
            else
            {
                horizontal = 1;
            }
        }
    }
}
