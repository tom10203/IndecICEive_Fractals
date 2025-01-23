using UnityEngine;

public class MBSRotateGuy : MonoBehaviour
{
    [SerializeField] float vRotateSpeed;
    [SerializeField] Vector3 vRotateVector = new Vector3(0,1,0);
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(vRotateVector * vRotateSpeed);

        
    }
}
