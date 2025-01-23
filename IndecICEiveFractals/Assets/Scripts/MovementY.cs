using UnityEngine;

public class MovementY : MonoBehaviour
{
    public float speed = 5f;
    public float torque = 500f;

    private Rigidbody rb;
    private bool movingUp = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddTorque(transform.up * torque);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 direction = movingUp ? Vector3.up : Vector3.down;
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ceiling"))
        {
            movingUp = false;
        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            movingUp = true;
        }
    }
}
