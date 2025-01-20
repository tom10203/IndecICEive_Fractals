using UnityEngine;

public class Blower_tf : MonoBehaviour
{
    public float z;
    public Camera cam;
    public Transform blower;
    Rigidbody blowerRb;
    public bool stationary = false;
    Vector3 offset;
    bool setOffset = true;

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

        if (Input.GetMouseButton(0))
        {
            stationary = true;
            blowerRb.isKinematic = true;
            if (setOffset)
            {
                offset = blower.position - transform.position;
                setOffset = false;
            }
            
        }
        else
        {
            stationary = false;
            blowerRb.isKinematic = false;
            setOffset = true;
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
