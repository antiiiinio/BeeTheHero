using UnityEngine;

public class TutorialPause : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject PainelTutorial;
    int tutorialativo = 1;
    void Start()
    {
        tutorialativo = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (tutorialativo == 1)
        {
            Time.timeScale = 0;
        }
    }
    public void continuar()
    {
        tutorialativo = 0;
        PainelTutorial.SetActive(false);
        Time.timeScale = 1f;
    }
}
