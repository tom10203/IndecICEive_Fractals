using UnityEngine;

public class MBSRotate : MonoBehaviour
{
    [SerializeField] float vRotate=4;
    [SerializeField] Vector3 vAngle = new Vector3 (0f, 1f, 0f);
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.Rotate(vAngle * Random.Range (0f, 50f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(vAngle * vRotate *Time.deltaTime);
    }
}
