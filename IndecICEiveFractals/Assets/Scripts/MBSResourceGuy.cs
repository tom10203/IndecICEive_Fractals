using UnityEngine;
using UnityEngine.UIElements;

public class MBSResourceGuy : MonoBehaviour
{

    [SerializeField] int vResouceNo;
    [SerializeField] int vResourceScore;
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

    [SerializeField] GameObject gLight;
    [SerializeField] GameObject gDissolveEffect;

    [SerializeField] GameObject gLight;
    [SerializeField] GameObject gDissolveEffect;

    [SerializeField] GameObject gLight;
    [SerializeField] GameObject gDissolveEffect;

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

            vPosTmp = transform.localPosition;
            float vDist = vPosTmp.magnitude;

            if (vDist > vCentreLimit)
                
            {
                vPosTmp *= (1 - (vAttractionRate * Time.deltaTime));

                transform.localPosition = vPosTmp;

                Debug.Log("Resource has to get closer");
            }

            else
            {
<<<<<<< Updated upstream
                Debug.Log("Resource Destroyed");
                GameManager.updateUI(vResourceScore, 0);
                Destroy(gameObject);

=======
                Debug.Log("Destroy");
               gameObject.SetActive(false);
              gDissolveEffect.SetActive(true);
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes

            }

        }



    }



    private void OnTriggerEnter(Collider other)
    {
        vHitShow = other.transform;
        vHitLayer = other.gameObject.layer;
        // if player touches the resource
        if (other.gameObject.layer == 6)

        {
            Debug.Log("Current Parent " + transform.parent);

            if (transform.parent.name == "ResourceParent")
            {
                {
                    // Collider.enabled = false;
                    gLight.SetActive(false);
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
