using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_SceneController : MonoBehaviour
{
    public GameObject _player;
    public Player _playerScript;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_playerScript._isDead)
        {
            Debug.Log("fuck");
            _playerScript._isDead = false;
        }
       
    }
    //Detener jugador
}
