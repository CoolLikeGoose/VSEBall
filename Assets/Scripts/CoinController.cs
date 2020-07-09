using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;

    private void Update()
    {
        transform.Rotate(new Vector3(0, rotationSpeed, 0) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager.OnCoinCollected?.Invoke();

        Destroy(gameObject);
    }
}
