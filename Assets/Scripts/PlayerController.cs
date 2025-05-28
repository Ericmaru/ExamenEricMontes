using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variable para la velocidad de movimiento
    public float playerSpeed = 5.5f;
    //Variable para la fuerza del salto
    public float jumpForce = 3f;

    //Variable para acceder al SpriteRenderer
    private SpriteRenderer spriteRenderer;
    //Variable para acceder al RigidBody2D
    private Rigidbody2D _rigidBody;
    //Variable para acceder al GroundSensor
    private GroundSensor sensor;

    //Variable para almacenar el input de movimiento
    float horizontal;

    public Transform BulletSpawn;
    public GameObject BulletPrefab;
    private Animator _animator;

    GameManager gameManager;

    void Awake()
    {
        //Asignamos la variables del SpriteRender con el componente que tiene este objeto
        spriteRenderer = GetComponent<SpriteRenderer>();
        //Asignamos la variable del Rigidbody2D con el componente que tiene este objeto
        _rigidBody = GetComponent<Rigidbody2D>();
        //Buscamos un Objeto por su nombre, cojemos el Componente GroundSensor de este objeto y lo asignamos a la variable
        sensor = GameObject.Find("GroundSensor").GetComponent<GroundSensor>();
        //Buscamos el objeto del GameManager y SFXManager lo asignamos a las variables
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();       

        _animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameOver == true)
        {
            return;
        }    
        
        horizontal = Input.GetAxis("Horizontal");

        if(horizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            _animator.SetBool("IsRunning", true);
           

        }
        else if(horizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _animator.SetBool("IsRunning", true);
            
        }

        if(Input.GetButtonDown("Jump") && sensor.isGrounded)
        {
            _rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _animator.SetBool("IsJumping", true);
        }  

        if(Input.GetButtonDown("Fire1"))
        {

        }      
    }

    void FixedUpdate()
    {
        _rigidBody.velocity = new Vector2(horizontal * playerSpeed, _rigidBody.velocity.y);
    }

    public void Die()
    {
        gameManager.GameOver();
        Destroy(this.gameObject);
        _animator.SetTrigger("IsDead");
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Coin")
        {
            gameManager.AddCoin();
            Destroy(collider.gameObject);
        }
    }


 




}
