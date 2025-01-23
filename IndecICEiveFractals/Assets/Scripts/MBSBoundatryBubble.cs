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



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gBubble = FindFirstObjectByType<GuyBubble>().transform;
        rb = gBubble.GetComponent<Rigidbody>();
        GuyBubble = gBubble.GetComponent<GuyBubble>();


    }

    // Update is called once per frame
   

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

           // GuyBubble.FnHealthChange(vDamageonWall);



        }


    }


}
