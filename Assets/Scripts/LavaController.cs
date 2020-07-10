using UnityEngine;

public class LavaController : MonoBehaviour
{
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

            playerBall.nowLavaCenter = 0;
            playerBall.rend.material.color = playerBall.startColor;
        }
    }
}
