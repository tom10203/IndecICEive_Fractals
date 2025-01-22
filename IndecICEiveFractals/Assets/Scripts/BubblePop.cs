using UnityEngine;

public class BubblePop : MonoBehaviour
{
    bool isPopped = false;
    public ParticleSystem popPS;
    MeshRenderer meshRenderer;
    SphereCollider sphereCollider;
    GameManager gameManager;

    bool playPS = true;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        sphereCollider = GetComponent<SphereCollider>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
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
