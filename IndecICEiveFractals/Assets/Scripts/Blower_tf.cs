using UnityEngine;

public class Blower_tf : MonoBehaviour
{
    public float z;
    public Camera cam;
    public Transform blower;
    Rigidbody blowerRb;
    public bool stationary = false;
    Vector3 offset;

    private void Start()
    {
        blowerRb = blower.GetComponent<Rigidbody>();
    }
    void Update()
    {
        var v3 = Input.mousePosition;
        v3.z = 10.0f;
        v3 = Camera.main.ScreenToWorldPoint(v3);

        transform.position = v3;

        if (Input.GetMouseButtonDown(0))
        {
            ToggleStationary();
            offset = blower.position - transform.position;
            
        }
        else if (Input.GetMouseButtonUp(0))
        {
            ToggleStationary();
        }

        if (stationary)
        {
            blower.position = transform.position + offset;
        }
    }

    public void MakeBlowerStationary()
    {
        Vector3 offset = blower.position - transform.position;
        blowerRb.isKinematic = true;
    }

    void ToggleStationary()
    {
        stationary = !stationary;
        blowerRb.isKinematic = !blowerRb.isKinematic;
    }

    private void OnTriggerEnter(Collider other)
    {
        print($"trigger enter");
    }
}
