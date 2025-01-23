using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;





public class Uimanager : MonoBehaviour
{
    public Toggle _toggle;
    public Slider _sliderMenu;
    public Slider _sliderSFX;
    public Button _play;
    public Button _pause;
    
    public TMP_Dropdown _difficulty;
   


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //main menu volume slider and mute toggle

        GetComponent<AudioSource>().volume = _sliderMenu.value / 10;
        GetComponent<AudioSource>().volume = _sliderSFX.value / 10;
        GetComponent<AudioSource>().enabled = _toggle.isOn;

    }

   

    public void startLevel()
    {
        //Load game scene from main menu 
        SceneManager.LoadScene(1);

    }

}
