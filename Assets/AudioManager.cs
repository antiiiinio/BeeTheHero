using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public AudioSource Boss;
    public AudioSource Player;
    public AudioClip[] audios;
    public AudioMixer mixer;


    public Slider effSL;
    public Slider musicSL;
    public void PlayAudio(int indice)
    {
        Player.clip = audios[indice];
        Player.Play();
    }
    public void PlayAudioBoss(int indice)
    {
        Boss.clip = audios[indice];
        Boss.Play();
    }

    public void MudarVolume(int indice)
    {
        if (indice == 0)
        {
            mixer.SetFloat("effvol", effSL.value);
        }
        if (indice == 1)
        {
            mixer.SetFloat("musicvol", musicSL.value);
        }

    }
    public void SalvarVolume()
    {
        PlayerPrefs.SetFloat("effvol", effSL.value);
        PlayerPrefs.SetFloat("musicvol", musicSL.value);
        PlayerPrefs.Save();
    }

}