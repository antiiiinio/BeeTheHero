using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.InputSystem.XR;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Image[] WeaponControl;
    public Image[] ColmeiaControl;
    public Image[] VidaControl;
    public TextMeshProUGUI ControleGameOver;
    public TextMeshProUGUI ControlePontos;
    public int pontos = 0;
    public int VidaPlayer;
    public int Vidacolmeia;
    public int vitoriaderrota;
    public int faseatual;
    public GameObject slider;

    public void Start()
    {
        Vidacolmeia = 3;
        Time.timeScale = 1;
        vitoriaderrota = 0;
        MudarPontos(0);
        VidaPlayer = 6;
        float effSL = PlayerPrefs.GetFloat("effvol");
    }
    public void Update()
    {
        if (VidaPlayer > 6)
        {
            VidaPlayer = 6;
        }
        if (VidaPlayer <= 0)
        {
            Derrota();
        }
        if (Vidacolmeia <= 0)
        {
            Derrota();
        }
        if (pontos < 0)
        {
            SetPontos(0);
        }
        if (vitoriaderrota == 1)
        {
            if (Input.GetKey(KeyCode.R))
            {
                if(faseatual == 1)
                {
                    SceneManager.LoadScene("cena1");
                }
                if (faseatual == 2)
                {
                    SceneManager.LoadScene("cena2");
                }
                if (faseatual == 3)
                {
                    SceneManager.LoadScene("cena3");
                }
            }
        }
        if (vitoriaderrota == 2)
        {
            if (Input.GetKey(KeyCode.F))
            {
                if(faseatual == 1)
                {
                    SceneManager.LoadScene("cena2");
                }
                if (faseatual == 2)
                {
                    SceneManager.LoadScene("cena3");
                }
                if (faseatual == 3)
                {
                    SceneManager.LoadScene("MENU");
                }
            }
        }
    }
    public void MudarPontos(int valor)
    {
        pontos += valor;
        ControlePontos.text = "Score: " + pontos.ToString();
    }
    public void SetPontos(int valor)
    {
        pontos = valor;
        ControlePontos.text = "Score: " + pontos.ToString();
    }
    public void Derrota()
    {
        ControleGameOver.text = "Game Over, Press R to retry.";
        Time.timeScale = 0;
        vitoriaderrota = 1;
    }
    public void Vitoria()
    {
        ControleGameOver.text = "You win!, Press F to proceed";
        Time.timeScale = 0;
        vitoriaderrota = 2;
    }
    public void DanoPlayer(int dano)
    {
        for (int i = 0; i < dano; i++)
        {
            VidaPlayer = VidaPlayer - 1;
            VidaControl[VidaPlayer].gameObject.SetActive(false);
        }
    }
    public void CuraPlayer(int cura)
    {
        for (int i = 0; i < cura; i++)
        {
            VidaControl[VidaPlayer].gameObject.SetActive(true);
            VidaPlayer = VidaPlayer + 1;
        }
    }
    public void DiminuirVidaColmeia()
    {
        Vidacolmeia = Vidacolmeia - 1;
        ColmeiaControl[Vidacolmeia].gameObject.SetActive(false);
        ColmeiaControl[Vidacolmeia+3].gameObject.SetActive(true);
    }
    public void TrocarArma(int value)
    {
        if (value == 1)
        {
            WeaponControl[0].gameObject.SetActive(true);
            WeaponControl[1].gameObject.SetActive(false);
            slider.SetActive(false);
        }
        if (value == 2)
        {
            WeaponControl[0].gameObject.SetActive(false);
            WeaponControl[1].gameObject.SetActive(true);
            slider.SetActive(true);
        }
    }
}