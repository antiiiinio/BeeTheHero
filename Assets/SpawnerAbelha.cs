using UnityEngine;

public class SpawnerAbelha : MonoBehaviour
{
    public float TimerSpawn= 30f;
    public float cooldownSpawn = 0f;
    public GameObject Abelha;
    void Start()
    {
        cooldownSpawn = UnityEngine.Random.Range(0f, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        cooldownSpawn += Time.deltaTime;
        if (cooldownSpawn >= TimerSpawn)
        {
            cooldownSpawn = UnityEngine.Random.Range(0f, 15f);
            Instantiate(Abelha, transform.position + transform.forward, transform.rotation);
        }
    }
}
