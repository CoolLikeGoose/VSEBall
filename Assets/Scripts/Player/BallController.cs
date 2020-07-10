using System;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody rbody;
    [NonSerialized] public Renderer rend;
    [NonSerialized] public Color startColor;

    [NonSerialized] public Vector3 startAcceleration;
    [NonSerialized] public Vector3 movement;

    private Vector3 startPos;

    [NonSerialized] public float nowLavaCenter = 0;

    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        startAcceleration = new Vector3(Input.acceleration.x, Input.acceleration.z, Input.acceleration.y);
        startPos = transform.position;

        GameManager.OnRoundLose += () =>
        {
            transform.position = startPos;
            rbody.velocity = Vector3.zero;
        };

        GameManager.OnCheckpoint += () =>
        {
            startPos = transform.position;
        };
    }

    //fix it
    private void Update()
    {
        if (nowLavaCenter != 0) 
        {
            rend.material.color = Color.LerpUnclamped(startColor, Color.black, transform.position.x/nowLavaCenter * 1.3f);
            if (transform.position.x / nowLavaCenter > 0.7f) { GameManager.OnRoundLose?.Invoke(); }
        }
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
        startAcceleration = new Vector3(Input.acceleration.x, Input.acceleration.z, Input.acceleration.y);  
    }
}
