using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class MBSResourceGuy : MonoBehaviour
{

    [SerializeField] int vResouceNo;
    public int vResourceScore;
    public bool isAttached = false;
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

    [SerializeField] Transform gBase;

    [SerializeField] MBSBubbleEnemyInteraction MBSBubbleEnemyInteraction;
    [SerializeField] Collider Collider;
    [SerializeField] Transform vHitShow;
    [SerializeField] int vHitLayer;
    [SerializeField] int vHitLayer2;
    [SerializeField] GameManager GameManager;
    public bool isInBase =false;
    [SerializeField] GameObject vSelf;
    [SerializeField] float vDist;

    private void Start()
    {
        gBubble = FindFirstObjectByType<GuyBubble>().transform;
        vSizeStart = transform.localScale;
        GuyBubble = gBubble.GetComponent<GuyBubble>();
        vSlot1 = gBubble.transform.Find("ResourceSlot1");
        vSlot2 = gBubble.transform.Find("ResourceSlot2");
        vSlot3 = gBubble.transform.Find("ResourceSlot3");
        gBase = FindFirstObjectByType<MBSBaseGuy>().transform;
        MBSBubbleEnemyInteraction = FindFirstObjectByType<MBSBubbleEnemyInteraction>().GetComponent<MBSBubbleEnemyInteraction>();
        GuyBubble.vResourcesCarried = 0;
        GameManager = FindFirstObjectByType<GameManager>().GetComponent<GameManager>();

        vSelf = gameObject;

        //Collider = GetComponent<SphereCollider>();    
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

        if (isInBase)
        {
            
            transform.parent = gBase;
            vResourceScore = 0;

          //  Debug.Log("Gets closer");
            vPosTmp = transform.localPosition;
            vDist = vPosTmp.magnitude;

            if (vDist > vCentreLimit)
                
            {
                vPosTmp *= (1 - (vAttractionRate * Time.deltaTime));

                transform.localPosition = vPosTmp;

             //   Debug.Log("Resource has to get closer" + vPosTmp + "    World  "   + gBase.position);
                
            }

            else
            {
                Debug.Log("Destroy");
               gameObject.SetActive(false);
              

            }

        }



    }



    private void OnTriggerEnter(Collider other)
    {
        vHitShow = other.transform;
        vHitLayer = other.gameObject.layer;

        if (other.gameObject.layer == 8)

        {

            Debug.Log("Base Hit");

            GetComponent<Collider>().enabled = false;


            isAttached = false;
            isInBase = true;
            GameManager.updateUI(vResourceScore, 0);
            vResourceScore = 0;
            Debug.Log("Resource score is " + vResourceScore);
            if (vResourceScore == 0)
            { 
                Debug.Log("Score Chnged");
            }

            transform.parent = gBase;

            if (GuyBubble = null)
            {
                Debug.Log("No GuyBubble- why??");
            }

            else
            {
                Debug.Log ("Size" + GuyBubble.vSize);
            }


            GuyBubble.vSize = GuyBubble.vSize/vSizeChange;
            vBubbleNewSize = GuyBubble.vSize/vSizeChange;

            GuyBubble.vResourcesCarried = GuyBubble.vResourcesCarried - 1;
            if (GuyBubble.vResourcesCarried < 0)
            {
                GuyBubble.vResourcesCarried = 0;
            }
        }
        
        // if player touches the resource
        else if (other.gameObject.layer == 6)

        {
            Debug.Log("Current Parent " + transform.parent);

            if (transform.parent.name == "ResourceParent")
            {
                {
                    // Collider.enabled = false;
                    isAttached = true;
                    vBubbleNewSize = GuyBubble.vSize + vSizeChange;
                    GuyBubble.vBlowTmp = new Vector3(1, 0, 0);
                    GuyBubble.vBlowTmpAtLastImpulse = new Vector3(1, 0, 0);

                    Debug.Log("Checking for slots");

                   if (GuyBubble.vResourcesCarried == 3)
                    {
                        MBSBubbleEnemyInteraction.FnBurst();

                    }

                    if (GuyBubble.vResourcesCarried == 2)
                    {
                        GuyBubble.vResourcesCarried = 3;
                        transform.parent = vSlot3;

                    }

                    if (GuyBubble.vResourcesCarried == 1)
                    {
                        GuyBubble.vResourcesCarried = 2;
                        transform.parent = vSlot2;

                    }
                    if (GuyBubble.vResourcesCarried == 0)
                    {
                        GuyBubble.vResourcesCarried = 1;
                        transform.parent = vSlot1;

                    }
                    
                   





                }


            }


            

               


            


        }
    }

   

}
