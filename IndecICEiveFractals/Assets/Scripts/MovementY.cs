using Unity.VisualScripting;
using UnityEngine;

public class MovementY : MonoBehaviour
{
    GameObject enemyPrefab;
    public float speed = 5f;
    public float torque = 500f;

    public float positiveY = 20f;
    public float negativeY = 0f;

    public bool moveUp;
    public bool moveDown;

    private Rigidbody rb;
    private void Start()
    {
        moveUp = true;
        rb = GetComponent<Rigidbody>();
        rb.AddTorque(transform.up * torque);

    }
    private void Update()
    {        
        if (moveUp == true)
        {
            MoveUp();
        }

        else
        {
            MoveDown();
        }
    }

    void MoveUp()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
    void MoveDown()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ceiling"))
        {
            moveDown = true;
            moveUp = false;
        }
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            moveDown = false;
            moveUp = true;
        }
    }
}