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


        if (transform.position.y > vUpperLimit)
        {
            GameManager.gameOverState();

        }



    }

}
