using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{

    public AudioSource Player;
    public AudioClip[] audios;
    public AudioMixer mixer;


    public Slider effSL;

    public void PlayAudio(int indice)
    {
        Player.clip = audios[indice];
        Player.Play();
    }

    public void MudarVolume(int indice)
    {
        if (indice == 0)
        {
            mixer.SetFloat("effvol", effSL.value);
        }

    }
    public void SalvarVolume()
    {
        PlayerPrefs.SetFloat("effvol", effSL.value);
        PlayerPrefs.Save();
    }

}