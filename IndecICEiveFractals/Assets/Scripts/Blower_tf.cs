using UnityEngine;

public class Blower_tf : MonoBehaviour
{
    [SerializeField] float z;

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
        z = (transform.position - cam.transform.position).magnitude;

        var v3 = Input.mousePosition;
        v3.z = z;
        v3 = cam.ScreenToWorldPoint(v3);


        transform.position = new Vector3(v3.x, v3.y, 6f);

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

}
