using UnityEngine;

public class UISound : MonoBehaviour
{
    
    private AudioSource m_AudioSource;

    [SerializeField] private AudioClip hoverSound;
    [SerializeField] private AudioClip clickSound;


    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }


    public void playHoverSound()
    {
        m_AudioSource.PlayOneShot(hoverSound);
    }

    public void playClickSound()
    {
        m_AudioSource.PlayOneShot(clickSound);
    }



}
