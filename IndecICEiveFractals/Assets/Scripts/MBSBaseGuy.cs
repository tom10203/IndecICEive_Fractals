using UnityEngine;

using System.Collections;
using Unity.Mathematics;

public class MBSBaseGuy : MonoBehaviour
{
    [SerializeField] GuyBubble GuyBubble;
    [SerializeField] Transform gBubble;
    [SerializeField] Transform vSlot1;
    [SerializeField] Transform vSlot2;
    [SerializeField] Transform vSlot3;
    [SerializeField] Transform gBase;
    [SerializeField] Transform vContact;
    [SerializeField] MBSResourceGuy MBSResourceGuy;


    private void Start()
    {
        gBubble = FindFirstObjectByType<GuyBubble>().transform;
        
        GuyBubble = gBubble.GetComponent<GuyBubble>();
        vSlot1 = gBubble.transform.Find("ResourceSlot1");
        vSlot2 = gBubble.transform.Find("ResourceSlot2");
        vSlot3 = gBubble.transform.Find("ResourceSlot3");
      

    }


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

    {


    }

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


}
