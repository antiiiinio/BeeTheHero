using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckVitoriaCena3 : MonoBehaviour
{
    public GameObject textoVitoria;
    public int inimigosvivos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inimigosvivos = GameObject.FindGameObjectsWithTag("Inimigo").Length;
        if (inimigosvivos == 0)
        {
            Time.timeScale = 0;
            textoVitoria.SetActive(true);
            if (Input.GetKey(KeyCode.F))
            {
                    SceneManager.LoadScene("MENU");
            }
        }
    }
}
