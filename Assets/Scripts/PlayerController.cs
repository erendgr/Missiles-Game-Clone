using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }
    
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;

    private float _input;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        _input = Input.GetAxis("Horizontal");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbody.velocity = (transform.up * (moveSpeed * Time.deltaTime));
        rigidbody.angularVelocity = -_input * (rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Missile"))
        {
            Time.timeScale = 0;
        }
    }
}