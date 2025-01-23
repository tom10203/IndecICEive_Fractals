using UnityEngine;



public class MBSBaseGuy : MonoBehaviour
{
    [SerializeField] float vRiseRate = .05f;
    [SerializeField] float vUpperLimit = 9f;
    [SerializeField] GameManager GameManager;

    private void Start()
    {
        GameManager =FindFirstObjectByType<GameManager>().GetComponent<GameManager>();
    }

    private void Update()
    {
        transform.Translate(0, vRiseRate *Time.deltaTime, 0);

        Debug.Log("Base is at " + transform.position);
        Debug.Log("Upper Limit is" + vUpperLimit);
        Debug.Log(GameManager);

        if (transform.position.y > vUpperLimit)
        {
            Debug.Log("Called Game over as Base");
            GameManager.gameOverState();
            Debug.Log("Called Game over as Base it outside limits");

        }



    }

}
