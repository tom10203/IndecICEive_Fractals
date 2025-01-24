using UnityEngine;

public class SFX : MonoBehaviour
{

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clipPop;
    [SerializeField] AudioClip clipGrab;
    [SerializeField] AudioClip clipDrop;
    [SerializeField] DifficultySlider difficultySlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       difficultySlider = FindFirstObjectByType<DifficultySlider>();
        
        audioSource= GetComponent<AudioSource>();
        audioSource.volume = difficultySlider.audioVolumeSFX/10;
    }

    // Update is called once per frame
   
    public void SoundPop()

    {
        
        audioSource.clip = clipPop;
        audioSource.Play();


    }

   public void SoundGrab()

    {

        audioSource.clip = clipGrab;
        audioSource.Play();


    }
   public void SoundDrop()

    {

        audioSource.clip = clipDrop;
        audioSource.Play();


    }

}
