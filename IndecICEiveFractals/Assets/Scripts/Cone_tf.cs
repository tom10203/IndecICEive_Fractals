using UnityEngine;

public class Cone_tf : MonoBehaviour
{
    public float force;
    public Vector3 forceVector;
    private void OnTriggerStay(Collider other)
    {
        print($"cone triggerEnter");
        if (other.gameObject.layer == 6)
        {
            Vector3 toTarget = other.transform.position - transform.parent.position;
            forceVector = force * toTarget;

            Rigidbody otherRb = other.GetComponent<Rigidbody>();

            otherRb.AddForce(forceVector);

        }
    }
}
