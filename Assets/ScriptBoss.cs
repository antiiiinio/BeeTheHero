using UnityEngine;

public class ScriptBoss : MonoBehaviour
{
    public Animator animboss;
    GameManager controller;
    public Rigidbody rbinimigo;
    public float forceAmount = 10f;
    public GameObject TiroBossBasico;
    public GameObject TiroBossPesado;
    public int vidaBoss = 1;
    public float OrdemEventos;
    public float Burst = 0.10f;
    public float BurstCD = 1f;
    public Transform shootpointL;
    public Transform shootpointR;

    // Referência ao jogador
    private Transform playerTransform;

    public void Start()
    {
        animboss = GetComponent<Animator>();
        animboss.Play("ChegandoBoss");
        animboss.SetBool("Idle", true);
        animboss.SetBool("Cut", false);
        animboss.SetBool("FireLeft", false);
        animboss.SetBool("FireRigth", false);
        OrdemEventos = -5f;
        rbinimigo = GetComponent<Rigidbody>();
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
        if (OrdemEventos >= 14.9f && OrdemEventos < 18f)
        {
            animboss.SetBool("Idle", true);
            animboss.SetBool("FireLeft", false);
        }
        if (OrdemEventos >= 18f)
        {
            animboss.StopPlayback();
            animboss.Play("IdleBoss");
            animboss.SetBool("Cut", false);
            animboss.SetBool("FireLeft", false);
            animboss.SetBool("FireRigth", false);
            animboss.SetBool("Idle", true);
            OrdemEventos = 0f;
        }
        if (playerTransform != null)
        {
            transform.LookAt(playerTransform);
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
        }
    }
    public void FireLeft()
    {
        if (BurstCD >= Burst)
        {
            BurstCD = 0f;
            Instantiate(TiroBossBasico, shootpointR.position + shootpointR.forward, shootpointR.rotation);
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
    }
    public void DanoTiroPesado(int dano)
    {
        vidaBoss -= dano;
    }
}
