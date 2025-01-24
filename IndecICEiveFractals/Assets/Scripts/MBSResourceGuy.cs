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
    //[SerializeField] float vForce =0.2f;
    [SerializeField] GuyBubble GuyBubble;
    [SerializeField] float vIncrement;
    [SerializeField] float vBubbleNewSize;
    [SerializeField] float vCentreLimit = 0.1f;
    [SerializeField] float vAttractionRate = 0.1f;
    [SerializeField] Vector3 vPosTmp;
    [SerializeField] float vSizeChange = .5f;
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
    public bool isInBase = false;
    [SerializeField] GameObject vSelf;
    [SerializeField] float vDist;

    [SerializeField] GameObject gSprite;
    [SerializeField] GameObject gDissolve;


    [SerializeField] SFX SFX;

    [SerializeField] BubblePop BubblePop;
    [SerializeField] Transform gResourceParent;
    [SerializeField] Vector3 vStartPos;
    [SerializeField] bool isReturning;
    [SerializeField] float vReturnSpeed = .1f;
    [SerializeField] Vector3 vStartSizeRes;


    private void Start()
    {

        vSizeStart = transform.localScale;

        gBase = FindFirstObjectByType<MBSBaseGuy>().transform;
        MBSBubbleEnemyInteraction = FindFirstObjectByType<MBSBubbleEnemyInteraction>().GetComponent<MBSBubbleEnemyInteraction>();

        GameManager = FindFirstObjectByType<GameManager>().GetComponent<GameManager>();
        vStartPos = transform.localPosition;
        vStartSizeRes = transform.localScale;   

        vReturnSpeed = .03f;

        // vSelf = gameObject;

        //Collider = GetComponent<SphereCollider>();    
    }

    public void FnFindBubble()
    {
        GuyBubble = FindFirstObjectByType<GuyBubble>();
        if (GuyBubble != null)
        {
            gBubble = GuyBubble.transform;
            vSlot1 = gBubble.transform.Find("ResourceSlot1");
            vSlot2 = gBubble.transform.Find("ResourceSlot2");
            vSlot3 = gBubble.transform.Find("ResourceSlot3");
            GuyBubble.vResourcesCarried = 0;
        }
    }


    void Update()
    {
        FnFindBubble();



        if (isAttached)
        {
            if (GuyBubble.vSize < vBubbleNewSize)

            {
                GuyBubble.vSize += vIncrement * Time.deltaTime;
                transform.localScale = vSizeStart;
                

            }




            vPosTmp = transform.localPosition;

            if (vPosTmp.magnitude > vCentreLimit)
            {
                vPosTmp *= (1 - (vAttractionRate * Time.deltaTime));

                transform.localPosition = vPosTmp;
            }

            //check for op only if attached to the bubble
           

            if (BubblePop.isPopped)
            {
                
                    gResourceParent = GameObject.FindWithTag("RParent").transform;

                    transform.parent = gResourceParent;
                    isReturning = true;
                    isAttached = false;
                transform.localScale = vStartSizeRes;

                
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
                transform.localScale = transform.localScale * (1 - 0.05f * Time.deltaTime);

                //   Debug.Log("Resource has to get closer" + vPosTmp + "    World  "   + gBase.position);

            }

            else
            {
                Debug.Log("Destroy");
                gSprite.SetActive(false);
                gDissolve.SetActive(true);
                Destroy(gameObject, 5);
                isInBase = false;


            }




        }


        if (isReturning)

        {
            //Drift back to start point
            vPosTmp = ( vStartPos- transform.localPosition );
            
            vDist = vPosTmp.magnitude;

            if (vDist > vCentreLimit)

            {
                vPosTmp  = vPosTmp.normalized;
                    vPosTmp *= (1 - (vAttractionRate * Time.deltaTime));
                vPosTmp *= vReturnSpeed;

                transform.localPosition = transform.localPosition + vPosTmp;


                //   Debug.Log("Resource has to get closer" + vPosTmp + "    World  "   + gBase.position);

            }

            else
            {
                isReturning = false;

            }

        }





    }

    void OnTriggerEnter(Collider other)
        {
            vHitShow = other.transform;
            vHitLayer = other.gameObject.layer;

            gBase = FindFirstObjectByType<MBSBaseGuy>().transform;
            MBSBubbleEnemyInteraction = FindFirstObjectByType<MBSBubbleEnemyInteraction>().GetComponent<MBSBubbleEnemyInteraction>();

            GameManager = FindFirstObjectByType<GameManager>().GetComponent<GameManager>();
            GuyBubble = FindFirstObjectByType<GuyBubble>().GetComponent<GuyBubble>();

            SFX = FindFirstObjectByType<SFX>().GetComponent<SFX>();

            if (other.gameObject.layer == 8)

            {

                Debug.Log("Base Hit");

                GetComponent<Collider>().enabled = false;


                GuyBubble = gBubble.GetComponent<GuyBubble>();

                isAttached = false;
                isInBase = true;

                Debug.Log("Resource score is " + vResourceScore);
                if (vResourceScore == 0)
                {
                    Debug.Log("Score Chnged");
                }



                if (GuyBubble == null)
                {
                    Debug.Log("No GuyBubble- why??");
                }

                else
                {
                    Debug.Log("Size" + GuyBubble.vSize);
                }


                GuyBubble.vSize = GuyBubble.vSize / (1 + vSizeChange);
                vBubbleNewSize = GuyBubble.vSize / (1 + vSizeChange);

                GuyBubble.vResourcesCarried = GuyBubble.vResourcesCarried - 1;

                if (GuyBubble.vResourcesCarried < 0)
                {
                    GuyBubble.vResourcesCarried = 0;
                }
                transform.parent = gBase;
                GameManager.updateUI(vResourceScore, 0);
                SFX.SoundDrop();

            }

            // if player touches the resource
            else if (other.gameObject.layer == 6)

            {
                Debug.Log("Current Parent " + transform.parent);

                if (transform.parent.name == "ResourceParent")
                {
                    SFX = FindFirstObjectByType<SFX>().GetComponent<SFX>();


                    if (GuyBubble.vResourcesCarried == 0)
                    {
                        GuyBubble.vResourcesCarried = 1;
                        transform.parent = vSlot1;

                        isReturning = false;

                        // Collider.enabled = false;
                        isAttached = true;
                        vBubbleNewSize = GuyBubble.vSize + vSizeChange;
                        GuyBubble.vBlowTmp = new Vector3(1, 0, 0);
                        GuyBubble.vBlowTmpAtLastImpulse = new Vector3(1, 0, 0);
                        SFX.SoundGrab();
                    BubblePop = FindFirstObjectByType<BubblePop>();

                    Debug.Log("Checking for slots");

                        /* if (GuyBubble.vResourcesCarried == 3)
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

                          }*/



                    }










                }





            }
        }



    
}
