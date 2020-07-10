using System.Collections;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    [SerializeField] private bool isFinish = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isFinish) { GameManager.OnFinish?.Invoke(); return; }
            GameManager.OnCheckpoint?.Invoke();

            Destroy(GetComponent<BoxCollider>());
        }
    }
}