using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEditor;





public class Uimanager : MonoBehaviour
{
    public Toggle _toggle;
    public Slider _sliderMenu;
    public Slider _sliderSFX;
    public Button _play;
    public Button _pause;
    public Button _resume;
    public float MusicVol;
   public float SFXVol;
    
    public TMP_Dropdown _difficulty;
    [SerializeField] DifficultySlider _difficultySlider;
  
   


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _difficultySlider = FindFirstObjectByType<DifficultySlider>();

        if (!_difficultySlider.isMenuScene)
        {
            GetComponent<AudioSource>().volume = _difficultySlider.audioVolumeBackground / 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //main menu volume slider and mute toggle

        //Commented out to avoid errors on compile - Guy - reinstate when finished. SFX are now in the audio script SFX attached to the InGameManager to avoid conflicts
        /*
                GetComponent<AudioSource>().volume = _sliderMenu.value / 10;
                GetComponent<AudioSource>().volume = _sliderSFX.value / 10;
                GetComponent<AudioSource>().enabled = _toggle.isOn;


        */

        if ( _difficultySlider.isMenuScene)
        { 
        MusicVol = _sliderMenu.value;
        SFXVol = _sliderSFX.value;

        _difficultySlider.audioVolumeBackground = MusicVol;
        _difficultySlider.audioVolumeSFX = SFXVol;
         }

        else
        {
            GetComponent<AudioSource>().volume = _difficultySlider.audioVolumeBackground / 10;


        }
    }

   

    public void startLevel()
    {

        _difficultySlider = FindFirstObjectByType<DifficultySlider>();
        _difficultySlider.isMenuScene = false;
        //Load game scene from main menu 
        SceneManager.LoadScene(1);


    }

}
