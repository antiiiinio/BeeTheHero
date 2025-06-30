using UnityEngine;

public class TutorialPause : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject PainelTutorial;
    void Awake()
    {
        Time.timeScale = 0f;
        Debug.Log("pausou");
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
