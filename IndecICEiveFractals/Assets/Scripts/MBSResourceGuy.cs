using UnityEngine;
using UnityEngine.UIElements;

public class MBSResourceGuy : MonoBehaviour
{

    [SerializeField] int vResouceNo;
    [SerializeField] bool isAttached = false;
    [SerializeField] Transform gBubble;
    [SerializeField] Vector3 vOffset;
    [SerializeField] Rigidbody rb;
    [SerializeField] float vForce =0.2f;
    [SerializeField] GuyBubble GuyBubble;
    [SerializeField] float vIncrement;
    [SerializeField] float vBubbleNewSize;
    [SerializeField] float vCentreLimit =0.1f;
    [SerializeField] float vAttractionRate =0.1f;
    [SerializeField] Vector3 vPosTmp;
    [SerializeField] float vSizeChange =.5f;
    [SerializeField] Vector3 vSizeStart;
    [SerializeField] Transform vSlot1;
    [SerializeField] Transform vSlot2;
    [SerializeField] Transform vSlot3;


    private void Start()
    {
        gBubble = FindFirstObjectByType<GuyBubble>().transform;
        vSizeStart = transform.localScale;
        GuyBubble = gBubble.GetComponent<GuyBubble>();
        vSlot1 = gBubble.transform.Find("ResourceSlot1");
        vSlot2 = gBubble.transform.Find("ResourceSlot2");
        vSlot3 = gBubble.transform.Find("ResourceSlot3");


    }


    void Update()
    {

        if (isAttached)
        {
            if (GuyBubble.vSize < vBubbleNewSize)

            {
                GuyBubble.vSize += vIncrement *Time.deltaTime;
                transform.localScale = vSizeStart;


            }

           vPosTmp = transform.localPosition;
            if (vPosTmp.magnitude > vCentreLimit)
            {
                vPosTmp *= (1 - (vAttractionRate * Time.deltaTime)); 

                transform.localPosition = vPosTmp;
            }


        }


    }



    private void OnTriggerEnter(Collider other)
    {

        // if player touches the resource
        if (other.gameObject.layer == 6)

        { 
        
        isAttached = true;
            vBubbleNewSize = GuyBubble.vSize + vSizeChange;
            GuyBubble.vBlowTmp = new Vector3(1,0,0);
            GuyBubble.vBlowTmpAtLastImpulse = new Vector3(1, 0, 0);

            if (GuyBubble.vResourcesCarried == 3)
            {
                GuyBubble.FnBurst();


            }

            if (GuyBubble.vResourcesCarried == 2)
            {
                GuyBubble.vResourcesCarried = 3;
                GuyBubble.vCollect[2] = vResouceNo;
                transform.parent = vSlot3;

            }

            if (GuyBubble.vResourcesCarried == 1)
            {
                GuyBubble.vResourcesCarried = 2;
                GuyBubble.vCollect[1] = vResouceNo;
                transform.parent = vSlot2;
            }

            

           
            if (GuyBubble.vResourcesCarried == 0)
            {
                GuyBubble.vResourcesCarried = 1;
                GuyBubble.vCollect[0] = vResouceNo;
                transform.parent = vSlot1;
            }

        }
                
                
                }
}
