using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class CenarioAndando : MonoBehaviour
{
    public Rigidbody cenario;
    private float forceAmount=5000f;
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
            cenario.position = new Vector3(cenario.position.x, cenario.position.y, 1220);
        }
    }
}
