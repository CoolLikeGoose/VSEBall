using System.Collections;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public Transform moveTo;
    private Vector3 startPos;

    public Transform forBall;

    public float speed = 5f;

    private void Start()
    {
        startPos = transform.position;

        StartCoroutine(moveToFinish());
    }

    private IEnumerator moveToFinish()
    {
        while (transform.position != moveTo.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveTo.position, speed * Time.deltaTime);
            forBall.position = transform.position;

            yield return null;
        }

        yield return new WaitForSeconds(1.5f);
        StartCoroutine(moveToStart());
    }

    private IEnumerator moveToStart()
    {
        while (transform.position != startPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
            forBall.position = transform.position;

            yield return null;
        }

        yield return new WaitForSeconds(1.5f);
        StartCoroutine(moveToFinish());
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(forBall);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(null);
            other.transform.localScale = Vector3.one;
        }
    }
    
}
