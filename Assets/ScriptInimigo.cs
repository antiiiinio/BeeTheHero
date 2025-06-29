using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.Rendering;

public class ScriptInimigo : MonoBehaviour
{
    public AudioClip audio;
    public AudioSource Inimigo;
    public Animator anim;
    GameManager controller;
    public Rigidbody rbinimigo;
    public float forceAmount = 10f;
    public GameObject tiroinimigo;
    public GameObject powerup_cura;
    public int vidaInimigo = 10;

    // Referência ao jogador
    private Transform playerTransform;

    public void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("ChegandoInimigo");
        rbinimigo = GetComponent<Rigidbody>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        timer = UnityEngine.Random.Range(0f, 2f);
        timer = timer - 1f;
    }

    public float timer;
    float time = 5f;
    public float cura = 0f;
    public float cura_cd = 10f;
    public float random = 0f;

    public void Update()
    {
        timer += Time.deltaTime;
        cura += Time.deltaTime;
        if (timer < 4f)
        {
            anim.SetBool("Idle", true);
            anim.SetBool("Ataque", false);
        }
        if (timer >= 4.5f)
        {
            anim.SetBool("Idle", false);
            anim.SetBool("Ataque", true);
        }
        if (timer >= 5f)
        {
            AtirarInimigo();
            timer = 0f;
        }
        if (vidaInimigo <= 0) //droprate de power-up
        {
            random = UnityEngine.Random.Range(0, 100);
            if (random <= 50)
            {
                if (cura >= cura_cd)
                {
                    cura = 0f;
                    Instantiate(powerup_cura, transform.position + new Vector3(0, 0, 1), transform.rotation);

                }
            }
            controller = GameObject.FindGameObjectWithTag("interface").gameObject.GetComponent<GameManager>();
            controller.MudarPontos(15); //mudança de pontos
            Destroy(gameObject);
        }

        // Faz o inimigo olhar para o jogador
        if (playerTransform != null)
        {
            transform.LookAt(playerTransform);
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
    public void AtirarInimigo()
    {
        Instantiate(tiroinimigo, transform.position + new Vector3(0, -1, 0), transform.rotation);
        PlayAudioInimigo();
    }
    public void DanoTiroBasico(int dano)
    {
        vidaInimigo -= dano;
    }
    public void DanoTiroPesado(int dano)
    {
        vidaInimigo -= dano;
    }
    public void PlayAudioInimigo()
    {
        Inimigo.clip = audio;
        Inimigo.Play();
    }
}