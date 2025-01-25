using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enlace : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnlaceDeBoton(string enlace)
    {
        Application.OpenURL(enlace);
    }
}
