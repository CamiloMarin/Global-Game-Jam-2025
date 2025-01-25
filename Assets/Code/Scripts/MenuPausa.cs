using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject btnPausa;
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameObject menuConfig;
    [SerializeField] private GameObject player;

    private Vector3 posicionInicial;
    public AudioSource musicSource;
    private Transform player_transform;

    public void Start()
    {
        menuPausa.SetActive(false);
        menuConfig.SetActive(false);
        player = GameObject.Find("Player");
        player_transform = player.GetComponent<Transform>();
        player_transform.position = posicionInicial;
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
        player_transform.position = posicionInicial;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void VolverMenuPrincipal()
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

    public void Musica()
    {
        Time.timeScale = 0f;
    }
}