using UnityEngine;

public class CenarioAndaFase3 : MonoBehaviour
{
    public Rigidbody cenario;
    private float forceAmount = 350f;
    void Start()
    {

    }
    private void Update()
    {
        cenario.AddForce(Vector3.back * forceAmount * Time.deltaTime);

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "VoltaCenario")
        {
            cenario.position = new Vector3(cenario.position.x, cenario.position.y, 3480);
        }
    }
}