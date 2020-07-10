using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private float smoothFactor;

    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - player.position;
    }   

    private void Update()
    {
        //transform.position = Vector3.Lerp(transform.position, player.position + offset, smoothFactor);
        transform.position = player.position + offset;
    }
}
