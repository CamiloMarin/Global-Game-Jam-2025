using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoPasos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public AudioSource Pasos;
    private void OnCollisionStay2D (Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            Pasos.Play();
        }
    }
}
