using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    Rigidbody rb;

    void Start()
    {
        Movement();
    }

    void Update()
    {
        
    }

    public void Movement()
    {
        rb = GetComponent<Rigidbody>();
        float randomY = Random.Range(-1, 1);
        float randomX = Random.Range(-1, 1);
        Vector3 velocity = new Vector3(randomX, randomY, 0);
        rb.linearVelocity = velocity * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerCall");

        if (other.gameObject.CompareTag("Ceiling") || other.gameObject.CompareTag("Ground"))
        {
            float Y = rb.linearVelocity.y;
            Vector3 velocity = new Vector3(rb.linearVelocity.x, -Y, 0);
        }

        if (other.gameObject.CompareTag("WallLeft") || other.gameObject.CompareTag("WallRight"))
        {
            float X = rb.linearVelocity.x;
            Vector3 velocity = new Vector3(-X, rb.linearVelocity.y, 0);
        }
    }
}
