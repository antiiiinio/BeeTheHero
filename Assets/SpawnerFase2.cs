using UnityEngine;
using UnityEngine.InputSystem.XR;

public class spawnerFase2 : MonoBehaviour

{
    GameManager controller;
    public int wave;
    public int inimigosvivos;
    public GameObject inimigo;
    public GameObject MiniInimigo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;
        wave = 1;
    }
    public float timer = 1f;
    public float time = 10f;
    // Update is called once per frame
    void Update()
    {
        if (timer > time)
        {
            timer = time;
        }
        inimigosvivos = GameObject.FindGameObjectsWithTag("Inimigo").Length;
        timer += Time.deltaTime;
        if (inimigosvivos == 0)
        {
            if (timer >= time)
            {
                if (wave == 1)
                {
                    timer = 0f;
                    Instantiate(inimigo, transform.position + new Vector3(5, 2, 0), transform.rotation);
                    Instantiate(inimigo, transform.position + new Vector3(-5, 2, 0), transform.rotation);
                    Instantiate(inimigo, transform.position + new Vector3(-5, -5, 0), transform.rotation);
                    Instantiate(inimigo, transform.position + new Vector3(0, 7, 0), transform.rotation);
                    Instantiate(inimigo, transform.position + new Vector3(5, -5, 0), transform.rotation);
                    wave++;
                }
            }
        }
        if (inimigosvivos == 0)
        {
            if (timer >= time)
            {
                if (wave == 2)
                {
                    Instantiate(MiniInimigo, transform.position + new Vector3(0, -3, 0), transform.rotation);
                    Instantiate(MiniInimigo, transform.position + new Vector3(0, 0, 0), transform.rotation);
                    Instantiate(MiniInimigo, transform.position + new Vector3(0, 3, 0), transform.rotation);
                    Instantiate(inimigo, transform.position + new Vector3(5, 0, 0), transform.rotation);
                    Instantiate(inimigo, transform.position + new Vector3(-5, 0, 0), transform.rotation);
                    Instantiate(inimigo, transform.position + new Vector3(7, 0, 0), transform.rotation);
                    Instantiate(inimigo, transform.position + new Vector3(-7, 0, 0), transform.rotation);
                    timer = 0f;
                    wave++;
                }
            }
        }
        if (inimigosvivos == 0)
        {
            if (timer >= time)
            {
                if (wave == 3)
                {
                    Instantiate(MiniInimigo, transform.position + new Vector3(0, 3, 0), transform.rotation);
                    Instantiate(MiniInimigo, transform.position + new Vector3(3, 3, 0), transform.rotation);
                    Instantiate(MiniInimigo, transform.position + new Vector3(-3, 3, 0), transform.rotation);
                    Instantiate(MiniInimigo, transform.position + new Vector3(-3, 0, 0), transform.rotation);
                    Instantiate(MiniInimigo, transform.position + new Vector3(3, 0, 0), transform.rotation);
                    Instantiate(MiniInimigo, transform.position + new Vector3(0, 0, 0), transform.rotation);
                    Instantiate(MiniInimigo, transform.position + new Vector3(3, -3, 0), transform.rotation);
                    Instantiate(MiniInimigo, transform.position + new Vector3(0, -3, 0), transform.rotation);
                    Instantiate(MiniInimigo, transform.position + new Vector3(-3, -3, 0), transform.rotation);
                    timer = 0f;
                    wave++;
                }
            }
        }
        if (inimigosvivos == 0)
        {
            if (timer >= time)
            {
                if (wave == 4)
                {
                    Instantiate(inimigo, transform.position + new Vector3(0, 0, 0), transform.rotation);
                    Instantiate(inimigo, transform.position + new Vector3(1, 0, 0), transform.rotation);
                    Instantiate(inimigo, transform.position + new Vector3(2, 0, 0), transform.rotation);
                    Instantiate(inimigo, transform.position + new Vector3(-1, 0, 0), transform.rotation);
                    Instantiate(inimigo, transform.position + new Vector3(-2, 0, 0), transform.rotation);
                    Instantiate(inimigo, transform.position + new Vector3(0, 1, 0), transform.rotation);
                    Instantiate(inimigo, transform.position + new Vector3(2, 1, 0), transform.rotation);
                    Instantiate(inimigo, transform.position + new Vector3(0, 2, 0), transform.rotation);
                    Instantiate(inimigo, transform.position + new Vector3(2, 2, 0), transform.rotation);
                    Instantiate(inimigo, transform.position + new Vector3(-1, 2, 0), transform.rotation);
                    Instantiate(inimigo, transform.position + new Vector3(-2, 2, 0), transform.rotation);
                    Instantiate(inimigo, transform.position + new Vector3(0, -1, 0), transform.rotation);
                    Instantiate(inimigo, transform.position + new Vector3(-2, -1, 0), transform.rotation);
                    Instantiate(inimigo, transform.position + new Vector3(0, -2, 0), transform.rotation);
                    Instantiate(inimigo, transform.position + new Vector3(-2, -2, 0), transform.rotation);
                    Instantiate(inimigo, transform.position + new Vector3(2, -2, 0), transform.rotation);
                    Instantiate(inimigo, transform.position + new Vector3(1, -2, 0), transform.rotation);
                    timer = 0f;
                    wave++;
                }
            }
        }
        if (inimigosvivos == 0)
        {
            if (timer >= time)
            {
                if (wave == 5)
                {
                    controller = GameObject.FindGameObjectWithTag("interface").gameObject.GetComponent<GameManager>();
                    controller.Vitoria();
                }
                wave++;
            }
        }
    }
}