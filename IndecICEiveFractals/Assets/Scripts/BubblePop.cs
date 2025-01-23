using UnityEngine;

public class BubblePop : MonoBehaviour
{
    public bool isPopped = false;
    public ParticleSystem popPS;
    MeshRenderer meshRenderer;
    SphereCollider sphereCollider;
    GameManager gameManager;

    [SerializeField] bool playPS = true;
    [SerializeField] SFX SFX;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        sphereCollider = GetComponent<SphereCollider>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        SFX = FindFirstObjectByType<SFX>().GetComponent<SFX>();
    }
    void Update()
    {
  
        if (isPopped)
        {
            meshRenderer.enabled = false;
            sphereCollider.enabled = false;

            if (playPS)
            {
                gameManager.updateUI(0, -1);
                popPS.Play();
                playPS = false;
                SFX.SoundPop();
            }

           
            
            Destroy(gameObject, 1);
                       
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            isPopped = true;
        }
    }
}
