using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.InputSystem.XR;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    public Image[] VidaControl;
    public TextMeshProUGUI ControleGameOver;
    public TextMeshProUGUI ControlePontos;
    public int pontos = 0;
    public int VidaPlayer;
    private bool isPaused = false;

    public void Start()
    {
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
        if (pontos < 0)
        {
            SetPontos(0);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            pausado();
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
        ControleGameOver.text = "Game Over, you lost.";
        Time.timeScale = 0;
    }
    public void Vitoria()
    {
        ControleGameOver.text = "You win!";
        Time.timeScale = 0;
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
        void pausado()
        {
            if (isPaused)
            {
                Time.timeScale = 0;
            }
            if (!isPaused)
            {
                Time.timeScale = 1;
            }
        }

}