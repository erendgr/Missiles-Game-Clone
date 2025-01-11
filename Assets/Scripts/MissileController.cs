using System;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;





    // Update is called once per frame
    void FixedUpdate()
    {
        var direction = PlayerController.Instance.transform.position - transform.position;
        direction = direction.normalized;

        var rotateAmount = Vector3.Cross(direction, transform.up).z;
        
        rigidbody.velocity = (transform.up * (moveSpeed * Time.deltaTime));
        rigidbody.angularVelocity = -rotateAmount * (rotateSpeed * Time.deltaTime);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Missile"))
        {
            Destroy(gameObject);
        }
    }
}