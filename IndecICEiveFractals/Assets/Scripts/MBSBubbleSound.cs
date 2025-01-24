using UnityEngine;

public class MBSBubbleSound : MonoBehaviour
{

    [SerializeField] AudioSource m_AudioSource;
    [SerializeField] AudioClip audioClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        audioClip = GetComponent<AudioClip>();
        m_AudioSource.Play();
        FnRusiningNoise(0);
    }

    // Update is called once per frame
    public void FnRusiningNoise(float volume)
    {
        m_AudioSource.volume = volume;

    }
}
