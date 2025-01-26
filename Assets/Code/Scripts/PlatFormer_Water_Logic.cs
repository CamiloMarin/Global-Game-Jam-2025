using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlatFormer_Water_Logic : MonoBehaviour
{
    // Rotación **********************************************************************************
    [SerializeField] private float _initial_Pos_Z;
    [SerializeField] private float _returnSpeed_Z = 5f; // Velocidad de retorno al valor inicial
    [Space]
    [Space]
    [Space]
    // Transform Vertical ************************************************************************
    [SerializeField] private float _initial_Pos_Y;
    [SerializeField] private float _returnSpeed_Y = 5f; // Velocidad de retorno al valor inicial
    [SerializeField] private float _seconds_to_wait = 1.3f;
    private bool _isTouching_Player = false;

    private void Start()
    {
        _initial_Pos_Z = transform.rotation.eulerAngles.z;
        _initial_Pos_Y = transform.position.y;
    }

    void Update()
    {
        Rotate_Plataform_To_Initial_Rotation_Pos();

        if (_isTouching_Player)
        {
            StartCoroutine("UpStreamAfterTouch");
        }
    }

    // Reorganizar posición inicial despues del contacto con el player
    void Rotate_Plataform_To_Initial_Rotation_Pos()
    {
        // Obtén la rotación actual
        Vector3 currentRotation = transform.rotation.eulerAngles;

        // Interpola suavemente el eje Z hacia el valor inicial
        float _newZ = Mathf.LerpAngle(currentRotation.z, _initial_Pos_Z, _returnSpeed_Z * Time.deltaTime);

        // Sobrescribe solo el valor Z con el inicial
        transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, _newZ);
    }

    // Colisiones
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _isTouching_Player = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _isTouching_Player = false;
        }
    }

    public void Move_Platform_To_Initial_Position()
    {
        // Obtén la posición actual
        Vector3 currentPosition = transform.position;

        // Interpola suavemente el eje Y hacia el valor inicial
        float newY = Mathf.Lerp(currentPosition.y, _initial_Pos_Y, _returnSpeed_Y * Time.deltaTime);

        // Sobrescribe solo el valor Y con el inicial
        transform.position = new Vector3(currentPosition.x, newY, currentPosition.z);
    }

    IEnumerator UpStreamAfterTouch()
    {
        yield return new WaitForSeconds(_seconds_to_wait);
        Move_Platform_To_Initial_Position();
    }
}



