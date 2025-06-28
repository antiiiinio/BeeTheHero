using UnityEngine;

public class ScriptTiroBoss : MonoBehaviour
{
    public Rigidbody rbshootpoint;
    private Transform playerTransform;
    void Start()
    {
        rbshootpoint = GetComponent<Rigidbody>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            transform.LookAt(playerTransform);
        }
    }
}
