using UnityEngine;
using UnityEngine.InputSystem.XR;

public class TiroInimigo1 : MonoBehaviour
{
   public Rigidbody tiroinimigo;
    public float forceAmount = 5000f;
    void Start()
    {
        tiroinimigo = GetComponent<Rigidbody>();
    }
    void Update()
    {
        tiroinimigo.AddForce(transform.forward * forceAmount * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
        {
        if (other.gameObject.tag == "Player")
                   {
            Destroy(gameObject);         
                   }    
        if (other.gameObject.tag =="Seguranca")
        {
            Destroy(gameObject);
        }
        }
}
