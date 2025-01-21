using UnityEngine;

using System.Collections;

public class MBSBaseGuy : MonoBehaviour
{
    [SerializeField] GuyBubble GuyBubble;
    [SerializeField] Transform gBubble;


    private void Start()
    {
        gBubble = FindFirstObjectByType<GuyBubble>().transform;
        
        GuyBubble = gBubble.GetComponent<GuyBubble>();

    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnCollisionEnter(Collision collision)
    {
     StartCoroutine(   FnTransfer());
    }

    private void OnCollisionStay(Collision collision)
    {
        // if the bubble is touching the base

        if (collision.gameObject.layer == 6)
        {
            FnRecover();

            

        }
    }

    void FnRecover()

    {


    }

    IEnumerator FnTransfer()
    {
        if (GuyBubble.vResourcesCarried >2)
        {



        }

        yield return null;

    }


}
