using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotoesCodigo : MonoBehaviour
{
    public GameObject PainelOpcoes;
    public GameObject PainelPausa;
    public bool isPaused = false;
    void Start()
    {
        Time.timeScale = 1;
        PainelPausa.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Continuar();
        }
    }
    public void Continuar()
    {
        isPaused = !isPaused;
        pausado();
    }
    public void Menu()
    {
        SceneManager.LoadScene("MENU");
    }
    public void Opcoes()
    {
        PainelOpcoes.SetActive(true);
    }
    void pausado()
    {
        if (isPaused)
        {
            PainelPausa.SetActive(true);
            Time.timeScale = 0;
        }
        if (!isPaused)
        {
            Time.timeScale = 1;
            PainelPausa.SetActive(false);
            PainelOpcoes.SetActive(false);
        }
    }
}
