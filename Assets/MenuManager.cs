using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using UnityEngine.Video;
public class MenuManager : MonoBehaviour
{
    public GameObject Options;
    void Start()
    {
    }
    void Update()
    {
    }
    public void clicarplay()
    {
        SceneManager.LoadScene("cena1");
    }
    public void clicaroptions()
    {
        Options.SetActive(true);
    }
    public void clicarback()
    {
        Options.SetActive(false);
    }
}
