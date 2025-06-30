using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PowerUpFireRate : MonoBehaviour
{
    public Rigidbody powerupfirerate;
    public float forceAmount = 5000f;
    void Start()
    {
        powerupfirerate = GetComponent<Rigidbody>();
    }
    void Update()
    {
        powerupfirerate.AddForce(-transform.up * forceAmount * Time.deltaTime);
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