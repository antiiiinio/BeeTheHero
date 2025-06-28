using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using UnityEngine.Video;
public class MenuManager : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1;
    }
    void Update()
    {

    }
    public void clicarplay()
    {
        SceneManager.LoadScene("cena1");
    }
    public void clicarQuit()
    {
        Application.Quit();
    }
    public void clicarback()
    {
    }
}
