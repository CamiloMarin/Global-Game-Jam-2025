using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject btnPausa;
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameObject menuConfig;
    
    public AudioSource musicSource;

    public void Start()
    {
        menuPausa.SetActive(false);
        menuConfig.SetActive(false);
    }
    public void Pausa()
    {
        Time.timeScale = 0f;
        btnPausa.SetActive(false);
        menuPausa.SetActive(true);
        menuConfig.SetActive(false);
    }

    public void Reanudar()
    {
        Time.timeScale = 1f;
        btnPausa.SetActive(true);
        menuPausa.SetActive(false);
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Cerrar()
    {
        menuPausa.SetActive(false);
    }

    public void AbrirMenuConfig()
    {
        menuPausa.SetActive(false);
        menuConfig.SetActive(true);
    }

    public void backMenuPause()
    {
        menuPausa.SetActive(true);
        menuConfig.SetActive(false);
    }

    public void Music()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Play();
        }
        else
    {
            musicSource.Play();
        }
    }
}