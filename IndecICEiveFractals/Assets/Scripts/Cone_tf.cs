using UnityEngine;

public class Cone_tf : MonoBehaviour
{
    public float force;
    public Vector3 forceVector;
    [SerializeField] GuyBubble GuyBubble;

    private void Start()
    {
        GuyBubble = FindFirstObjectByType<GuyBubble>().GetComponent<GuyBubble>();
    }

    private void OnTriggerStay(Collider other)
    {
        print($"cone triggerEnter");
        if (other.gameObject.layer == 6)
        {
            Vector3 toTarget = other.transform.position - transform.parent.position;
            float DistanceToTarget = toTarget.magnitude;   
            if (DistanceToTarget <1)
            {
                DistanceToTarget = 1;
            }

            forceVector = force * toTarget.normalized/DistanceToTarget;
            forceVector = new Vector3(forceVector.x, forceVector.y, 0);

            Rigidbody otherRb = other.GetComponent<Rigidbody>();

            otherRb.AddForce(forceVector);
           GuyBubble.vBlowTmp = forceVector;
            GuyBubble.vBlowTmpAtLastImpulse = forceVector;
           
        }


     


    }
    private void OnTriggerExit(Collider other)
    {
        GuyBubble.vBlowTmp = Vector3.zero;


    }

}
