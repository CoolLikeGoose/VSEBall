using UnityEngine;

public class LavaController : MonoBehaviour
{
    /*
    [SerializeField] private float startRadius;
    [SerializeField] private float deathRadius;

    [SerializeField] private Vector3 startCube;
    [SerializeField] private Vector3 deathCube;

    private void Start()
    {
        startCube = transform.localScale + new Vector3(2, 2, 2);    
        deathCube = transform.localScale + new Vector3(7, 3, 7);
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawWireSphere(transform.position, startRadius);
        //Gizmos.DrawWireSphere(transform.position, deathRadius);

        Gizmos.DrawWireCube(transform.position, startCube);
        Gizmos.DrawWireCube(transform.position, deathCube);
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<BallController>().nowLavaCenter = transform.position.x;  
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BallController playerBall = other.GetComponent<BallController>();
            if (playerBall.nowLavaCenter == transform.position.x)
            {
                playerBall.nowLavaCenter = 0;
                playerBall.rend.material.color = playerBall.startColor;
            }
        }
    }
}
