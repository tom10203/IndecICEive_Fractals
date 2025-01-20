using UnityEngine;

public class GuyPlaceholderForce : MonoBehaviour
{
    [SerializeField] Transform gBubble;
    [SerializeField] Vector3 vDistance;
    [SerializeField] Vector3 vBlow;
    [SerializeField] float vBlowerPower = 10;
    [SerializeField] float vBlowerMove = 10;
    [SerializeField] Transform gBlower;
    [SerializeField] Rigidbody rbBubble;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        gBubble = FindFirstObjectByType<GuyBubble>().transform;
        rbBubble = gBubble.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
        vDistance = gBubble.position - transform.position;

        vBlow = new Vector3(vDistance.x, 0, vDistance.z);
        vBlow = vBlow * vBlowerPower / vDistance.magnitude;

        rbBubble.AddForce(vBlow, ForceMode.Impulse);


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
