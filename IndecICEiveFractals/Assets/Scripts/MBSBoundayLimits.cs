using UnityEngine;

public class MBSBoundayLimits : MonoBehaviour
{

    //boundary
    [SerializeField] Transform gBubble;
    [SerializeField] float xUpperLimit = 18;
    [SerializeField] float yUpperLimit = 9.4f;
    [SerializeField] float xLowerLimit = -21;
    [SerializeField] float yLowerLimit = -7;
    [SerializeField] Vector3 tmpPos;// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gBubble = FindFirstObjectByType<GuyBubble>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        //boundary check
        tmpPos = gBubble.transform.position;

        if (tmpPos.x > xUpperLimit)
        {
            tmpPos.x = xUpperLimit;
        }

        if (tmpPos.x < xLowerLimit)
        {
            tmpPos.x = xLowerLimit;
        }
        if (tmpPos.y > yUpperLimit)
        {
            tmpPos.y = yUpperLimit;
        }
        if (tmpPos.y < yLowerLimit)
        {
            tmpPos.y = yLowerLimit;
        }

        gBubble.transform.position = tmpPos;
    }
}
