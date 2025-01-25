using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_SceneController : MonoBehaviour
{
    public GameObject _gameObject_Player;
    private Player _playerScript;
    private bool _doItOnce = false;

    void Start()
    {
        _playerScript = _gameObject_Player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerScript._isDead)
        {
            StopPlayer();
            if (!_doItOnce)
            {
                StartAnim_Death();
                _doItOnce = true;
            }
        }

    }

    //Detener jugador
    void StopPlayer()
    {
        _playerScript._rb.velocity = new Vector2(0, 0);
    }

    void StartAnim_Death()
    {
        _playerScript._animator.SetBool("isDeath", true);
    }


    // Animación de Muerte UI

    // Pasar escena iniciar canvas de muerte


}
