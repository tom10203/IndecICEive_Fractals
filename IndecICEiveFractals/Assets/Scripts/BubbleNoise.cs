using UnityEngine;

public class BubbleNoise : MonoBehaviour
{
    public float noiseScaleX = 1f;
    public float noiseScaleY = 1f;
    public float speed = 1f;
    float timer;

    Rigidbody rb;

    public float test;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        timer += Time.deltaTime * speed;
        float perlinX = Mathf.PerlinNoise1D(timer);
        float perlinY = Mathf.PerlinNoise1D(100f + timer);

        perlinX = (perlinX * 2f - 1f) * noiseScaleX;
        perlinY = (perlinY * 2f - 1f) * noiseScaleY;

        print($"perlinX, perlinY {perlinX} {perlinY}");

        transform.position += Vector3.right * perlinX * Time.deltaTime;
        transform.position += Vector3.up * perlinY * Time.deltaTime;

    }
}
