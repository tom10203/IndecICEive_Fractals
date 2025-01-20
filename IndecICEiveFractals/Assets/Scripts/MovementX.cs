using Unity.VisualScripting;
using UnityEngine;

public class MovementX : MonoBehaviour
{
    public float forceAmount = 10f;
    public float speed = 5f;
    public float xRange = 10f;
    public float zRange = 10f;    
    public float yRange = -10f;
    public Vector3 velocity;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        ApplyForce();
    }
    private void Update()
    {
        velocity = rb.linearVelocity;
    }
    void ApplyForce()
    {        
        rb.AddForce(new Vector3(xRange, yRange, 0) * forceAmount * speed);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("WallLeft"))
        {
            rb.linearVelocity = Vector3.zero;
            rb.AddForce(new Vector3(xRange, yRange, 0) * forceAmount * speed);
        }

        if (collision.gameObject.CompareTag("WallRight"))
        {
            rb.linearVelocity = Vector3.zero;
            rb.AddForce(new Vector3(-xRange, yRange, 0) * forceAmount * speed);
        }
    }

    /*   
    /*void applyforce(vector3 direction)
    {
        rb.addforce(direction * forceamount * speed);
    }

    applyforce(-xrange, yrange,0);
    */

}