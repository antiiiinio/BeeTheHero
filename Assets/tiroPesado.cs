using NUnit.Framework;
using System;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TiroPesado : MonoBehaviour
{
    public Rigidbody tiroPesado;
    public float forceAmount = 5000f;
    void Start()
    {
        tiroPesado = GetComponent<Rigidbody>();
    }
    void Update()
    {
        tiroPesado.AddForce(Vector3.forward * forceAmount * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Inimigo")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Seguranca")
        {
            Destroy(gameObject);
        }
    }
}
