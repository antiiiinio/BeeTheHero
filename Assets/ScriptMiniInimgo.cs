using Unity.VisualScripting;
using UnityEngine;
using System;
using UnityEngine.Rendering;
using Unity.Mathematics;

public class ScriptMiniInimigo : MonoBehaviour
{
    public Animator Minianim;
    GameManager controller;
    public Rigidbody rbinimigo;
    public float forceAmount = 10f;
    public GameObject tiroinimigo;
    public GameObject powerUpFireRate;
    public int vidaInimigo = 5;

    // Referência ao jogador
    private Transform playerTransform;

    public void Start()
    {
        Minianim = GetComponent<Animator>();
        Minianim.Play("ChegandoDrone");
        rbinimigo = GetComponent<Rigidbody>();

        // Encontra o jogador pelo tag "Player"
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        timer = UnityEngine.Random.Range(0f, 2f);
        timer = timer - 1f;
        Minianim.SetBool("Idle", true);
    }

    public float timer = 1f;
    public float time = 5f;
    public float Burst = 0.15f;
    public float BurstCD = 1f;
    public float Random = 0f;

    public void Update()
    {
        BurstCD += Time.deltaTime;
        timer += Time.deltaTime;
        if (timer >= time)
        {
            AtirarInimigo();
        }
        if (vidaInimigo <= 0) //droprate de power-up
        {
            Random = UnityEngine.Random.Range(0, 100);
            if (Random <= 50)
            {
                Instantiate(powerUpFireRate, transform.position + new Vector3(0, 0, 1), transform.rotation);
            }
            controller = GameObject.FindGameObjectWithTag("interface").gameObject.GetComponent<GameManager>();
            controller.MudarPontos(10);
            Destroy(gameObject);
        }

        // Faz o inimigo olhar para o jogador
        if (playerTransform != null)
        {
            transform.LookAt(playerTransform);
        }

    }

    public void AtirarInimigo()
    {
        if (BurstCD >= Burst)
        {
            BurstCD = 0f;
            Instantiate(tiroinimigo, transform.position + transform.forward, transform.rotation);
            if (timer >= 5.3f)
            {
                timer = 0f;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TiroBasico")
        {
            DanoTiroBasico(1);
        }
        if (other.gameObject.tag == "TiroPesado")
        {
            DanoTiroPesado(5);
        }
    }
    public void DanoTiroBasico(int dano)
    {
        vidaInimigo -= dano;
    }
    public void DanoTiroPesado(int dano)
    {
        vidaInimigo -= dano;
    }
}