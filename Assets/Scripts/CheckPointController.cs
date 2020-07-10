using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.OnCheckpoint?.Invoke();
        }
    }
}
