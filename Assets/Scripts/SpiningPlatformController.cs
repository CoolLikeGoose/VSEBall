using UnityEngine;

public class SpiningPlatformController : MonoBehaviour
{
    public float rotationSpeed;

    private void Start()
    {
        transform.eulerAngles = new Vector3(Random.Range(-15, 15), 0, 0);
    }

    private void Update()
    {
        transform.Rotate(new Vector3(rotationSpeed * Time.deltaTime, 0, 0));
    }
}
