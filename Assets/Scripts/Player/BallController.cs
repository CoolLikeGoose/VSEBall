using System;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody rbody;

    [NonSerialized] public Vector3 startAcceleration;
    [NonSerialized] public Vector3 movement;

    private Vector3 startPos;

    private void Start()
    {
        rbody = GetComponent<Rigidbody>();

        startAcceleration = Input.acceleration;
        startPos = transform.position;

        GameManager.OnRoundLose += () =>
        {
            transform.position = startPos;
            rbody.velocity = Vector3.zero;
        };
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
