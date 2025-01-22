using UnityEngine;

public class MBSBoundatryBubble : MonoBehaviour
{
    


    [SerializeField] Transform gBubble;
    [SerializeField] GuyBubble GuyBubble;
    [SerializeField] float vDamageonWall = 10f;


    // Negative is a bounce in a direction
    [SerializeField] float vReflectHorizontal=-0.8f;
    [SerializeField] float vReflectVertical = 0.8f;
    
       
    [SerializeField] Vector3 vVectorLinearVel;
    [SerializeField] Rigidbody rb;

    //boundary
    [SerializeField] float xUpperLimit=18;
    [SerializeField] float yUpperLimit=9.4f;
    [SerializeField] float xLowerLimit =-21; 
    [SerializeField] float yLowerLimit=-7;
    [SerializeField] Vector3 tmpPos;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gBubble = FindFirstObjectByType<GuyBubble>().transform;
        rb = gBubble.GetComponent<Rigidbody>();
        GuyBubble = gBubble.GetComponent<GuyBubble>();


    }

    // Update is called once per frame
    void Update()
    {
        //boundary check
        tmpPos = gBubble.transform.position;

        if (tmpPos.x > xUpperLimit)
        {
            tmpPos.x = xUpperLimit;
        }

        if (tmpPos.x < xLowerLimit)
        {
            tmpPos.x = xLowerLimit;
        }
        if (tmpPos.y > yUpperLimit)
        {
            tmpPos.y = yUpperLimit;
        }
        if (tmpPos.y < yLowerLimit)
        {
            tmpPos.y = yLowerLimit;
        }

        gBubble.transform.position = tmpPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.layer ==6)

        {
           //Bounce
            
            vVectorLinearVel = rb.linearVelocity;

            vVectorLinearVel.x = vVectorLinearVel.x * vReflectHorizontal;
            vVectorLinearVel.y = vVectorLinearVel.y * vReflectVertical;

            rb.linearVelocity = vVectorLinearVel;

            //Damage

            GuyBubble.FnHealthChange(vDamageonWall);



        }


    }


}
