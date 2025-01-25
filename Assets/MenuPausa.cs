using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject btnPausa;
    [SerializeField] private GameObject menuPausa;
    

    public void Pausa()
    {
        Time.timeScale = 0f;
        btnPausa.SetActive(false);
        menuPausa.SetActive(true);
    }

    public void Reanudar()
    {
        Time.timeScale = 1f;
        btnPausa.SetActive(true);
        menuPausa.SetActive(false);
    }

    public void Quitar()
    {
        Time.timeScale = 0f;
    }

    public void Config()
    {
        Time.timeScale = 0f;
    }

    public void Musica()
    {
        Time.timeScale = 0f;
    }
}