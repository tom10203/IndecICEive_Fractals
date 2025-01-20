using UnityEngine;

public class GuyPlaceholderForce : MonoBehaviour
{
    [SerializeField] Transform gBubble;
    [SerializeField] Vector3 vDistance;
    public Vector3 vBlow;
    [SerializeField] float vBlowerPower = 10;
    [SerializeField] float vBlowerMove = 10;
    [SerializeField] Transform gBlower;
    [SerializeField] Rigidbody rbBubble;
    [SerializeField] GuyBubble MBSGuyBubble;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        gBubble = FindFirstObjectByType<GuyBubble>().transform;
        rbBubble = gBubble.GetComponent<Rigidbody>();
        MBSGuyBubble = gBubble.GetComponent <GuyBubble>();

    }

    // Update is called once per frame
    void Update()
    {
        
        vDistance = gBubble.position - transform.position;

        vBlow = new Vector3(vDistance.x, 0, vDistance.z);
        vBlow = vBlow * vBlowerPower / vDistance.magnitude;

        rbBubble.AddForce(vBlow, ForceMode.Impulse);
        MBSGuyBubble.vBlowTmp = vBlow;


        if (Input.GetKey(KeyCode.W))

        {
            gBlower.transform.Translate(0, 0, vBlowerMove * Time.deltaTime,Space.World);

        }

        if (Input.GetKey(KeyCode.S))

        {
            gBlower.transform.Translate(0, 0, -vBlowerMove * Time.deltaTime, Space.World);

        }


        if (Input.GetKey(KeyCode.A))

        {
            gBlower.transform.Translate( -vBlowerMove * Time.deltaTime, 0, 0, Space.World);

        }
        if (Input.GetKey(KeyCode.D))

        {
            gBlower.transform.Translate(vBlowerMove * Time.deltaTime, 0, 0, Space.World );

        }
    }
}
