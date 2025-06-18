using UnityEngine;
using System.Collections;
using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.InputSystem.XR;
using UnityEngine.VFX;
using Unity.Cinemachine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    AudioController AudioControl;
    CinemachineImpulseSource controlador;
    GameManager controller;
    public VisualEffect TiroVFXNOVO;
    public Rigidbody rb;
    public float forceAmount = 10f;
    public GameObject tiro;
    public GameObject tirogrande;
    public int VidaPlayer;
    public int armabasica;
    public int armapesada;
    public int armaequipada;


    void Start()
    {
        AudioControl = GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<AudioController>();
        armabasica = 1;
        armaequipada = 1;
        VidaPlayer = 6;
        rb = GetComponent<Rigidbody>();
    }
    public float timerbasico = 1f;
    public float timebasico = 0.15f;
    public float timerpesado = 1f;
    public float timepesado = 1f;
    public float duracao = 10f;
    public float tempoAtivo = 0f;
    void Update()
    {
        if (tempoAtivo >= duracao)
        {
            tempoAtivo = 0f;
            timepesado = 1f;
            timebasico = 0.15f;
        }
        if (tempoAtivo > 0)
        {
            tempoAtivo += Time.deltaTime;
            timepesado = 0.5f;
            timebasico = 0.08f;
        }
        if (armapesada == 0)
        {
            if (armaequipada >= 2)
            {
                armaequipada = 1;
            }
        }
        if (armaequipada >= 3)
        {
            armaequipada = 1;
        }
        if (armaequipada <= 0)
        {
            armaequipada = 2;
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.up * forceAmount * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.down * forceAmount * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * forceAmount * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * forceAmount * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            armaequipada = armaequipada + 1;
            timerpesado = 0f;
            timerbasico = 0f;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            armaequipada = armaequipada - 1;
            timerpesado = 0f;
            timerbasico = 0f;
        }
        timerbasico += Time.deltaTime;
        if (armapesada == 1);
        {
            if (armaequipada == 2)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    timerpesado += Time.deltaTime;
                    if (timerpesado >= timepesado)
                    {
                        Instantiate(TiroVFXNOVO, transform.position + new Vector3(0, 0, 1), transform.rotation);
                    }
                }
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    if (timerpesado >= timepesado)
                    {
                        AudioControl.PlayAudio(1);
                        Atirapesado();
                    }
                    if (timerpesado < timepesado)
                    {
                        timerpesado = 0f;
                    }
                }
            }
        }
        if (armabasica == 1)
        {
            if (armaequipada == 1)
            {
                if (timerbasico >= timebasico)
                {
                    if (Input.GetKey(KeyCode.Space))
                    {
                        Instantiate(TiroVFXNOVO, transform.position + new Vector3(0, -1, 1), transform.rotation);
                        Atirarbasico();
                        AudioControl.PlayAudio(0);
                    }
                }
            }
        }
    }
    public void Atirarbasico()
    {
        Instantiate(tiro, transform.position + new Vector3(0, 0, 1), transform.rotation);

        timerbasico = 0f;
    }
    public void Atirapesado()
    {
        Instantiate(tirogrande, transform.position + new Vector3(0, 0, 2), transform.rotation);

        timerpesado = 0f;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TiroBasicoInimigo")
        {
            controller = GameObject.FindGameObjectWithTag("interface").gameObject.GetComponent<GameManager>();
            controller.DanoPlayer(1);
            controlador = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<CinemachineImpulseSource>();
            controlador.GenerateImpulse(0.2f);
        }
        if (other.gameObject.tag == "TiroBasicoInimigo")
        {
            controller = GameObject.FindGameObjectWithTag("interface").gameObject.GetComponent<GameManager>();
            controller.MudarPontos(-10);
            VidaPlayer = VidaPlayer - 1;
        }
        if (other.gameObject.tag == "CuraPowerUp")
        {
            controller = GameObject.FindGameObjectWithTag("interface").gameObject.GetComponent<GameManager>();
            controller.CuraPlayer(2);
            VidaPlayer = VidaPlayer + 2;
        }
        if (other.gameObject.tag == "PowerUpFireRate")
        {
            tempoAtivo += Time.deltaTime;
        }
    }

}