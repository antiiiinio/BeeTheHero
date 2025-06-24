using UnityEngine;
using UnityEngine.Video;

public class AbelhaScript : MonoBehaviour
{
    GameManager controller;
    public Rigidbody Abelha;
    float forceAmount = 450f;
    float timerVida= 20f;
    public float tempoviva=0f;
    void Start()
    {
        Abelha = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Abelha.AddForce(transform.forward * forceAmount * Time.deltaTime);
        tempoviva += Time.deltaTime;
        if (tempoviva >= timerVida)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TiroPesado")
        {
            controller = GameObject.FindGameObjectWithTag("interface").gameObject.GetComponent<GameManager>();
            controller.DiminuirVidaColmeia();
            controller.MudarPontos(-50);
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "TiroBasico")
        {
            controller = GameObject.FindGameObjectWithTag("interface").gameObject.GetComponent<GameManager>();
            controller.DiminuirVidaColmeia();
            controller.MudarPontos(-50);
            Destroy(gameObject);
        }
    }

}
