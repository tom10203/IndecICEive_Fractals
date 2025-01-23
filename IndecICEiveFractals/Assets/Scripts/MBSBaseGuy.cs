using UnityEngine;

using System.Collections;
using Unity.Mathematics;

public class MBSBaseGuy : MonoBehaviour
{
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    [SerializeField] GuyBubble GuyBubble;
    [SerializeField] Transform gBubble;
    [SerializeField] Transform vSlot1;
    [SerializeField] Transform vSlot2;
    [SerializeField] Transform vSlot3;
    [SerializeField] Transform gBase;
    [SerializeField] Transform vContact;
    [SerializeField] MBSResourceGuy MBSResourceGuy;
=======
    [SerializeField] float vRiseRate;
    [SerializeField] float vEnd =9;
    [SerializeField] GameManager GameManager;
>>>>>>> Stashed changes
=======
    [SerializeField] float vRiseRate;
    [SerializeField] float vEnd =9;
    [SerializeField] GameManager GameManager;
>>>>>>> Stashed changes
=======
    [SerializeField] float vRiseRate;
    [SerializeField] float vEnd =9;
    [SerializeField] GameManager GameManager;
>>>>>>> Stashed changes

    private void Start()
    {
        GameManager = FindFirstObjectByType<GameManager>().GetComponent<GameManager>();
    }

<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Bubble hits base");
        vContact = collision.GetComponent<Transform>();
        
        if (vContact == gBubble)
        {

            Debug.Log("Bubble hits base - registered");

            FnTransferRes();
            GuyBubble.vSize = 1;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        // if the bubble is touching the base
        

        if (collision.transform == gBubble)
        {
            FnRecover();

            

        }
    }

    void FnRecover()

=======
    private void Update()
>>>>>>> Stashed changes
=======
    private void Update()
>>>>>>> Stashed changes
=======
    private void Update()
>>>>>>> Stashed changes
    {



        transform.Translate(0, vRiseRate * Time.deltaTime, 0);
        if (transform.position.y >vEnd)
        {

            GameManager.gameOverState();


        }


    }

<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    void FnTransferRes()
    {
        Debug.Log("TransferFn");

        if (vSlot1.GetChild(0) !=null)
        {
            Debug.Log("Resouce in slot 1");
            MBSResourceGuy = vSlot1.GetChild(0).GetComponent<MBSResourceGuy>();

            vSlot1.GetChild(0).parent = gBase;

            

            MBSResourceGuy.isAttached = false;
            MBSResourceGuy.isInBase = true;
            
        }
        else
        {
            Debug.Log("Notihing in slot 1");

        }
/*
        if (vSlot2.GetChild(0) != null)
        {
            Debug.Log("Resouce in slot 2");
            vSlot2.GetChild(0).parent = gBase;

        }
        else
        {
            Debug.Log("Notihing in slot 2");

        }

        if (vSlot3.GetChild(0) != null)
        {
            Debug.Log("Resouce in slot 3");
            vSlot3.GetChild(0).parent = gBase;

        }
        else
        {
            Debug.Log("Notihing in slot 3");

        }
        */

        Debug.Log("Clear Bubble");
        GuyBubble.vSize = 1;
        GuyBubble.vResourcesCarried = 0;
        GuyBubble.vCollect[0] = 0;
        GuyBubble.vCollect[1] = 0;
        GuyBubble.vCollect[2] = 0;
    }

=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes

}

