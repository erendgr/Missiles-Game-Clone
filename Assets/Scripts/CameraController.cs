using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        var position = target.position - offset;
        var currentPosition = Vector3.Lerp(transform.position, position, 5f * Time.deltaTime);
        currentPosition.z = transform.position.z;
        
        transform.position = currentPosition;
    }
}