using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisChangeDetector : MonoBehaviour

    // Este script detecta el cambio del axis para implementar logicas en la camara y en las animaciones de particulas
{
    private Vector3 _previusScale; // Nuevo Vector 3

    private Player _player_Script; // Ref del elemento del player

    [SerializeField] private CameraFollow _cameraFollow_Script;

    void Start()
    {
        _previusScale = transform.localScale;
        _player_Script = gameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localScale != _previusScale)
        {
            // ha cambiado de axis el objeto

            _cameraFollow_Script._offset = new Vector3 (_cameraFollow_Script._offset.x * -1, _cameraFollow_Script._offset.y, _cameraFollow_Script._offset.z);
     


            _player_Script.StartParticleAnim_Dust(); // animacion de polvo
            _previusScale = transform.localScale; // Actualizamos valor
        }
    }
}
