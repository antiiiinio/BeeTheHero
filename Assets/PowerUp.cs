using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PowerUp : MonoBehaviour
{
    GameManager control;
    public Rigidbody powerup_cura;
    public float forceAmount = 5000f;
    void Start()
    {
        powerup_cura = GetComponent<Rigidbody>();
    }
    void Update()
    {
        powerup_cura.AddForce(transform.forward * forceAmount * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Seguranca")
        {
            Destroy(gameObject);
        }
    }
}
