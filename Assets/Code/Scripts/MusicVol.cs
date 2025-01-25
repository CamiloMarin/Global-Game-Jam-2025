using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicVol : MonoBehaviour
{
    
    [SerializeField] private AudioMixer audiomixer;

    public void ControlMusica(float slidermusica)
    {
        audiomixer.SetFloat("VolumenMusica", Mathf.Log10(slidermusica) * 20);
    }
}
