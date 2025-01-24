using TMPro;
using UnityEngine;

public class DifficultySlider : MonoBehaviour
{
    public int difficulty;
    public TMP_Dropdown dropdown;
    public static DifficultySlider instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Update is called once per frame
    void SelectDifficulty()
    {
        difficulty = dropdown.value;
    }
}
