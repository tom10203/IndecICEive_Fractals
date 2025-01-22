using UnityEngine;

public class MBSBubbleEnemyInteraction : MonoBehaviour
{


    [SerializeField] GuyBubble GuyBubble;
    [SerializeField] Transform gBubble;
    [SerializeField] MBSGameManagerGuy MBSGameManagerGuy;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gBubble = FindFirstObjectByType<GuyBubble>().transform;

        GuyBubble = gBubble.GetComponent<GuyBubble>();
        MBSGameManagerGuy = FindFirstObjectByType<MBSGameManagerGuy>().GetComponent<MBSGameManagerGuy>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter(Collider other)
    {
        // detect enemy


        if (other.gameObject.layer == 7)
        {

            FnBurst();




        }


    }
    public void FnBurst()
    {

        GetComponent<Renderer>().enabled = false;

        MBSGameManagerGuy.SoundBurst();
        MBSGameManagerGuy.FnGameOver();
    }

}
