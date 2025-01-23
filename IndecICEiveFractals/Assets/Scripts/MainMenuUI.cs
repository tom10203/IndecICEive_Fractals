using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;





public class Uimanager : MonoBehaviour
{
    public Toggle _toggle;
    public Slider _slider;
    public Button _play;
    public Button _pause;
    public Button _save;
    public Button _load;
    public TMP_Dropdown _difficulty;
    public TMP_InputField _inputField;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //main menu volume slider and mute toggle

        GetComponent<AudioSource>().volume = _slider.value / 10;
        GetComponent<AudioSource>().enabled = _toggle.isOn;

    }

    public void displayText()
    {
        Debug.Log(_inputField.text);
    }

    public void startLevel()
    {
        //Load game scene from main menu 
        SceneManager.LoadScene(1);

    }

}