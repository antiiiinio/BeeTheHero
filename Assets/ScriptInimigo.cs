using Unity.VisualScripting;
using UnityEngine;
using System;
using UnityEngine.Rendering;

public class ScriptInimigo : MonoBehaviour
{
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
        rbinimigo = GetComponent<Rigidbody>();

        // Encontra o jogador pelo tag "Player"
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        timer = UnityEngine.Random.Range(0f, 2f);
    }

    public float timer = 1f;
    public float time = 5f;
    public float cura = 0f;
    public float cura_cd = 10f;
    public float random = 0f;

    public void Update()
    {
        timer += Time.deltaTime;
        cura += Time.deltaTime;
        if (timer >= time)
        {
            AtirarInimigo();
        }
        if (vidaInimigo <= 0) //droprate de power-up
        {
            random = UnityEngine.Random.Range(0, 100);
            if (random<=50)
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
        Instantiate(tiroinimigo, transform.position + transform.forward, transform.rotation);
        timer = 0f;
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
