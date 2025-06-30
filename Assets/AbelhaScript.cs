using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Video;

public class AbelhaScript : MonoBehaviour
{
    public Animator anim;
    CinemachineImpulseSource controlador;
    GameManager controller;
    public Rigidbody Abelha;
    float forceAmount = 450f;
    float timerVida= 20f;
    public float tempoviva=0f;
    void Start()
    {
        Abelha = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        anim.Play("Idle");
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
            Destroy(gameObject);
            controlador = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<CinemachineImpulseSource>();
            controlador.GenerateImpulse(0.5f);
            controller.MudarPontos(-50);
        }
        if (other.gameObject.tag == "TiroBasico")
        {
            controller = GameObject.FindGameObjectWithTag("interface").gameObject.GetComponent<GameManager>();
            controller.DiminuirVidaColmeia();
            Destroy(gameObject);
            controlador = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<CinemachineImpulseSource>();
            controlador.GenerateImpulse(0.5f);
            controller.MudarPontos(-50);
        }
    }

}
