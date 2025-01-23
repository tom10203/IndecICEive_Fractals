using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject bubblePrefab;
    public Transform spawnPoint;
    public float offset = 2;
    GameObject bubble;

    void Awake()
    {
        bubble = InstantiateBubble();
    }

    // Update is called once per frame
    void Update()
    {
        if (bubble == null)
        {
            bubble = InstantiateBubble();
        }
    }

    GameObject InstantiateBubble()
    {
        return Instantiate(bubblePrefab, spawnPoint.position + Vector3.up * offset, Quaternion.identity);
    }
}
