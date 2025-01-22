using UnityEngine;

public class BubblePop : MonoBehaviour
{
    bool isPopped = false;
    public ParticleSystem popPS;
    MeshRenderer meshRenderer;
    SphereCollider sphereCollider;

    bool playPS = true;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        sphereCollider = GetComponent<SphereCollider>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isPopped = true;
        }
        if (isPopped)
        {
            meshRenderer.enabled = false;
            sphereCollider.enabled = false;

            if (playPS)
            {
                popPS.Play();
                playPS = false;
            }

            Destroy(gameObject, 1);
                       
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
