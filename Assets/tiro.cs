using NUnit.Framework;
using System;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Tiro : MonoBehaviour
{
    public Rigidbody tiro;
    public float forceAmount = 5000f;
    void Start()
    {
        tiro = GetComponent<Rigidbody>();
    }
    void Update()
    {
        tiro.AddForce(Vector3.forward * forceAmount * Time.deltaTime);
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
