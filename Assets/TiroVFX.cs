using UnityEngine;
using UnityEngine.VFX;

public class TiroVFX : MonoBehaviour
{
    public GameObject TiroVFXNOVO;
    public float timevfx;
    public float timevfxCD;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timevfx = 0.5f;
        timevfxCD = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timevfxCD += Time.deltaTime;
        if (timevfxCD >= timevfx)
        {
            Destroy(gameObject);
        }
    }
}
