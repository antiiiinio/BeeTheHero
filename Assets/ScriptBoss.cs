using UnityEngine;
using UnityEngine.UI;

public class ScriptBoss : MonoBehaviour
{
    AudioController AudioControl;
    public Animator animboss;
    GameManager controller;
    public Rigidbody rbinimigo;
    public float forceAmount = 10f;
    public GameObject TiroBossBasico;
    public GameObject TiroBossPesado;
    public int vidaBoss;
    int vidamaximaboss = 500;
    float OrdemEventos;
    float Burst = 0.10f;
    float BurstCD = 1f;
    public Transform shootpointL;
    public Transform shootpointR;
    Transform playerTransform;
    Vector3 lookPlayer;
    public Slider barraVidaDireita;
    public Slider barraVidaEsquerda;

    public void Start()
    {
        vidaBoss = vidamaximaboss;
        barraVidaDireita.maxValue = vidamaximaboss;
        barraVidaDireita.value = vidaBoss;
        barraVidaEsquerda.maxValue = vidamaximaboss;
        barraVidaEsquerda.value = vidaBoss;
        animboss = GetComponent<Animator>();
        animboss.Play("ChegandoBoss");
        animboss.SetBool("Idle", true);
        animboss.SetBool("Cut", false);
        animboss.SetBool("FireLeft", false);
        animboss.SetBool("FireRigth", false);
        OrdemEventos = -5f;
        rbinimigo = GetComponent<Rigidbody>();
        AudioControl = GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<AudioController>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }
    void Update()
    {
        BurstCD += Time.deltaTime;
        OrdemEventos += Time.deltaTime;
        if (OrdemEventos < 0f)
        {
            animboss.SetBool("Idle", true);
            animboss.SetBool("Cut", false);
            animboss.SetBool("FireLeft", false);
            animboss.SetBool("FireRigth", false);
        }
        if (OrdemEventos >= 3f && OrdemEventos < 5.5f)
        {
            animboss.SetBool("Idle", false);
            animboss.SetBool("Cut", true);
        }
        if (OrdemEventos >= 8f && OrdemEventos < 10f)
        {
            animboss.SetBool("Idle", false);
            animboss.SetBool("FireRigth", true);
        }
        if (OrdemEventos >= 9f && OrdemEventos < 10f)
        {
            FireRigth();
        }
        if (OrdemEventos >= 13f && OrdemEventos < 14.9f)
        {
            animboss.SetBool("Idle", false);
            animboss.SetBool("FireLeft", true);
        }
        if (OrdemEventos >= 14.1f && OrdemEventos < 14.15f)
        {
            FireLeft();
        }
        if (OrdemEventos >= 5.5f && OrdemEventos < 8f)
        {
            animboss.SetBool("Idle", true);
            animboss.SetBool("Cut", false);
        }
        if (OrdemEventos >= 10f && OrdemEventos < 13f)
        {
            animboss.SetBool("Idle", true);
            animboss.SetBool("FireRigth", false);
        }
        if (OrdemEventos >= 14.9f && OrdemEventos < 16f)
        {
            animboss.SetBool("Idle", true);
            animboss.SetBool("FireLeft", false);
        }
        if (OrdemEventos >= 16f)
        {
            animboss.StopPlayback();
            animboss.Play("IdleBoss");
            OrdemEventos = 0f;
        }
        if (playerTransform != null)
        {
            lookPlayer = new Vector3(playerTransform.position.x, playerTransform.position.y - 5, playerTransform.position.z);
            transform.LookAt(lookPlayer);
        }
        if (vidaBoss <=0)
        {
            animboss.SetBool("Idle", false);
            animboss.SetBool("Cut", false);
            animboss.SetBool("FireLeft", false);
            animboss.SetBool("FireRigth", false);
            animboss.StopPlayback();
            animboss.Play("DeathBoss");
            Destroy(gameObject, 5f);
            OrdemEventos = 0f;
        }
    }
    public void FireRigth()
    {
        if (BurstCD >= Burst)
        {
            BurstCD = 0f;
            Instantiate(TiroBossBasico, shootpointL.position + shootpointL.forward, shootpointL.rotation);
            AudioControl.PlayAudioBoss(2);
        }
    }
    public void FireLeft()
    {
        if (BurstCD >= Burst)
        {
            BurstCD = 0f;
            Instantiate(TiroBossPesado, shootpointR.position + shootpointR.forward, shootpointR.rotation);
            AudioControl.PlayAudioBoss(2);
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
        vidaBoss -= dano;
        barraVidaDireita.value = vidaBoss;
        barraVidaEsquerda.value = vidaBoss;
    }
    public void DanoTiroPesado(int dano)
    {
        vidaBoss -= dano;
        barraVidaDireita.value = vidaBoss;
        barraVidaEsquerda.value = vidaBoss;
    }
}
