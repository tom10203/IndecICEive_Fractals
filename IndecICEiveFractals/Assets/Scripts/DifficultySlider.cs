using TMPro;
using UnityEngine;

public class DifficultySlider : MonoBehaviour
{
    public int difficulty;
    public TMP_Dropdown dropdown;
    
    public static DifficultySlider instance;
    public float audioVolumeBackground;
    public float audioVolumeSFX;
    [SerializeField] Uimanager Uimanager;
    public bool isMenuScene=true;
   
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
    public void SelectDifficultyNew()
    {
        difficulty = dropdown.value;
      
        //Uimanager = FindFirstObjectByType<Uimanager>();

        //audioVolumeBackground = Uimanager.MusicVol;
        //audioVolumeSFX = Uimanager.SFXVol;

      
    }
}
