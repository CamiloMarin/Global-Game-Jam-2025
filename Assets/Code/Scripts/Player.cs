using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float _velocity = 5f; // Velocidad del personaje
    public float _jumpForce = 10f; // Fuerza del salto
    private Rigidbody2D _rb; // Componente del rb
    private bool _isGrounded; // bool del suelo

    

    // Start is called before the first frame update
    void Start()
    {
        // Capturamos el elemento del RigidBody 2d
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movimiento Horizontal
        float _moveInput = Input.GetAxis("Horizontal"); // Las flechas de A/D & Las Flechas Left/Right 
        _rb.velocity = new Vector2(_moveInput * _velocity, _rb.velocity.y);

        // Cambio del sprite dependiendo de la dirección
        if (_moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (_moveInput < 0)
        {
            transform.localScale = new Vector3(-1,1,1);
        }

        // Jump 
        if (Input.GetKeyDown(KeyCode.W) && _isGrounded)
        {
            
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
            Debug.Log("True");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
            Debug.Log("False"); //
        }

    }

    public void CharacterDeath()
    {
        // Terminar el juego
    }
}
