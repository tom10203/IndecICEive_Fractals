using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject bubblePrefab;
    public Transform spawnPoint;
    public float offset = 2;
    GameObject bubble;

    public GameObject[] enemies;

    void Awake()
    {
        bubble = InstantiateBubble();
    }

    private void Start()
    {
        DifficultySlider difficultySlider = FindFirstObjectByType<DifficultySlider>();
        if (difficultySlider != null)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (i <= difficultySlider.difficulty)
                {
                    enemies[i].SetActive(true);
                }
            }
        }
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
