using UnityEngine;

public class MBSBaseGuy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnCollisionStay(Collision collision)
    {
        // if the bubble is touching the base

        if (collision.gameObject.layer == 6)
        {
            FnRecover();

            FnTransfer();

        }
    }

    void FnRecover()

    {


    }

    void FnTransfer()
    {


    }


}
