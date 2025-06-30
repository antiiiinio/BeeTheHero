using UnityEngine;

public class TutorialPause : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject PainelTutorial;
    void Start()
    {
        if (Time.timeScale == 1f)
        {
        Time.timeScale = 0f; 

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void continuar()
    {
        PainelTutorial.SetActive(false);
        Time.timeScale = 1f;
    }
}
