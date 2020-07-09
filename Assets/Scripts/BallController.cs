using System;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody rbody;

    [NonSerialized] public Vector3 startAcceleration;

    public Vector3 movement;

    private void Start()
    {
        rbody = GetComponent<Rigidbody>();

        Vector3 movement = new Vector3(Input.acceleration.x, Input.acceleration.z, Input.acceleration.y) * 9.8f;
        rbody.AddForce(movement, ForceMode.Acceleration);

        startAcceleration = Input.acceleration;
    }

    private void FixedUpdate()
    {
        #if UNITY_EDITOR
            movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Time.deltaTime * speed;
            rbody.AddForce(movement);
#elif UNITY_ANDROID
            movement = new Vector3(Input.acceleration.x, Input.acceleration.z, Input.acceleration.y) - startAcceleration;
            rbody.AddForce(movement * 9.8f, ForceMode.Acceleration);
#endif
    }

    public void DiscardAcceleration()
    {
        startAcceleration = Input.acceleration;
    }
}
