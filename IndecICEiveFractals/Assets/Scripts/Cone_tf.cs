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

            //Scaling force based on angle between end of blower and target
            float dot = Vector3.Dot(-transform.forward, toTarget.normalized); // returns a number between 0-1. 1 being bubble is directly in front of the blower, 0 being perpendicular. From testing values range from ~ 0.8-0.98, due to cone shape of collider.

            forceVector = forceVector * dot;
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
