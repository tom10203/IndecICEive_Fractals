using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public float torque;

    Rigidbody rb;

    void Start()
    {
        Movement();
        rb.AddTorque(transform.up * torque);
    }

    void Update()
    {

    }

    public void Movement()
    {
        rb = GetComponent<Rigidbody>();
        float randomY = Random.Range(-1f, 1f);
        float randomX = Random.Range(-1f, 1f);
        Vector3 velocity = new Vector3(randomX, randomY, 0);
        rb.linearVelocity = velocity * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ceiling") || other.gameObject.CompareTag("Ground"))
        {
            float y = rb.linearVelocity.y;
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, -y, 0);
        }
        else if (other.gameObject.CompareTag("WallLeft") || other.gameObject.CompareTag("WallRight"))
        {
            float x = rb.linearVelocity.x;
            rb.linearVelocity = new Vector3(-x, rb.linearVelocity.y, 0);
        }
    }
}