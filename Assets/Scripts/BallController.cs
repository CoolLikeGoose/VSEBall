using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody rigidbody;

    private int coins;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        GameManager.OnCoinCollected += () => { coins++; };
    }

    private void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Time.deltaTime * speed;
        rigidbody.AddForce(movement);
    }
}
