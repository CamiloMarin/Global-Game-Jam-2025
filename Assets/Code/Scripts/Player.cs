using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D _rb; // Componente del rb
    private bool _isGrounded; // bool del suelo

    // Animación ********************************************************************************
    public Animator _animator;

    // Particulas ********************************************************************************
    private ParticleSystem _particleSmokeFx; // particulas de polvo al caer, y al girar el axis
    private ParticleSystem _particleSmokeFx_Jump; // particulas de polvo al saltar

    private bool _doesMyAxisChange = false; // si el axis cambia de 1 a -1 o viseversa este valor es verdadero

    // Velocidad ********************************************************************************
    // Estas variables se utilizan para el movimiento del personaje

    public float _actualVelocity = 5f; // Velocidad del personaje
    public float _jumpForce = 10f; // Fuerza del salto
    [SerializeField] private float _acceleration = 5f;      // Acceleration rate  
    [SerializeField] private float _topSpeed = 5f;         // Maximum speed  
    [SerializeField] private float _deceleration = 10f;    // Deceleration rate  

    // Muerte ************************************************************************************
    // Estas variables se utilizan para implementar la logica de la muerte del personaje

    public bool _isDead = false; // Estado del muerte del personaje

    // Layers ************************************************************************************
    [SerializeField] private bool _is_OnWall_Layer;


    // Start is called before the first frame update
    void Start()
    {
        // Capturamos el elemento del RigidBody 2d
        _rb = GetComponent<Rigidbody2D>();

        // Llamamos al componente ParticleFX
        _particleSmokeFx = transform.GetChild(0).GetComponentInChildren<ParticleSystem>();


        // Llamamos al componente ParticleFX Mientras saltamos
        _particleSmokeFx_Jump = transform.GetChild(1).GetComponentInChildren<ParticleSystem>();

        // Llamamos al componente Animator
        _animator = GetComponent<Animator>();

        // set val _is_OnWall_Layer en falso

        _is_OnWall_Layer = false;
    }




    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        IsTouchingWall();

        // Deja de aplicar fuerza si está tocando una pared de forma horizontal
        if (_is_OnWall_Layer)
        {
            Debug.Log("hola");
            _actualVelocity = 0; // Anula el movimiento horizontal
        }

        // Jump 

        if (!_isDead)
        {
            if (Input.GetKeyDown(KeyCode.W) && _isGrounded)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
                StartParticleAnim_Jump(); // animación de polvo al caer xxxxxxxxxxxxxxxxxx

            }
        }

        // Animaciones del personaje 
        _animator.SetFloat("movement", _actualVelocity); // animación de movimiento

    }

    #region MOVIMIENTO
    // Logica de Movimiento
    private void PlayerMovement()
    {
        if (!_isDead)
        {
             // Movimiento Horizontal
                float _moveInput = Input.GetAxis("Horizontal"); // Las flechas de A/D & Las Flechas Left/Right 

            // Cambio del sprite dependiendo de la dirección
            if (_moveInput > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);

            }
            else if (_moveInput < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);

            }

            if (_moveInput != 0)
            {
                _actualVelocity = Mathf.MoveTowards(_actualVelocity, _moveInput * _topSpeed, _acceleration * Time.deltaTime);

            }
            else
            {
                _actualVelocity = Mathf.MoveTowards(_actualVelocity, 0, _deceleration * Time.deltaTime);
            }


      
                _rb.velocity = new Vector2(_actualVelocity, _rb.velocity.y);
            }
       

    }
    #endregion

    #region COLISIONES 2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Entra en colisión con el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
            _animator.SetBool("isGrounded", true);

        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            CharacterDeath(); // se muere el personaje
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Sale de la colisión con el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
            _animator.SetBool("isGrounded", false);
        }

    }
    #endregion

    #region LOGICA DE MUERTE
    public void CharacterDeath()
    {
        // Terminar el juego
        _isDead = true;
    }
    #endregion

    #region ANIMACIONES PARTICULAS
    public void StartParticleAnim_Dust()
    {
        _particleSmokeFx.Play();

    }


    public void StartParticleAnim_Jump()
    {
        _particleSmokeFx_Jump.Play();
    }
    #endregion

    #region LOGICA DE PAREDES
    // Evita que se aplique una fuerza a una pared

    private void IsTouchingWall()
    {
        /*

        LayerMask _wallLayer = LayerMask.GetMask("wallLayer");
         
        // Dibuja los rayos en la escena para debug
        Debug.DrawRay(transform.position, Vector2.right * 0.8f, Color.red);
        Debug.DrawRay(transform.position, Vector2.left * 0.8f, Color.red);

        RaycastHit2D hit_right = Physics2D.Raycast(transform.position, Vector2.right, 0.8f, _wallLayer); // hacia la derecha
        RaycastHit2D hit_left = Physics2D.Raycast(transform.position, Vector2.left, 0.8f, _wallLayer); // hacia la izquierda

        if (hit_left.collider != null || hit_right.collider != null)
        {
            if (hit_left.collider.gameObject.layer == _wallLayer ||
                hit_right.collider.gameObject.layer == _wallLayer)
            {
                _is_OnWall_Layer = true;
            }
            else
            {
                _is_OnWall_Layer = false;
            }
        }
  
        */
    }

    #endregion

}
